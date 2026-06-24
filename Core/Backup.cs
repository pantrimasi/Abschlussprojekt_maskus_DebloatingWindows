/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Creates Windows restore points and manages backup metadata in a local JSON file.
 */
using System.Collections.Generic;
using System.Text.Json;

namespace WindowsDebloater.Core
{
    public static class Backup
    {
        private static string BackupFile => System.IO.Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
            "WindowsDebloater", "backups.json");

        public static void CreateRestorePoint()
        {
            // create restore point
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"Checkpoint-Computer -Description 'WindowsDebloater Backup' -RestorePointType MODIFY_SETTINGS\"",
                UseShellExecute = false,
                CreateNoWindow = true
            })?.WaitForExit();

            // get ID separately
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"(Get-ComputerRestorePoint | Sort-Object SequenceNumber | Select-Object -Last 1).SequenceNumber\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var process = System.Diagnostics.Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd().Trim();
            process.WaitForExit();

            if (!int.TryParse(output, out int id)) return;

            // save to json
            var backups = LoadBackups();
            string name = $"Backup_{System.DateTime.Now:dd.MM.yyyy_HH-mm-ss}";
            backups.Add(new BackupEntry { Name = name, Id = id });

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(BackupFile));
            System.IO.File.WriteAllText(BackupFile, JsonSerializer.Serialize(backups,
                new JsonSerializerOptions { WriteIndented = true }));
        }

        public static List<BackupEntry> LoadBackups()
        {
            if (!System.IO.File.Exists(BackupFile))
                return new List<BackupEntry>();

            return JsonSerializer.Deserialize<List<BackupEntry>>(
                System.IO.File.ReadAllText(BackupFile)) ?? new List<BackupEntry>();
        }

        public static void RestoreBackup(int id)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Restore-Computer -RestorePoint {id}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            })?.WaitForExit();
        }
    }

    public class BackupEntry
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
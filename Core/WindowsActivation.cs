/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: KMS-based Windows activation using slmgr.vbs with sequential command execution.
 */
using System.Diagnostics;

namespace WindowsDebloater.Core
{
    public static class WindowsActivation
    {
        private static void RunCmdWait(string command)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var process = Process.Start(psi);
            process.WaitForExit();
        }

        public static void ActivatePro()
        {
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX");
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /skms kms8.msguides.com");
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /ato");
        }

        public static void ActivateHome()
        {
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /ipk TX9XD-98N7V-6WMQ6-BX7FG-H8Q99");
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /skms kms8.msguides.com");
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /ato");
        }

        public static void ActivateEnterprise()
        {
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /ipk NPPR9-FWDCX-D2C8J-H872K-2YT43");
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /skms kms8.msguides.com");
            RunCmdWait("cscript //nologo C:\\Windows\\System32\\slmgr.vbs /ato");
        }

        public static string GetEdition()
        {
            string productName = Microsoft.Win32.Registry.GetValue(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                "ProductName", "Unbekannt")?.ToString() ?? "Unbekannt";

            return productName.Replace("Windows 10", "Windows 11");
        }

        public static string GetActivationStatus()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cscript.exe",
                Arguments = "//nologo C:\\Windows\\System32\\slmgr.vbs /dlv",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var process = Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            string licenseStatus = "";

            foreach (string line in output.Split('\n'))
            {
                if (line.Contains("Lizenzstatus") || line.Contains("License Status"))
                    licenseStatus = line.Trim();
            }

            return $"{GetEdition()} - {licenseStatus}";
        }
    }
}

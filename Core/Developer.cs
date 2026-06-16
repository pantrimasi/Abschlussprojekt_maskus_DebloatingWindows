namespace WindowsDebloater.Core
{
    public static class Developer
    {
        private static void RunCmd(string command)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        private static void RunPowerShell(string command)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        private static void SetReg(string path, string name, string type, string value) =>
            RunCmd($"reg add \"{path}\" /v \"{name}\" /t {type} /d \"{value}\" /f");

        public static void EnableAll()
        {
            // file extensions
            SetReg(@"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt", "REG_DWORD", "0");
            // hidden files
            SetReg(@"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Hidden", "REG_DWORD", "1");
            // system files
            SetReg(@"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowSuperHidden", "REG_DWORD", "1");
            // full path in titlebar
            SetReg(@"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\CabinetState", "FullPath", "REG_DWORD", "1");
            // classic context menu
            SetReg(@"HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32", "", "REG_SZ", "");
            // developer mode
            SetReg(@"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock", "AllowDevelopmentWithoutDevLicense", "REG_DWORD", "1");
            // powershell execution policy
            RunPowerShell("Set-ExecutionPolicy RemoteSigned -Scope CurrentUser -Force");
            // WSL
            RunPowerShell("dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart");
            // Hyper-V
            RunPowerShell("dism.exe /online /enable-feature /featurename:Microsoft-Hyper-V-All /all /norestart");
            // Windows Sandbox
            RunPowerShell("dism.exe /online /enable-feature /featurename:Containers-DisposableClientVM /all /norestart");
            // SSH client
            RunPowerShell("Add-WindowsCapability -Online -Name OpenSSH.Client~~~~0.0.1.0");
            // Telnet client
            RunPowerShell("dism.exe /online /enable-feature /featurename:TelnetClient /norestart");

            Animationen.RestartExplorer();
        }
    }
}
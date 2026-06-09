namespace WindowsDebloater.Core
{
    public static class DataProtection
    {
        private static void RunRegistryCommand(string arguments)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {arguments}",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        // Telemetrie
        public static void DisableTelemetry() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d 0 /f");

        // Aktivitätsverlauf
        public static void DisableActivityHistory()
        {
            RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\System\" /v PublishUserActivities /t REG_DWORD /d 0 /f");
            RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\System\" /v UploadUserActivities /t REG_DWORD /d 0 /f");
        }

        // Standort
        public static void DisableLocation() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors\" /v DisableLocation /t REG_DWORD /d 1 /f");

        // Feedback
        public static void DisableFeedback() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Siuf\\Rules\" /v NumberOfSIUFInPeriod /t REG_DWORD /d 0 /f");

        // Suchverlauf
        public static void DisableSearchHistory() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings\" /v IsDeviceSearchHistoryEnabled /t REG_DWORD /d 0 /f");

        // Diagnosedaten
        public static void DisableDiagnosticData() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d 0 /f");

        // Fehlerberichterstattung
        public static void DisableErrorReporting() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Error Reporting\" /v Disabled /t REG_DWORD /d 1 /f");

        // Handschriftdaten
        public static void DisableHandwritingData() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Input\\TIPC\" /v Enabled /t REG_DWORD /d 0 /f");

        // Werbe-ID
        public static void DisableAdvertisingId() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\" /v Enabled /t REG_DWORD /d 0 /f");

        // Personalisierte Werbung
        public static void DisableTailoredExperiences() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Privacy\" /v TailoredExperiencesWithDiagnosticDataEnabled /t REG_DWORD /d 0 /f");

        // Spracherkennung
        public static void DisableSpeechRecognition() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Speech_OneCore\\Settings\\OnlineSpeechPrivacy\" /v HasAccepted /t REG_DWORD /d 0 /f");

        // Kamera
        public static void DisableCameraAccess() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy\" /v LetAppsAccessCamera /t REG_DWORD /d 2 /f");

        // Mikrofon
        public static void DisableMicrophoneAccess() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy\" /v LetAppsAccessMicrophone /t REG_DWORD /d 2 /f");

        // Kontakte
        public static void DisableContactsAccess() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy\" /v LetAppsAccessContacts /t REG_DWORD /d 2 /f");

        // Zwischenablage
        public static void DisableCloudClipboard() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Clipboard\" /v CloudClipboardAutomaticUpload /t REG_DWORD /d 0 /f");
    }
}
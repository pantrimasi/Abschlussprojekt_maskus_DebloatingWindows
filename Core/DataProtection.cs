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

        // Telementry
        public static void DisableTelemetry() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d 0 /f");

        // Activity history
        public static void DisableActivityHistory()
        {
            RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\System\" /v PublishUserActivities /t REG_DWORD /d 0 /f");
            RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\System\" /v UploadUserActivities /t REG_DWORD /d 0 /f");
        }

        // Location
        public static void DisableLocation() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors\" /v DisableLocation /t REG_DWORD /d 1 /f");

        // Feedback
        public static void DisableFeedback() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Siuf\\Rules\" /v NumberOfSIUFInPeriod /t REG_DWORD /d 0 /f");

        // Search History
        public static void DisableSearchHistory() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings\" /v IsDeviceSearchHistoryEnabled /t REG_DWORD /d 0 /f");

        // Diagnostic Data
        public static void DisableDiagnosticData() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d 0 /f");

        // Error Reporting
        public static void DisableErrorReporting() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Error Reporting\" /v Disabled /t REG_DWORD /d 1 /f");

        // Handwriting-Data
        public static void DisableHandwritingData() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Input\\TIPC\" /v Enabled /t REG_DWORD /d 0 /f");

        // Ad-ID
        public static void DisableAdvertisingId() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\" /v Enabled /t REG_DWORD /d 0 /f");

        // Personalized advertising
        public static void DisableTailoredExperiences() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Privacy\" /v TailoredExperiencesWithDiagnosticDataEnabled /t REG_DWORD /d 0 /f");

        // Speech recognition
        public static void DisableSpeechRecognition() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Speech_OneCore\\Settings\\OnlineSpeechPrivacy\" /v HasAccepted /t REG_DWORD /d 0 /f");

        // Camera
        public static void DisableCameraAccess() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy\" /v LetAppsAccessCamera /t REG_DWORD /d 2 /f");

        // Microphone
        public static void DisableMicrophoneAccess() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy\" /v LetAppsAccessMicrophone /t REG_DWORD /d 2 /f");

        // Contacts
        public static void DisableContactsAccess() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppPrivacy\" /v LetAppsAccessContacts /t REG_DWORD /d 2 /f");

        // Clipboard
        public static void DisableCloudClipboard() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Clipboard\" /v CloudClipboardAutomaticUpload /t REG_DWORD /d 0 /f");

        // personalized offers
        public static void DisablePersonalizedOffers() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-338388Enabled /t REG_DWORD /d 0 /f");

        // personalized tips
        public static void DisablePersonalizedTips() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-353698Enabled /t REG_DWORD /d 0 /f");

        // language list access
        public static void DisableLanguageListAccess() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\International\\User Profile\" /v HttpAcceptLanguageOptOut /t REG_DWORD /d 1 /f");

        // app launch tracking
        public static void DisableAppLaunchTracking() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v Start_TrackProgs /t REG_DWORD /d 0 /f");

        // settings notifications + recommendations
        public static void DisableSettingsNotifications() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-338393Enabled /t REG_DWORD /d 0 /f");
        // Disable all
        public static void DisableAll()
        {
            DisableTelemetry();
            DisableActivityHistory();
            DisableLocation();
            DisableFeedback();
            DisableSearchHistory();
            DisableDiagnosticData();
            DisableErrorReporting();
            DisableHandwritingData();
            DisableAdvertisingId();
            DisableTailoredExperiences();
            DisableSpeechRecognition();
            DisableCameraAccess();
            DisableMicrophoneAccess();
            DisableContactsAccess();
            DisableCloudClipboard();
            DisablePersonalizedOffers();
            DisablePersonalizedTips();
            DisableLanguageListAccess();
            DisableAppLaunchTracking();
            DisableSettingsNotifications();
        }
    }
}
/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Registry tweaks to disable Windows advertisements, suggestions and Bing integration.
 */
namespace WindowsDebloater.Core
{
    public static class Ads
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

        // Ad-ID
        public static void DisableAdvertisingId() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\" /v Enabled /t REG_DWORD /d 0 /f");

        // Start menu
        public static void DisableStartMenuSuggestions() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SystemPaneSuggestionsEnabled /t REG_DWORD /d 0 /f");

        // Lockscreen
        public static void DisableLockScreenAds() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-338387Enabled /t REG_DWORD /d 0 /f");

        // App suggestions
        public static void DisableAppSuggestions() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-338388Enabled /t REG_DWORD /d 0 /f");

        // Bing search
        public static void DisableBingSearch() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings\" /v IsDynamicSearchBoxEnabled /t REG_DWORD /d 0 /f");

        // Explorer
        public static void DisableExplorerAds() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v ShowSyncProviderNotifications /t REG_DWORD /d 0 /f");

        // Settings
        public static void DisableSettingsAds1() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-338393Enabled /t REG_DWORD /d 0 /f");
        public static void DisableSettingsAds2() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-353634Enabled /t REG_DWORD /d 0 /f");
        public static void DisableSettingsAds3() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-353636Enabled /t REG_DWORD /d 0 /f");

        // Tipps
        public static void DisableTips() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Privacy\" /v TailoredExperiencesWithDiagnosticDataEnabled /t REG_DWORD /d 0 /f");

        // Setup-Ads
        public static void DisableSetupAds() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement\" /v ScoobeSystemSettingEnabled /t REG_DWORD /d 0 /f");

        // Welcomepage
        public static void DisableWelcomePage() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-310093Enabled /t REG_DWORD /d 0 /f");

        // Popups
        public static void DisablePopups() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SubscribedContent-338389Enabled /t REG_DWORD /d 0 /f");

        // Widgets
        public static void DisableWidgetAds() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Feeds\\DSB\" /v InformationContent /t REG_DWORD /d 0 /f");

        //Disable all
        public static void DisableAll()
        {
            DisableAdvertisingId();
            DisableStartMenuSuggestions();
            DisableLockScreenAds();
            DisableAppSuggestions();
            DisableBingSearch();
            DisableExplorerAds();
            DisableSettingsAds1();
            DisableSettingsAds2();
            DisableSettingsAds3();
            DisableTips();
            DisableSetupAds();
            DisableWelcomePage();
            DisablePopups();
            DisableWidgetAds();
        }

        // Explorer restart
        public static void RestartExplorer()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"Stop-Process -Name explorer -Force\"",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }
    }
}
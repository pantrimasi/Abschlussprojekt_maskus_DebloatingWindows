/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Removes built-in Windows apps via PowerShell grouped by category.
 */
namespace WindowsDebloater.Core
{
    public static class AppRemoval
    {
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

        private static void RemoveAppx(string name) =>
            RunPowerShell($"Get-AppxPackage *{name}* | Remove-AppxPackage -ErrorAction SilentlyContinue");

        // ------------------------------------------------------------------------- AI
        public static void RemoveCopilot() => RemoveAppx("Copilot");
        public static void RemoveCortana() => RemoveAppx("Cortana");
        public static void RemoveJournal() => RemoveAppx("MicrosoftJournal");
        public static void RemoveDevHome() => RemoveAppx("DevHome");

        // ------------------------------------------------------------------------- Gaming Features
        public static void RemoveXboxApp() => RemoveAppx("XboxApp");
        public static void RemoveXboxGameBar() => RemoveAppx("XboxGamingOverlay");
        public static void RemoveXboxConsoleCompanion() => RemoveAppx("XboxOneSmartGlass");
        public static void RemoveXboxTCUI() => RemoveAppx("XboxTCUI");
        public static void RemoveXboxIdentityProvider() => RemoveAppx("XboxIdentityProvider");
        public static void RemoveXboxSpeechToText() => RemoveAppx("XboxSpeechToTextOverlay");
        public static void RemoveSolitaire() => RemoveAppx("MicrosoftSolitaireCollection");

        // ------------------------------------------------------------------------- Communication
        public static void RemoveTeamsNew() => RemoveAppx("MSTeams");
        public static void RemoveTeamsOld() => RemoveAppx("Teams");
        public static void RemoveSkype() => RemoveAppx("SkypeApp");
        public static void RemoveMailCalendar() => RemoveAppx("windowscommunicationsapps");
        public static void RemovePeople() => RemoveAppx("People");
        public static void RemoveMessaging() => RemoveAppx("Messaging");
        public static void RemovePhoneLink() => RemoveAppx("YourPhone");

        // ------------------------------------------------------------------------- Office
        public static void RemoveStickyNotes() => RemoveAppx("MicrosoftStickyNotes");
        public static void RemoveToDo() => RemoveAppx("Todos");
        public static void RemoveOneNote() => RemoveAppx("OneNote");
        public static void RemoveOfficeHub() => RemoveAppx("MicrosoftOfficeHub");
        public static void RemovePowerBI() => RemoveAppx("PowerBI");
        public static void RemovePowerAutomate() => RemoveAppx("PowerAutomateDesktop");
        public static void RemoveSway() => RemoveAppx("MicrosoftSway");
        public static void RemovePCManager() => RemoveAppx("PCManager");

        // ------------------------------------------------------------------------- Unnecessary  Bing Features nobody asked for
        public static void RemoveBingNews() => RemoveAppx("BingNews");
        public static void RemoveBingWeather() => RemoveAppx("BingWeather");
        public static void RemoveBingFinance() => RemoveAppx("BingFinance");
        public static void RemoveBingSports() => RemoveAppx("BingSports");
        public static void RemoveBingFoodDrink() => RemoveAppx("BingFoodAndDrink");
        public static void RemoveBingHealthFitness() => RemoveAppx("BingHealthAndFitness");
        public static void RemoveBingTranslator() => RemoveAppx("BingTranslator");
        public static void RemoveBingTravel() => RemoveAppx("BingTravel");
        public static void RemoveBingSearch() => RemoveAppx("BingSearch");
        public static void RemoveMicrosoftNews() => RemoveAppx("BingNews");

        // ------------------------------------------------------------------------- 3D Tools
        public static void Remove3DViewer() => RemoveAppx("Microsoft3DViewer");
        public static void Remove3DBuilder() => RemoveAppx("3DBuilder");
        public static void RemovePaint3D() => RemoveAppx("MSPaint");
        public static void RemoveMixedReality() => RemoveAppx("MixedReality");
        public static void RemovePrint3D() => RemoveAppx("Print3D");

        // ------------------------------------------------------------------------- Entertainment
        public static void RemoveFilmsTV() => RemoveAppx("ZuneVideo");
        public static void RemoveGrooveMusic() => RemoveAppx("ZuneMusic");
        public static void RemoveClipchamp() => RemoveAppx("Clipchamp");

        // ------------------------------------------------------------------------- System Features
        public static void RemoveFeedbackHub() => RemoveAppx("WindowsFeedbackHub");
        public static void RemoveGetHelp() => RemoveAppx("GetHelp");
        public static void RemoveGetStarted() => RemoveAppx("GetStarted");
        public static void RemoveQuickAssist() => RemoveAppx("QuickAssist");
        public static void RemoveFamilySafety() => RemoveAppx("FamilySafety");
        public static void RemoveNetworkSpeedTest() => RemoveAppx("NetworkSpeedTest");
        public static void RemoveOneConnect() => RemoveAppx("OneConnect");
        public static void RemoveAlarmsClock() => RemoveAppx("WindowsAlarms");
        public static void RemoveSoundRecorder() => RemoveAppx("SoundRecorder");

        // ------------------------------------------------------------------------- Widgetss
        public static void RemoveWidgets() => RemoveAppx("WebExperienceHost");
        public static void RemoveWidgetsPlatform() => RemoveAppx("WidgetsPlatformRuntime");
        public static void RemoveWebExperiencePack() => RemoveAppx("WebExperiencePack");
        public static void RemoveCrossDevice() => RemoveAppx("CrossDevice");

        // ------------------------------------------------------------------------- Special uninstallation methods for apps that you can't normally uninstall
        public static void RemoveEdge()
        {
            string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application";
            if (!System.IO.Directory.Exists(edgePath)) return;
            foreach (string dir in System.IO.Directory.GetDirectories(edgePath))
            {
                string installer = System.IO.Path.Combine(dir, "Installer", "setup.exe");
                if (!System.IO.File.Exists(installer)) continue;
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = installer,
                    Arguments = "--uninstall --system-level --verbose-logging --force-uninstall",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
            }
        }

        public static void RemoveOneDrive()
        {
            RunPowerShell("Stop-Process -Name OneDrive -Force -ErrorAction SilentlyContinue");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "SysWOW64", "OneDriveSetup.exe"),
                Arguments = "/uninstall",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        public static void RemoveOutlook() => RemoveAppx("OutlookForWindows");
        public static void RemoveWhiteboard() => RemoveAppx("Whiteboard");
        public static void RemoveRemoteDesktop() => RemoveAppx("MicrosoftRemoteDesktop");
        public static void Remove365Companions() => RemoveAppx("MicrosoftOffice");

        // ------------------------------------------------------------------------- Groups
        public static void RemoveAllAI()
        {
            RemoveCopilot();
            RemoveCortana();
            RemoveJournal();
            RemoveDevHome();
        }

        public static void RemoveAllGaming()
        {
            RemoveXboxApp();
            RemoveXboxGameBar();
            RemoveXboxConsoleCompanion();
            RemoveXboxTCUI();
            RemoveXboxIdentityProvider();
            RemoveXboxSpeechToText();
            RemoveSolitaire();
        }

        public static void RemoveAllCommunication()
        {
            RemoveTeamsNew();
            RemoveTeamsOld();
            RemoveSkype();
            RemoveMailCalendar();
            RemovePeople();
            RemoveMessaging();
            RemovePhoneLink();
        }

        public static void RemoveAllOffice()
        {
            RemoveStickyNotes();
            RemoveToDo();
            RemoveOneNote();
            RemoveOfficeHub();
            RemovePowerBI();
            RemovePowerAutomate();
            RemoveSway();
            RemovePCManager();
        }

        public static void RemoveAllBing()
        {
            RemoveBingNews();
            RemoveBingWeather();
            RemoveBingFinance();
            RemoveBingSports();
            RemoveBingFoodDrink();
            RemoveBingHealthFitness();
            RemoveBingTranslator();
            RemoveBingTravel();
            RemoveBingSearch();
            RemoveMicrosoftNews();
        }

        public static void RemoveAll3D()
        {
            Remove3DViewer();
            Remove3DBuilder();
            RemovePaint3D();
            RemoveMixedReality();
            RemovePrint3D();
        }

        public static void RemoveAllEntertainment()
        {
            RemoveFilmsTV();
            RemoveGrooveMusic();
            RemoveClipchamp();
        }

        public static void RemoveAllSystem()
        {
            RemoveFeedbackHub();
            RemoveGetHelp();
            RemoveGetStarted();
            RemoveQuickAssist();
            RemoveFamilySafety();
            RemoveNetworkSpeedTest();
            RemoveOneConnect();
            RemoveAlarmsClock();
            RemoveSoundRecorder();
        }

        public static void RemoveAllWidgets()
        {
            RemoveWidgets();
            RemoveWidgetsPlatform();
            RemoveWebExperiencePack();
            RemoveCrossDevice();
        }

        public static void RemoveAllSpecial()
        {
            RemoveEdge();
            RemoveOneDrive();
            RemoveOutlook();
            RemoveWhiteboard();
            RemoveRemoteDesktop();
            Remove365Companions();
        }
    }
}
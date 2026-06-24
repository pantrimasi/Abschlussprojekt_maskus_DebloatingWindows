/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Core application logic for a Windows optimization tool that removes unnecessary system components and improves performance.
 */
using System.Windows;
using System.Windows.Controls;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class CreateProfile : UserControl
    {
        public CreateProfile()
        {
            InitializeComponent();
        }

        private void TxtProfileName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtProfileName.Text == "Profilname...")
            {
                TxtProfileName.Text = "";
                TxtProfileName.Foreground = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            }
        }

        private void TxtProfileName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtProfileName.Text))
            {
                TxtProfileName.Text = "Profilname...";
                TxtProfileName.Foreground = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(0x9E, 0x9E, 0x9E));
            }
        }

        private void BtnAnwenden_Click(object sender, RoutedEventArgs e)
        {
            bool triggerRestart = false;

            // ------------------------------------------------------------------------- Animations
            if (ChkMenuDelay.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableMenuShowDelay(); triggerRestart = true; }
            if (ChkTaskbarAnim.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableTaskbarAnimations(); triggerRestart = true; }
            if (ChkDynamicScrollbars.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableDynamicScrollbars(); triggerRestart = true; }
            if (ChkVisualFX.IsChecked == true) { WindowsDebloater.Core.Animationen.SetVisualFXBestPerformance(); triggerRestart = true; }
            if (ChkUserPrefMask.IsChecked == true) { WindowsDebloater.Core.Animationen.SetUserPreferencesMask(); triggerRestart = true; }
            if (ChkMinAnimate.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableWindowMinAnimate(); triggerRestart = true; }
            if (ChkDragFullWindows.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableDragFullWindows(); triggerRestart = true; }
            if (ChkTransparency.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableTransparency(); triggerRestart = true; }
            if (ChkPreviewWindow.IsChecked == true) { WindowsDebloater.Core.Animationen.DisablePreviewWindow(); triggerRestart = true; }
            if (ChkSearchboxMode.IsChecked == true) { WindowsDebloater.Core.Animationen.SetSearchboxMode(); triggerRestart = true; }
            if (ChkTouchPrediction.IsChecked == true) { WindowsDebloater.Core.Animationen.OptimizeTouchPrediction(); triggerRestart = true; }
            if (ChkModeChangeAnim.IsChecked == true) { WindowsDebloater.Core.Animationen.DisableModeChangeAnimation(); triggerRestart = true; }

            // ------------------------------------------------------------------------- Services
            if (ChkDiagTrack.IsChecked == true) WindowsDebloater.Core.Services.DisableDiagTrack();
            if (ChkWerSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableWerSvc();
            if (ChkLfsvc.IsChecked == true) WindowsDebloater.Core.Services.DisableLfsvc();
            if (ChkPcaSvc.IsChecked == true) WindowsDebloater.Core.Services.DisablePcaSvc();
            if (ChkPimIndex.IsChecked == true) WindowsDebloater.Core.Services.DisablePimIndexMaintenanceSvc();
            if (ChkDps.IsChecked == true) WindowsDebloater.Core.Services.DisableDps();
            if (ChkRetailDemo.IsChecked == true) WindowsDebloater.Core.Services.DisableRetailDemo();
            if (ChkMapsBroker.IsChecked == true) WindowsDebloater.Core.Services.DisableMapsBroker();
            if (ChkWpcMonSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableWpcMonSvc();
            if (ChkSCardSvr.IsChecked == true) WindowsDebloater.Core.Services.DisableSCardSvr();
            if (ChkFax.IsChecked == true) WindowsDebloater.Core.Services.DisableFax();
            if (ChkWisvc.IsChecked == true) WindowsDebloater.Core.Services.DisableWisvc();
            if (ChkPhoneSvc.IsChecked == true) WindowsDebloater.Core.Services.DisablePhoneSvc();
            if (ChkSpooler.IsChecked == true) WindowsDebloater.Core.Services.DisableSpooler();
            if (ChkWbioSrvc.IsChecked == true) WindowsDebloater.Core.Services.DisableWbioSrvc();
            if (ChkTermService.IsChecked == true) WindowsDebloater.Core.Services.DisableTermService();
            if (ChkWwanSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableWwanSvc();
            if (ChkXboxGipSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableXboxGipSvc();
            if (ChkXblAuthManager.IsChecked == true) WindowsDebloater.Core.Services.DisableXblAuthManager();
            if (ChkXblGameSave.IsChecked == true) WindowsDebloater.Core.Services.DisableXblGameSave();
            if (ChkXboxNetApiSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableXboxNetApiSvc();
            if (ChkDosvc.IsChecked == true) WindowsDebloater.Core.Services.DisableDosvc();
            if (ChkRemoteRegistry.IsChecked == true) WindowsDebloater.Core.Services.DisableRemoteRegistry();
            if (ChkCscService.IsChecked == true) WindowsDebloater.Core.Services.DisableCscService();
            if (ChkIphlpsvc.IsChecked == true) WindowsDebloater.Core.Services.DisableIphlpsvc();
            if (ChkTabletInput.IsChecked == true) WindowsDebloater.Core.Services.DisableTabletInputService();
            if (ChkSensorService.IsChecked == true) WindowsDebloater.Core.Services.DisableSensorService();
            if (ChkSysMain.IsChecked == true) WindowsDebloater.Core.Services.DisableSysMain();
            if (ChkFhsvc.IsChecked == true) WindowsDebloater.Core.Services.DisableFhsvc();
            if (ChkStiSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableStiSvc();
            if (ChkLmhosts.IsChecked == true) WindowsDebloater.Core.Services.DisableLmhosts();
            if (ChkTrkWks.IsChecked == true) WindowsDebloater.Core.Services.DisableTrkWks();
            if (ChkCertPropSvc.IsChecked == true) WindowsDebloater.Core.Services.DisableCertPropSvc();
            if (ChkHyperV.IsChecked == true) WindowsDebloater.Core.Services.DisableVmicguestinterface();
            if (ChkWcolorcp.IsChecked == true) WindowsDebloater.Core.Services.DisableWcolorcp();
            if (ChkWebClient.IsChecked == true) WindowsDebloater.Core.Services.DisableWebClient();
            if (ChkP2p.IsChecked == true) { WindowsDebloater.Core.Services.DisableP2pSvc(); WindowsDebloater.Core.Services.DisableP2pImSvc(); }

            // ------------------------------------------------------------------------- Data Protection
            if (ChkTelemetry.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableTelemetry();
            if (ChkActivityHistory.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableActivityHistory();
            if (ChkLocation.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableLocation();
            if (ChkFeedback.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableFeedback();
            if (ChkSearchHistory.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableSearchHistory();
            if (ChkDiagnosticData.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableDiagnosticData();
            if (ChkErrorReporting.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableErrorReporting();
            if (ChkHandwritingData.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableHandwritingData();
            if (ChkAdvertisingId.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableAdvertisingId();
            if (ChkTailoredExperiences.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableTailoredExperiences();
            if (ChkSpeechRecognition.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableSpeechRecognition();
            if (ChkCamera.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableCameraAccess();
            if (ChkMicrophone.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableMicrophoneAccess();
            if (ChkContacts.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableContactsAccess();
            if (ChkCloudClipboard.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableCloudClipboard();

            // ------------------------------------------------------------------------- Ads
            if (ChkAdsAdvertisingId.IsChecked == true) WindowsDebloater.Core.Ads.DisableAdvertisingId();
            if (ChkStartMenuSuggestions.IsChecked == true) WindowsDebloater.Core.Ads.DisableStartMenuSuggestions();
            if (ChkLockScreenAds.IsChecked == true) WindowsDebloater.Core.Ads.DisableLockScreenAds();
            if (ChkAppSuggestions.IsChecked == true) WindowsDebloater.Core.Ads.DisableAppSuggestions();
            if (ChkBingSearch.IsChecked == true) WindowsDebloater.Core.Ads.DisableBingSearch();
            if (ChkExplorerAds.IsChecked == true) WindowsDebloater.Core.Ads.DisableExplorerAds();
            if (ChkSettingsAds.IsChecked == true) { WindowsDebloater.Core.Ads.DisableSettingsAds1(); WindowsDebloater.Core.Ads.DisableSettingsAds2(); WindowsDebloater.Core.Ads.DisableSettingsAds3(); }
            if (ChkTips.IsChecked == true) WindowsDebloater.Core.Ads.DisableTips();
            if (ChkSetupAds.IsChecked == true) WindowsDebloater.Core.Ads.DisableSetupAds();
            if (ChkWelcomePage.IsChecked == true) WindowsDebloater.Core.Ads.DisableWelcomePage();
            if (ChkPopups.IsChecked == true) WindowsDebloater.Core.Ads.DisablePopups();
            if (ChkWidgetAds.IsChecked == true) WindowsDebloater.Core.Ads.DisableWidgetAds();

            if (triggerRestart) WindowsDebloater.Core.Animationen.RestartExplorer();

            // ------------------------------------------------------------------------- App Removal
            if (ChkCopilot.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveCopilot();
            if (ChkCortana.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveCortana();
            if (ChkJournal.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveJournal();
            if (ChkDevHome.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveDevHome();

            if (ChkXboxApp.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveXboxApp();
            if (ChkXboxGameBar.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveXboxGameBar();
            if (ChkXboxConsoleCompanion.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveXboxConsoleCompanion();
            if (ChkXboxTCUI.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveXboxTCUI();
            if (ChkXboxIdentityProvider.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveXboxIdentityProvider();
            if (ChkXboxSpeechToText.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveXboxSpeechToText();
            if (ChkSolitaire.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveSolitaire();

            if (ChkTeamsNew.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveTeamsNew();
            if (ChkTeamsOld.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveTeamsOld();
            if (ChkSkype.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveSkype();
            if (ChkMailCalendar.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveMailCalendar();
            if (ChkPeople.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePeople();
            if (ChkMessaging.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveMessaging();
            if (ChkPhoneLink.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePhoneLink();

            if (ChkStickyNotes.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveStickyNotes();
            if (ChkToDo.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveToDo();
            if (ChkOneNote.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveOneNote();
            if (ChkOfficeHub.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveOfficeHub();
            if (ChkPowerBI.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePowerBI();
            if (ChkPowerAutomate.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePowerAutomate();
            if (ChkSway.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveSway();
            if (ChkPCManager.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePCManager();

            if (ChkBingNews.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingNews();
            if (ChkBingWeather.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingWeather();
            if (ChkBingFinance.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingFinance();
            if (ChkBingSports.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingSports();
            if (ChkBingFoodDrink.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingFoodDrink();
            if (ChkBingHealthFitness.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingHealthFitness();
            if (ChkBingTranslator.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingTranslator();
            if (ChkBingTravel.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingTravel();
            if (ChkBingSearch.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveBingSearch();
            if (ChkMicrosoftNews.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveMicrosoftNews();

            if (Chk3DViewer.IsChecked == true) WindowsDebloater.Core.AppRemoval.Remove3DViewer();
            if (Chk3DBuilder.IsChecked == true) WindowsDebloater.Core.AppRemoval.Remove3DBuilder();
            if (ChkPaint3D.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePaint3D();
            if (ChkMixedReality.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveMixedReality();
            if (ChkPrint3D.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemovePrint3D();

            if (ChkFilmsTV.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveFilmsTV();
            if (ChkGrooveMusic.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveGrooveMusic();
            if (ChkClipchamp.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveClipchamp();

            if (ChkFeedbackHub.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveFeedbackHub();
            if (ChkGetHelp.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveGetHelp();
            if (ChkGetStarted.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveGetStarted();
            if (ChkQuickAssist.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveQuickAssist();
            if (ChkFamilySafety.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveFamilySafety();
            if (ChkNetworkSpeedTest.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveNetworkSpeedTest();
            if (ChkOneConnect.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveOneConnect();
            if (ChkAlarmsClock.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveAlarmsClock();
            if (ChkSoundRecorder.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveSoundRecorder();

            if (ChkWidgets.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveWidgets();
            if (ChkWidgetsPlatform.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveWidgetsPlatform();
            if (ChkWebExperiencePack.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveWebExperiencePack();
            if (ChkCrossDevice.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveCrossDevice();

            if (ChkEdge.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveEdge();
            if (ChkOneDrive.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveOneDrive();
            if (ChkOutlook.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveOutlook();
            if (ChkWhiteboard.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveWhiteboard();
            if (ChkRemoteDesktop.IsChecked == true) WindowsDebloater.Core.AppRemoval.RemoveRemoteDesktop();
            if (Chk365Companions.IsChecked == true) WindowsDebloater.Core.AppRemoval.Remove365Companions();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = TxtProfileName.Text.Trim();
            if (string.IsNullOrEmpty(name) || name == "Profilname...") return;
            var checkboxes = new System.Collections.Generic.Dictionary<string, bool>
        {

        // Animationen
        { "ChkMenuDelay", ChkMenuDelay.IsChecked == true },
        { "ChkTaskbarAnim", ChkTaskbarAnim.IsChecked == true },
        { "ChkDynamicScrollbars", ChkDynamicScrollbars.IsChecked == true },
        { "ChkVisualFX", ChkVisualFX.IsChecked == true },
        { "ChkUserPrefMask", ChkUserPrefMask.IsChecked == true },
        { "ChkMinAnimate", ChkMinAnimate.IsChecked == true },
        { "ChkDragFullWindows", ChkDragFullWindows.IsChecked == true },
        { "ChkTransparency", ChkTransparency.IsChecked == true },
        { "ChkPreviewWindow", ChkPreviewWindow.IsChecked == true },
        { "ChkSearchboxMode", ChkSearchboxMode.IsChecked == true },
        { "ChkTouchPrediction", ChkTouchPrediction.IsChecked == true },
        { "ChkModeChangeAnim", ChkModeChangeAnim.IsChecked == true },

        // Services
        { "ChkDiagTrack", ChkDiagTrack.IsChecked == true },
        { "ChkWerSvc", ChkWerSvc.IsChecked == true },
        { "ChkLfsvc", ChkLfsvc.IsChecked == true },
        { "ChkPcaSvc", ChkPcaSvc.IsChecked == true },
        { "ChkPimIndex", ChkPimIndex.IsChecked == true },
        { "ChkDps", ChkDps.IsChecked == true },
        { "ChkRetailDemo", ChkRetailDemo.IsChecked == true },
        { "ChkMapsBroker", ChkMapsBroker.IsChecked == true },
        { "ChkWpcMonSvc", ChkWpcMonSvc.IsChecked == true },
        { "ChkSCardSvr", ChkSCardSvr.IsChecked == true },
        { "ChkFax", ChkFax.IsChecked == true },
        { "ChkWisvc", ChkWisvc.IsChecked == true },
        { "ChkPhoneSvc", ChkPhoneSvc.IsChecked == true },
        { "ChkSpooler", ChkSpooler.IsChecked == true },
        { "ChkWbioSrvc", ChkWbioSrvc.IsChecked == true },
        { "ChkTermService", ChkTermService.IsChecked == true },
        { "ChkWwanSvc", ChkWwanSvc.IsChecked == true },
        { "ChkXboxGipSvc", ChkXboxGipSvc.IsChecked == true },
        { "ChkXblAuthManager", ChkXblAuthManager.IsChecked == true },
        { "ChkXblGameSave", ChkXblGameSave.IsChecked == true },
        { "ChkXboxNetApiSvc", ChkXboxNetApiSvc.IsChecked == true },
        { "ChkDosvc", ChkDosvc.IsChecked == true },
        { "ChkRemoteRegistry", ChkRemoteRegistry.IsChecked == true },
        { "ChkCscService", ChkCscService.IsChecked == true },
        { "ChkIphlpsvc", ChkIphlpsvc.IsChecked == true },
        { "ChkTabletInput", ChkTabletInput.IsChecked == true },
        { "ChkSensorService", ChkSensorService.IsChecked == true },
        { "ChkSysMain", ChkSysMain.IsChecked == true },
        { "ChkFhsvc", ChkFhsvc.IsChecked == true },
        { "ChkStiSvc", ChkStiSvc.IsChecked == true },
        { "ChkLmhosts", ChkLmhosts.IsChecked == true },
        { "ChkTrkWks", ChkTrkWks.IsChecked == true },
        { "ChkCertPropSvc", ChkCertPropSvc.IsChecked == true },
        { "ChkHyperV", ChkHyperV.IsChecked == true },
        { "ChkWcolorcp", ChkWcolorcp.IsChecked == true },
        { "ChkWebClient", ChkWebClient.IsChecked == true },
        { "ChkP2p", ChkP2p.IsChecked == true },

        // DataProtection
        { "ChkTelemetry", ChkTelemetry.IsChecked == true },
        { "ChkActivityHistory", ChkActivityHistory.IsChecked == true },
        { "ChkLocation", ChkLocation.IsChecked == true },
        { "ChkFeedback", ChkFeedback.IsChecked == true },
        { "ChkSearchHistory", ChkSearchHistory.IsChecked == true },
        { "ChkDiagnosticData", ChkDiagnosticData.IsChecked == true },
        { "ChkErrorReporting", ChkErrorReporting.IsChecked == true },
        { "ChkHandwritingData", ChkHandwritingData.IsChecked == true },
        { "ChkAdvertisingId", ChkAdvertisingId.IsChecked == true },
        { "ChkTailoredExperiences", ChkTailoredExperiences.IsChecked == true },
        { "ChkSpeechRecognition", ChkSpeechRecognition.IsChecked == true },
        { "ChkCamera", ChkCamera.IsChecked == true },
        { "ChkMicrophone", ChkMicrophone.IsChecked == true },
        { "ChkContacts", ChkContacts.IsChecked == true },
        { "ChkCloudClipboard", ChkCloudClipboard.IsChecked == true },

        // Ads
        { "ChkAdsAdvertisingId", ChkAdsAdvertisingId.IsChecked == true },
        { "ChkStartMenuSuggestions", ChkStartMenuSuggestions.IsChecked == true },
        { "ChkLockScreenAds", ChkLockScreenAds.IsChecked == true },
        { "ChkAppSuggestions", ChkAppSuggestions.IsChecked == true },
        { "ChkBingSearch", ChkBingSearch.IsChecked == true },
        { "ChkExplorerAds", ChkExplorerAds.IsChecked == true },
        { "ChkSettingsAds", ChkSettingsAds.IsChecked == true },
        { "ChkTips", ChkTips.IsChecked == true },
        { "ChkSetupAds", ChkSetupAds.IsChecked == true },
        { "ChkWelcomePage", ChkWelcomePage.IsChecked == true },
        { "ChkPopups", ChkPopups.IsChecked == true },
        { "ChkWidgetAds", ChkWidgetAds.IsChecked == true },

        // App Removal
        { "ChkCopilot", ChkCopilot.IsChecked == true },
        { "ChkCortana", ChkCortana.IsChecked == true },
        { "ChkJournal", ChkJournal.IsChecked == true },
        { "ChkDevHome", ChkDevHome.IsChecked == true },
        { "ChkXboxApp", ChkXboxApp.IsChecked != false },
        { "ChkXboxGameBar", ChkXboxGameBar.IsChecked != false },
        { "ChkXboxConsoleCompanion", ChkXboxConsoleCompanion.IsChecked != false },
        { "ChkXboxTCUI", ChkXboxTCUI.IsChecked != false },
        { "ChkXboxIdentityProvider", ChkXboxIdentityProvider.IsChecked != false },
        { "ChkXboxSpeechToText", ChkXboxSpeechToText.IsChecked != false },
        { "ChkSolitaire", ChkSolitaire.IsChecked == true },
        { "ChkTeamsNew", ChkTeamsNew.IsChecked == true },
        { "ChkTeamsOld", ChkTeamsOld.IsChecked == true },
        { "ChkSkype", ChkSkype.IsChecked == true },
        { "ChkMailCalendar", ChkMailCalendar.IsChecked == true },
        { "ChkPeople", ChkPeople.IsChecked == true },
        { "ChkMessaging", ChkMessaging.IsChecked == true },
        { "ChkPhoneLink", ChkPhoneLink.IsChecked == true },
        { "ChkStickyNotes", ChkStickyNotes.IsChecked == true },
        { "ChkToDo", ChkToDo.IsChecked == true },
        { "ChkOneNote", ChkOneNote.IsChecked == true },
        { "ChkOfficeHub", ChkOfficeHub.IsChecked == true },
        { "ChkPowerBI", ChkPowerBI.IsChecked == true },
        { "ChkPowerAutomate", ChkPowerAutomate.IsChecked == true },
        { "ChkSway", ChkSway.IsChecked == true },
        { "ChkPCManager", ChkPCManager.IsChecked == true },
        { "ChkBingNews", ChkBingNews.IsChecked == true },
        { "ChkBingWeather", ChkBingWeather.IsChecked == true },
        { "ChkBingFinance", ChkBingFinance.IsChecked == true },
        { "ChkBingSports", ChkBingSports.IsChecked == true },
        { "ChkBingFoodDrink", ChkBingFoodDrink.IsChecked == true },
        { "ChkBingHealthFitness", ChkBingHealthFitness.IsChecked == true },
        { "ChkBingTranslator", ChkBingTranslator.IsChecked == true },
        { "ChkBingTravel", ChkBingTravel.IsChecked == true },
        { "ChkMicrosoftNews", ChkMicrosoftNews.IsChecked == true },
        { "Chk3DViewer", Chk3DViewer.IsChecked == true },
        { "Chk3DBuilder", Chk3DBuilder.IsChecked == true },
        { "ChkPaint3D", ChkPaint3D.IsChecked == true },
        { "ChkMixedReality", ChkMixedReality.IsChecked == true },
        { "ChkPrint3D", ChkPrint3D.IsChecked == true },
        { "ChkFilmsTV", ChkFilmsTV.IsChecked == true },
        { "ChkGrooveMusic", ChkGrooveMusic.IsChecked == true },
        { "ChkClipchamp", ChkClipchamp.IsChecked == true },
        { "ChkFeedbackHub", ChkFeedbackHub.IsChecked == true },
        { "ChkGetHelp", ChkGetHelp.IsChecked == true },
        { "ChkGetStarted", ChkGetStarted.IsChecked == true },
        { "ChkQuickAssist", ChkQuickAssist.IsChecked == true },
        { "ChkFamilySafety", ChkFamilySafety.IsChecked == true },
        { "ChkNetworkSpeedTest", ChkNetworkSpeedTest.IsChecked == true },
        { "ChkOneConnect", ChkOneConnect.IsChecked == true },
        { "ChkAlarmsClock", ChkAlarmsClock.IsChecked == true },
        { "ChkSoundRecorder", ChkSoundRecorder.IsChecked == true },
        { "ChkWidgets", ChkWidgets.IsChecked == true },
        { "ChkWidgetsPlatform", ChkWidgetsPlatform.IsChecked == true },
        { "ChkWebExperiencePack", ChkWebExperiencePack.IsChecked == true },
        { "ChkCrossDevice", ChkCrossDevice.IsChecked == true },
        { "ChkEdge", ChkEdge.IsChecked == true },
        { "ChkOneDrive", ChkOneDrive.IsChecked == true },
        { "ChkOutlook", ChkOutlook.IsChecked == true },
        { "ChkWhiteboard", ChkWhiteboard.IsChecked == true },
        { "ChkRemoteDesktop", ChkRemoteDesktop.IsChecked == true },
        { "Chk365Companions", Chk365Companions.IsChecked == true }
    };
            string json = System.Text.Json.JsonSerializer.Serialize(
                new { name, checkboxes },
                new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            string folder = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                "WindowsDebloater", "profiles");

            System.IO.Directory.CreateDirectory(folder);
            System.IO.File.WriteAllText(System.IO.Path.Combine(folder, $"{name}.json"), json);

            BtnBack_Click(sender, e);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as WindowsDebloater.GUI.MainWindow;
            if (mainWindow == null) return;
            mainWindow.TabContent.Content = new WindowsDebloater.GUI.Tabs.Profiles();
        }
    }
}
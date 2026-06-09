using System.Windows;

namespace WindowsDebloater
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!WindowsDebloater.Core.AskAdminPermissions.IsAdmin())
                WindowsDebloater.Core.AskAdminPermissions.RestartAsAdmin();
        }

        private void BtnAnwenden_Click(object sender, RoutedEventArgs e)
        {
            bool triggerRestart = false;

            // ------------------------------------------------------------------------- Animationen
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

            // ------------------------------------------------------------------------- Datenschutz
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

            // ------------------------------------------------------------------------- Werbung
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

            // ------------------------------------------------------------------------- Dienste
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


            if (ChkStartupApps.IsChecked == true) WindowsDebloater.Core.AutomaticStartupApps.DisableStartupApps();

            // ------------------------------------------------------------------------- Explorer Neustart
            if (triggerRestart) WindowsDebloater.Core.Animationen.RestartExplorer();
        }

        private void ChkVisualFX_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
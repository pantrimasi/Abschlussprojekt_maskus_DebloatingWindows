using System.Windows;
using System.Windows.Controls;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class DataProtection : UserControl
    {
        public DataProtection() => InitializeComponent();

        private void BtnAnwenden_Click(object sender, RoutedEventArgs e)
        {
            bool triggerRestart = false;

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
            if (ChkPersonalizedOffers.IsChecked == true) WindowsDebloater.Core.DataProtection.DisablePersonalizedOffers();
            if (ChkPersonalizedTips.IsChecked == true) WindowsDebloater.Core.DataProtection.DisablePersonalizedTips();
            if (ChkLanguageList.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableLanguageListAccess();
            if (ChkAppLaunchTracking.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableAppLaunchTracking();
            if (ChkSettingsNotifications.IsChecked == true) WindowsDebloater.Core.DataProtection.DisableSettingsNotifications();

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
        }

        private void ChkMenuDelay_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
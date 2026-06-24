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
    public partial class Apps : UserControl
    {
        public Apps() => InitializeComponent();

        private void BtnAnwenden_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
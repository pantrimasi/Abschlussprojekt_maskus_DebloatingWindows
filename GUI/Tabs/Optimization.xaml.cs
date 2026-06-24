/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Reads checkbox states and calls the corresponding Core methods when applied.
 */
using System.Windows;
using System.Windows.Controls;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class Optimization : UserControl
    {
        public Optimization() => InitializeComponent();
        
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

            if (triggerRestart) WindowsDebloater.Core.Animationen.RestartExplorer();
        }

        private void ChkMenuDelay_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
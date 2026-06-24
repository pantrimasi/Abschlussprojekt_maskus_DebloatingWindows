/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Core application logic for a Windows optimization tool that removes unnecessary system components and improves performance.
 */
namespace WindowsDebloater.Core
{
    public static class ProfileManager
    {
        // ------------------------------------------------------------------------- Work Profile
        public static void ApplyWork()
        {
            DataProtection.DisableAll();
            Ads.DisableAll();

            Animationen.DisableMenuShowDelay();
            Animationen.DisableTaskbarAnimations();
            Animationen.SetVisualFXBestPerformance();

            Services.DisableAllTelemetry();
            Services.DisableAllUnnecessary();
            Services.DisableMapsBroker();

            AppRemoval.RemoveAllAI();
            AppRemoval.RemoveAllBing();
            AppRemoval.RemoveAll3D();
            AppRemoval.RemoveAllEntertainment();
            AppRemoval.RemoveSolitaire();

            Animationen.RestartExplorer();
        }

        // ------------------------------------------------------------------------- Gaming Profile
        public static void ApplyGaming()
        {
            DataProtection.DisableAll();
            Ads.DisableAll();

            Animationen.DisableMenuShowDelay();
            Animationen.DisableTaskbarAnimations();
            Animationen.DisableDynamicScrollbars();
            Animationen.SetVisualFXBestPerformance();
            Animationen.SetUserPreferencesMask();
            Animationen.DisableWindowMinAnimate();
            Animationen.DisableDragFullWindows();
            Animationen.DisableTransparency();
            Animationen.DisablePreviewWindow();
            Animationen.SetSearchboxMode();
            Animationen.OptimizeTouchPrediction();
            Animationen.DisableModeChangeAnimation();

            Services.DisableAllTelemetry();
            Services.DisableAllUnnecessary();
            Services.DisableAllOftenUnused();
            Services.DisableAllNetwork();
            Services.DisableAllHardware();
            Services.DisableAllSystem();
            Services.DisableAllOld();

            AppRemoval.RemoveAllAI();
            AppRemoval.RemoveAllCommunication();
            AppRemoval.RemoveAllOffice();
            AppRemoval.RemoveAllBing();
            AppRemoval.RemoveAll3D();
            AppRemoval.RemoveAllEntertainment();
            AppRemoval.RemoveAllSystem();
            AppRemoval.RemoveAllWidgets();
            // Defekt: AppRemoval.RemoveAllSpecial();

            Animationen.RestartExplorer();
        }

        // ------------------------------------------------------------------------- Minimum Profile
        public static void ApplyMinimum()
        {
            DataProtection.DisableAll();
            Ads.DisableAll();

            Animationen.DisableMenuShowDelay();
            Animationen.DisableTaskbarAnimations();
            Animationen.DisableDynamicScrollbars();
            Animationen.SetVisualFXBestPerformance();
            Animationen.SetUserPreferencesMask();
            Animationen.DisableWindowMinAnimate();
            Animationen.DisableDragFullWindows();
            Animationen.DisableTransparency();
            Animationen.DisablePreviewWindow();
            Animationen.SetSearchboxMode();
            Animationen.OptimizeTouchPrediction();
            Animationen.DisableModeChangeAnimation();

            Services.DisableAllTelemetry();
            Services.DisableAllUnnecessary();
            Services.DisableAllOftenUnused();
            Services.DisableAllGaming();
            Services.DisableAllNetwork();
            Services.DisableAllHardware();
            Services.DisableAllSystem();
            Services.DisableAllOld();

            AppRemoval.RemoveAllAI();
            AppRemoval.RemoveAllGaming();
            AppRemoval.RemoveAllCommunication();
            AppRemoval.RemoveAllOffice();
            AppRemoval.RemoveAllBing();
            AppRemoval.RemoveAll3D();
            AppRemoval.RemoveAllEntertainment();
            AppRemoval.RemoveAllSystem();
            AppRemoval.RemoveAllWidgets();
            // Defekt: AppRemoval.RemoveAllSpecial();

            Animationen.RestartExplorer();
        }

        // ------------------------------------------------------------------------- Developer Profile
        public static void ApplyDeveloper()
        {
            DataProtection.DisableAll();
            Ads.DisableAll();

            Services.DisableAllTelemetry();
            Services.DisableAllUnnecessary();

            AppRemoval.RemoveAllAI();
            AppRemoval.RemoveAllBing();
            AppRemoval.RemoveAll3D();
            AppRemoval.RemoveAllEntertainment();
            AppRemoval.RemoveSolitaire();

            Developer.EnableAll();
        }

        // ------------------------------------------------------------------------- Privacy Profile
        public static void ApplyPrivacy()
        {
            DataProtection.DisableAll();
            Ads.DisableAll();
            Animationen.RestartExplorer();
        }
    }
}
using System.Windows;

namespace WindowsDebloater.Core
{
    public static class Animationen
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

        // ------------------------------------------------------------------------- Basic Animations
        // Menu delay
        public static void DisableMenuShowDelay() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\Desktop\" /v MenuShowDelay /t REG_SZ /d \"0\" /f");

        // Taskbar-Animation
        public static void DisableTaskbarAnimations() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v TaskbarAnimations /t REG_DWORD /d 0 /f");

        // ------------------------------------------------------------------------- All other Animations
        // Global master switch
        public static void DisableDynamicScrollbars() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\Accessibility\" /v DynamicScrollbars /t REG_DWORD /d 0 /f");

        // Performance mode
        public static void SetVisualFXBestPerformance() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects\" /v VisualFXSetting /t REG_DWORD /d 2 /f");

        // Global Performance Filter
        public static void SetUserPreferencesMask() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\Desktop\" /v UserPreferencesMask /t REG_BINARY /d 9012028010000000 /f");

        // Window animations
        public static void DisableWindowMinAnimate() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\Desktop\\WindowMetrics\" /v MinAnimate /t REG_SZ /d \"0\" /f");

        // Window content
        public static void DisableDragFullWindows() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\Desktop\" /v DragFullWindows /t REG_SZ /d \"0\" /f");

        // Transparency
        public static void DisableTransparency() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 0 /f");

        // Aero-Peek
        public static void DisablePreviewWindow() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v DisablePreviewWindow /t REG_DWORD /d 1 /f");

        // Start menu animation
        public static void SetSearchboxMode() => RunRegistryCommand("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Search\" /v SearchboxInTaskbarMode /t REG_DWORD /d 1 /f");

        // Touch-Feedback
        public static void OptimizeTouchPrediction() => RunRegistryCommand("reg add \"HKCU\\Control Panel\\Desktop\" /v TouchPredictionLatency /t REG_DWORD /d 0 /f");

        // Screen switching
        public static void DisableModeChangeAnimation() => RunRegistryCommand("reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\Dwm\" /v ForceDisableModeChangeAnimation /t REG_DWORD /d 1 /f");

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
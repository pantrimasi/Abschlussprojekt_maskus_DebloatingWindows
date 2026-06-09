using Microsoft.Win32;

namespace WindowsDebloater.Core
{
    public static class AutomaticStartupApps
    {
        // whitelist
        private static readonly string[] allowedApps =
        {
            "SecurityHealthSystray"
        };

        // check whitelist
        private static bool IsAllowed(string name)
        {
            foreach (string allowed in allowedApps)
                if (name.Equals(allowed, System.StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        // disable startup entry
        private static void DisableKey(RegistryKey key)
        {
            if (key == null) return;
            foreach (string name in key.GetValueNames())
                if (!IsAllowed(name))
                    key.DeleteValue(name, false);
        }

        // run all
        public static void DisableStartupApps()
        {
            DisableKey(Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true));
            DisableKey(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true));
            DisableKey(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run", true));
        }
    }
}
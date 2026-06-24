/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Checks for admin rights and restarts the application with elevated privileges if needed.
 */
using System.Security.Principal;
using System.Windows;

namespace WindowsDebloater.Core
{
    public static class AskAdminPermissions
    {
        // admin check
        public static bool IsAdmin() =>
            new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        // restart
        public static void RestartAsAdmin()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName,
                UseShellExecute = true,
                Verb = "runas"
            });
            Application.Current.Shutdown();
        }
    }
}
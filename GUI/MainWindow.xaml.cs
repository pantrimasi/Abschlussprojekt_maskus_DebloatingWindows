using System.Windows;
using System.Windows.Controls;
using WindowsDebloater.GUI.Tabs;

namespace WindowsDebloater
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!WindowsDebloater.Core.AskAdminPermissions.IsAdmin())
                WindowsDebloater.Core.AskAdminPermissions.RestartAsAdmin();

            // live Stats
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = System.TimeSpan.FromSeconds(3);
            timer.Tick += (s, e) =>
            {
                TxtRam.Text = $"{WindowsDebloater.Core.LiveUtilization.GetRamUsage()} Ram Verbrauch";
                TxtProcesses.Text = $"{WindowsDebloater.Core.LiveUtilization.GetProcesses().Length} Prozesse Aktiv";
            };
            timer.Start();

            // default tab
            TabContent.Content = new WindowsDebloater.GUI.Tabs.Optimization();
        }

        // nav tabs
        private void SetActiveNav(TextBlock active)
        {
            NavOptimization.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xB0, 0xBE, 0xC5));
            NavDataProtection.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xB0, 0xBE, 0xC5));
            NavApps.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xB0, 0xBE, 0xC5));
            NavWindowsKey.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xB0, 0xBE, 0xC5));
            NavProfiles.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xB0, 0xBE, 0xC5));
            NavBenchmark.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xB0, 0xBE, 0xC5));
            active.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xBB, 0x86, 0xFC));
        }

        private void NavOptimization_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new WindowsDebloater.GUI.Tabs.Optimization();
            SetActiveNav(NavOptimization);
        }

        private void NavDataProtection_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new WindowsDebloater.GUI.Tabs.DataProtection();
            SetActiveNav(NavDataProtection);
        }

        private void NavApps_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new WindowsDebloater.GUI.Tabs.Apps();
            SetActiveNav(NavApps);
        }

        private void NavWindowsKey_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new WindowsDebloater.GUI.Tabs.WindowsKey();
            SetActiveNav(NavWindowsKey);
        }

        private void NavProfiles_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new WindowsDebloater.GUI.Tabs.Profiles();
            SetActiveNav(NavProfiles);
        }

        private void NavBenchmark_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new WindowsDebloater.GUI.Tabs.Benchmark();
            SetActiveNav(NavBenchmark);
        }

        private void ChkVisualFX_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
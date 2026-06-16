using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WindowsDebloater.GUI.Tabs;

namespace WindowsDebloater.GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!WindowsDebloater.Core.AskAdminPermissions.IsAdmin())
                WindowsDebloater.Core.AskAdminPermissions.RestartAsAdmin();

            // async initial load
            Loaded += async (s, e) =>
            {
                var ram = await System.Threading.Tasks.Task.Run(() => WindowsDebloater.Core.LiveUtilization.GetRamUsage());
                var processes = await System.Threading.Tasks.Task.Run(() => WindowsDebloater.Core.LiveUtilization.GetProcesses().Length);
                var cpu = await System.Threading.Tasks.Task.Run(() => WindowsDebloater.Core.LiveUtilization.GetCpuUsage());

                TxtRam.Text = $"{ram} Ram Verbrauch";
                TxtProcesses.Text = $"{processes} Prozesse Aktiv";
                TxtCpu.Text = $"{cpu}% CPU Verbrauch";
            };

            // live stats
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = System.TimeSpan.FromSeconds(5);
            timer.Tick += async (s, e) =>
            {
                var ram = await System.Threading.Tasks.Task.Run(() => WindowsDebloater.Core.LiveUtilization.GetRamUsage());
                var processes = await System.Threading.Tasks.Task.Run(() => WindowsDebloater.Core.LiveUtilization.GetProcesses().Length);
                var cpu = await System.Threading.Tasks.Task.Run(() => WindowsDebloater.Core.LiveUtilization.GetCpuUsage());

                TxtRam.Text = $"{ram} Ram Verbrauch";
                TxtProcesses.Text = $"{processes} Prozesse Aktiv";
                TxtCpu.Text = $"{cpu}% CPU Verbrauch";
            };
            timer.Start();

            // default tab
            TabContent.Content = new Optimization();
        }


        // window controls
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
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
            TabContent.Content = new Optimization();
            SetActiveNav(NavOptimization);
        }

        private void NavDataProtection_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new DataProtection();
            SetActiveNav(NavDataProtection);
        }

        private void NavApps_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new Apps();
            SetActiveNav(NavApps);
        }

        private void NavWindowsKey_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new Tabs.WindowsKey();
            SetActiveNav(NavWindowsKey);
        }

        private void NavProfiles_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new Profiles();
            SetActiveNav(NavProfiles);
        }

        private void NavBenchmark_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabContent.Content = new Benchmark();
            SetActiveNav(NavBenchmark);
        }

        private void ChkVisualFX_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
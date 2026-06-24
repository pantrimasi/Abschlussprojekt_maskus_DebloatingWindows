using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WindowsDebloater.GUI.Tabs;

namespace WindowsDebloater.GUI
{


    public partial class MainWindow : Window
    {

        private async void BtnApplyAll_Click(object sender, RoutedEventArgs e)
        {
            BtnApplyAll.IsEnabled = false;

            // read states on UI thread
            bool menuDelay = _tabOptimization.ChkMenuDelay.IsChecked == true;
            bool telemetry = _tabDataProtection.ChkTelemetry.IsChecked == true;
            bool copilot = _tabApps.ChkCopilot.IsChecked == true;
            // alle anderen gleich darunter

            await Task.Run(() => WindowsDebloater.Core.Backup.CreateRestorePoint());

            await Task.Run(() =>
            {
                if (menuDelay) WindowsDebloater.Core.Animationen.DisableMenuShowDelay();
                if (telemetry) WindowsDebloater.Core.DataProtection.DisableTelemetry();
                if (copilot) WindowsDebloater.Core.AppRemoval.RemoveCopilot();
                // alle anderen gleich darunter

                WindowsDebloater.Core.Animationen.RestartExplorer();
            });

            BtnApplyAll.IsEnabled = true;
        }


        // tab instances
        private WindowsDebloater.GUI.Tabs.Optimization _tabOptimization;
        private WindowsDebloater.GUI.Tabs.DataProtection _tabDataProtection;
        private WindowsDebloater.GUI.Tabs.Apps _tabApps;
        private WindowsDebloater.GUI.Tabs.WindowsKey _tabWindowsKey;
        private WindowsDebloater.GUI.Tabs.Profiles _tabProfiles;
        private WindowsDebloater.GUI.Tabs.RemoteDeploy _tabRemoteDeploy;

        public MainWindow()
        {
            InitializeComponent();

            if (!WindowsDebloater.Core.AskAdminPermissions.IsAdmin())
                WindowsDebloater.Core.AskAdminPermissions.RestartAsAdmin();

            // init tabs once
            _tabOptimization = new WindowsDebloater.GUI.Tabs.Optimization();
            _tabDataProtection = new WindowsDebloater.GUI.Tabs.DataProtection();
            _tabApps = new WindowsDebloater.GUI.Tabs.Apps();
            _tabWindowsKey = new WindowsDebloater.GUI.Tabs.WindowsKey();
            _tabProfiles = new WindowsDebloater.GUI.Tabs.Profiles();
            _tabRemoteDeploy = new WindowsDebloater.GUI.Tabs.RemoteDeploy();

            // default tab
            TabContent.Content = _tabOptimization;

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

private bool _isMaximized = false;
private double _prevLeft, _prevTop, _prevWidth, _prevHeight;

private void Maximize_Click(object sender, RoutedEventArgs e)
{
    if (_isMaximized)
    {
        Left = _prevLeft;
        Top = _prevTop;
        Width = _prevWidth;
        Height = _prevHeight;
        _isMaximized = false;
    }
    else
    {
        _prevLeft = Left;
        _prevTop = Top;
        _prevWidth = Width;
        _prevHeight = Height;

        var workArea = SystemParameters.WorkArea;
        Left = workArea.Left;
        Top = workArea.Top;
        Width = workArea.Width;
        Height = workArea.Height;
        _isMaximized = true;
    }
}


        // nav tabs
        private void SetActiveNav(TextBlock active)
        {
            NavOptimization.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            NavDataProtection.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            NavApps.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            NavWindowsKey.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            NavProfiles.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            NavRemoteDeploy.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFA, 0xFA));
            active.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xBB, 0x86, 0xFC));
        }

        private void NavOptimization_Click(object sender, MouseButtonEventArgs e)
        {
            TabContent.Content = _tabOptimization;
            SetActiveNav(NavOptimization);
        }

        private void NavDataProtection_Click(object sender, MouseButtonEventArgs e)
        {
            TabContent.Content = _tabDataProtection;
            SetActiveNav(NavDataProtection);
        }

        private void NavApps_Click(object sender, MouseButtonEventArgs e)
        {
            TabContent.Content = _tabApps;
            SetActiveNav(NavApps);
        }

        private void NavWindowsKey_Click(object sender, MouseButtonEventArgs e)
        {
            TabContent.Content = _tabWindowsKey;
            SetActiveNav(NavWindowsKey);
        }

        private void NavProfiles_Click(object sender, MouseButtonEventArgs e)
        {
            TabContent.Content = _tabProfiles;
            SetActiveNav(NavProfiles);
        }

        private void NavRemoteDeploy_Click(object sender, MouseButtonEventArgs e)
        {
            TabContent.Content = _tabRemoteDeploy;
            SetActiveNav(NavRemoteDeploy);
        }

        private void ChkVisualFX_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void BtnBackups_Click(object sender, RoutedEventArgs e)
        {
            CmbBackups.Items.Clear();
            var backups = WindowsDebloater.Core.Backup.LoadBackups();

            if (backups.Count == 0)
            {
                CmbBackups.Items.Add(new ComboBoxItem { Content = "Keine Backups gefunden" });
                BackupOverlay.Visibility = Visibility.Visible;
                return;
            }

            foreach (var backup in backups)
                CmbBackups.Items.Add(new ComboBoxItem { Content = backup.Name, Tag = backup.Id });

            CmbBackups.SelectedIndex = 0;
            BackupOverlay.Visibility = Visibility.Visible;
        }

        private async void BtnConfirmRestore_Click(object sender, RoutedEventArgs e)
        {
            if (CmbBackups.SelectedItem is not ComboBoxItem item || item.Tag == null) return;
            int id = (int)item.Tag;
            BackupOverlay.Visibility = Visibility.Collapsed;
            await Task.Run(() => WindowsDebloater.Core.Backup.RestoreBackup(id));
        }

        private void BtnCancelBackup_Click(object sender, RoutedEventArgs e)
        {
            BackupOverlay.Visibility = Visibility.Collapsed;
        }
        s
    }
}
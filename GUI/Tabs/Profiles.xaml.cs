using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class Profiles : UserControl
    {
        private Action _pendingProfile;

        public Profiles()
        {
            InitializeComponent();
            LoadSavedProfiles();
        }

        private void ShowConfirm(Action profileAction)
        {
            _pendingProfile = profileAction;
            ConfirmOverlay.Visibility = Visibility.Visible;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ConfirmOverlay.Visibility = Visibility.Collapsed;
            _pendingProfile = null;
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            ConfirmOverlay.Visibility = Visibility.Collapsed;
            await Task.Run(() => WindowsDebloater.Core.Backup.CreateRestorePoint());
            await Task.Run(_pendingProfile);
            _pendingProfile = null;
        }

        private void BtnWork_Click(object sender, RoutedEventArgs e) =>
            ShowConfirm(WindowsDebloater.Core.ProfileManager.ApplyWork);

        private void BtnGaming_Click(object sender, RoutedEventArgs e) =>
            ShowConfirm(WindowsDebloater.Core.ProfileManager.ApplyGaming);

        private void BtnMinimum_Click(object sender, RoutedEventArgs e) =>
            ShowConfirm(WindowsDebloater.Core.ProfileManager.ApplyMinimum);

        private void BtnDeveloper_Click(object sender, RoutedEventArgs e) =>
            ShowConfirm(WindowsDebloater.Core.ProfileManager.ApplyDeveloper);

        private void BtnPrivacy_Click(object sender, RoutedEventArgs e) =>
            ShowConfirm(WindowsDebloater.Core.ProfileManager.ApplyPrivacy);

        private void BtnCreateProfile_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (WindowsDebloater.GUI.MainWindow)Window.GetWindow(this);
            mainWindow.TabContent.Content = new WindowsDebloater.GUI.Tabs.CreateProfile();
        }

        private void LoadSavedProfiles()
        {
            string folder = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                "WindowsDebloater", "profiles");

            if (!System.IO.Directory.Exists(folder)) return;

            foreach (string file in System.IO.Directory.GetFiles(folder, "*.json"))
            {
                string json = System.IO.File.ReadAllText(file);
                var data = System.Text.Json.JsonDocument.Parse(json);
                string name = data.RootElement.GetProperty("name").GetString() ?? "Unbekannt";

                var card = new System.Windows.Controls.Border
                {
                    Background = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(0x24, 0x24, 0x24)),
                    CornerRadius = new CornerRadius(8),
                    Padding = new Thickness(20),
                    Margin = new Thickness(0, 0, 0, 10)
                };

                var stack = new System.Windows.Controls.StackPanel();
                stack.Children.Add(new System.Windows.Controls.TextBlock
                {
                    Text = name,
                    Foreground = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(0xBB, 0x86, 0xFC)),
                    FontSize = 20,
                    Margin = new Thickness(0, 0, 0, 10)
                });

                // buttons
                var btnStack = new System.Windows.Controls.StackPanel { Orientation = System.Windows.Controls.Orientation.Horizontal };

                var btnApply = new System.Windows.Controls.Button
                {
                    Content = "Anwenden",
                    Height = 35,
                    Width = 120,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Margin = new Thickness(0, 10, 10, 0),
                    Tag = file
                };
                btnApply.Click += (s, e) => ShowConfirm(() => ApplySavedProfile(file));

                var btnDelete = new System.Windows.Controls.Button
                {
                    Content = "Löschen",
                    Height = 35,
                    Width = 120,
                    Margin = new Thickness(0, 10, 0, 0),
                    Tag = file,
                    Foreground = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF)),
                    Background = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(0xD3, 0x2F, 0x2F)),
                    BorderBrush = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(0xD3, 0x2F, 0x2F))
                };
                btnDelete.Click += (s, e) =>
                {
                    System.IO.File.Delete(file);
                    ProfileCards.Children.Remove(card);
                };

                btnStack.Children.Add(btnApply);
                btnStack.Children.Add(btnDelete);
                stack.Children.Add(btnStack);
                card.Child = stack;
                ProfileCards.Children.Add(card);
            }
        }

        private void ApplySavedProfile(string file)
        {
            string json = System.IO.File.ReadAllText(file);
            var data = System.Text.Json.JsonDocument.Parse(json);
            var checkboxes = data.RootElement.GetProperty("checkboxes");

            // helper
            bool Get(string key) => checkboxes.TryGetProperty(key, out var val) && val.GetBoolean();

            if (Get("ChkMenuDelay")) WindowsDebloater.Core.Animationen.DisableMenuShowDelay();
            if (Get("ChkTaskbarAnim")) WindowsDebloater.Core.Animationen.DisableTaskbarAnimations();
            // alle anderen Checkboxen gleich darunter einfügen

            WindowsDebloater.Core.Animationen.RestartExplorer();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "JSON Profile|*.json",
                Title = "Profil importieren"
            };
            if (dialog.ShowDialog() != true) return;

            string folder = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                "WindowsDebloater", "profiles");

            System.IO.Directory.CreateDirectory(folder);
            string dest = System.IO.Path.Combine(folder, System.IO.Path.GetFileName(dialog.FileName));
            System.IO.File.Copy(dialog.FileName, dest, true);

            // reload
            ProfileCards.Children.Clear();
            LoadSavedProfiles();
        }

        private string _exportFolder => System.IO.Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
            "WindowsDebloater", "profiles");

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            CmbExportProfile.Items.Clear();
            foreach (string file in System.IO.Directory.GetFiles(_exportFolder, "*.json"))
                CmbExportProfile.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file));

            ExportOverlay.Visibility = Visibility.Visible;
        }


        private void BtnCancelExport_Click(object sender, RoutedEventArgs e)
        {
            ExportOverlay.Visibility = Visibility.Collapsed;
        }

        private void BtnConfirmExport_Click(object sender, RoutedEventArgs e)
        {
            if (CmbExportProfile.SelectedItem == null) return;

            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JSON Profile|*.json",
                Title = "Profil exportieren",
                FileName = CmbExportProfile.SelectedItem.ToString()
            };
            if (dialog.ShowDialog() != true) return;

            string src = System.IO.Path.Combine(_exportFolder, $"{CmbExportProfile.SelectedItem}.json");
            System.IO.File.Copy(src, dialog.FileName, true);
            ExportOverlay.Visibility = Visibility.Collapsed;
        }
    }
}
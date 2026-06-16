using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class Profiles : UserControl
    {
        private Action _pendingProfile;

        public Profiles() => InitializeComponent();

        // show overlay
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
    }
}
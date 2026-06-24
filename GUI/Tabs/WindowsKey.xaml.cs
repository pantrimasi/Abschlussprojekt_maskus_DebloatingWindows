using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class WindowsKey : UserControl
    {
        public WindowsKey() => InitializeComponent();

        private void BtnCheckStatus_Click(object sender, RoutedEventArgs e)
        {
            TxtStatus.Text = WindowsDebloater.Core.WindowsActivation.GetActivationStatus();
        }

        private async void BtnActivate_Click(object sender, RoutedEventArgs e)
        {
            string edition = (CmbEdition.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            TxtStatus.Text = "Backup wird erstellt...";
            BtnActivate.IsEnabled = false;

            await Task.Run(() => WindowsDebloater.Core.Backup.CreateRestorePoint());

            TxtStatus.Text = "Aktivierung läuft...";
            await Task.Run(() => {
                if (edition == "Windows 11 Pro") WindowsDebloater.Core.WindowsActivation.ActivatePro();
                if (edition == "Windows 11 Home") WindowsDebloater.Core.WindowsActivation.ActivateHome();
                if (edition == "Windows 11 Enterprise") WindowsDebloater.Core.WindowsActivation.ActivateEnterprise();
            });

            TxtStatus.Text = WindowsDebloater.Core.WindowsActivation.GetActivationStatus();
            BtnActivate.IsEnabled = true;
        }
    }
}
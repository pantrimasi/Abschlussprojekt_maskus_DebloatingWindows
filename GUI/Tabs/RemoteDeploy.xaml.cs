using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Renci.SshNet;

namespace WindowsDebloater.GUI.Tabs
{
    public partial class RemoteDeploy : UserControl
    {
        private SshClient _client;

        public RemoteDeploy()
        {
            InitializeComponent();
            LoadSavedProfiles();
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
                CmbProfile.Items.Add(new ComboBoxItem { Content = name, Tag = file });
            }
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            TxtStatus.Text = "Verbinde...";
            StatusDot.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0xD7, 0x00));

            string host = TxtHost.Text.Trim();
            string user = TxtUsername.Text.Trim();
            string pass = TxtPassword.Password;
            int port = int.TryParse(TxtPort.Text, out int p) ? p : 22;

            await Task.Run(() =>
            {
                try
                {
                    _client = new SshClient(host, port, user, pass);
                    _client.Connect();
                }
                catch { _client = null; }
            });

            if (_client != null && _client.IsConnected)
            {
                TxtStatus.Text = $"Verbunden mit {host}";
                StatusDot.Fill = new SolidColorBrush(Color.FromRgb(0x00, 0xC8, 0x53));
                BtnDeploy.IsEnabled = true;
            }
            else
            {
                TxtStatus.Text = "Verbindung fehlgeschlagen";
                StatusDot.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0x00, 0x00));
                BtnDeploy.IsEnabled = false;
            }
        }

        private async void BtnDeploy_Click(object sender, RoutedEventArgs e)
        {
            if (_client == null || !_client.IsConnected) return;

            string profile = (CmbProfile.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
            TxtOutput.Text = $"Starte Deploy: {profile}\n";
            BtnDeploy.IsEnabled = false;

            // build commands based on profile
            string[] commands = GetProfileCommands(profile);

            await Task.Run(() =>
            {
                foreach (string cmd in commands)
                {
                    var result = _client.RunCommand(cmd);
                    Dispatcher.Invoke(() =>
                    {
                        TxtOutput.Text += $"> {cmd}\n{result.Result}\n";
                    });
                }
            });

            TxtOutput.Text += "Deploy abgeschlossen.";
            BtnDeploy.IsEnabled = true;
        }

        private string[] GetProfileCommands(string profile)
        {
            var selected = CmbProfile.SelectedItem as ComboBoxItem;
            if (selected?.Tag != null)
                return GetCustomProfileCommands(selected.Tag.ToString());

            var cmds = new System.Collections.Generic.List<string>();


            cmds.Add("powershell -Command \"Stop-Service DiagTrack -Force; Set-Service DiagTrack -StartupType Disabled\"");
            cmds.Add("powershell -Command \"Stop-Service WerSvc -Force; Set-Service WerSvc -StartupType Disabled\"");
            cmds.Add("powershell -Command \"reg add \\\"HKLM\\\\SOFTWARE\\\\Policies\\\\Microsoft\\\\Windows\\\\DataCollection\\\" /v AllowTelemetry /t REG_DWORD /d 0 /f\"");
            cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\AdvertisingInfo\\\" /v Enabled /t REG_DWORD /d 0 /f\"");
            cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\ContentDeliveryManager\\\" /v ContentDeliveryAllowed /t REG_DWORD /d 0 /f\"");
            cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Search\\\" /v BingSearchEnabled /t REG_DWORD /d 0 /f\"");

            if (profile == "Work Profile")
            {
                cmds.Add("powershell -Command \"Stop-Service lfsvc -Force; Set-Service lfsvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service RetailDemo -Force; Set-Service RetailDemo -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service MapsBroker -Force; Set-Service MapsBroker -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service WpcMonSvc -Force; Set-Service WpcMonSvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*BingNews*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*BingWeather*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Copilot*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Cortana*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*3DViewer*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*ZuneVideo*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*ZuneMusic*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Solitaire*\\\" | Remove-AppxPackage\"");
            }

            if (profile == "Gaming Profile")
            {
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\VisualEffects\\\" /v VisualFXSetting /t REG_DWORD /d 2 /f\"");
                cmds.Add("powershell -Command \"Stop-Service SysMain -Force; Set-Service SysMain -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service TabletInputService -Force; Set-Service TabletInputService -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service SensorService -Force; Set-Service SensorService -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service lfsvc -Force; Set-Service lfsvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service MapsBroker -Force; Set-Service MapsBroker -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service RetailDemo -Force; Set-Service RetailDemo -StartupType Disabled\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Control Panel\\\\Desktop\\\" /v MenuShowDelay /t REG_SZ /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v TaskbarAnimations /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*BingNews*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Copilot*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*ZuneVideo*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*ZuneMusic*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"MSTeams\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Skype*\\\" | Remove-AppxPackage\"");
            }

            if (profile == "Minimum Profile")
            {
                cmds.Add("powershell -Command \"Stop-Service lfsvc -Force; Set-Service lfsvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service SysMain -Force; Set-Service SysMain -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service TabletInputService -Force; Set-Service TabletInputService -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service SensorService -Force; Set-Service SensorService -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service XboxGipSvc -Force; Set-Service XboxGipSvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service XblAuthManager -Force; Set-Service XblAuthManager -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service XblGameSave -Force; Set-Service XblGameSave -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service XboxNetApiSvc -Force; Set-Service XboxNetApiSvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service Spooler -Force; Set-Service Spooler -StartupType Disabled\"");
                cmds.Add("powershell -Command \"Stop-Service Fax -Force; Set-Service Fax -StartupType Disabled\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Control Panel\\\\Desktop\\\" /v MenuShowDelay /t REG_SZ /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v TaskbarAnimations /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Copilot*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Cortana*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"MSTeams\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Skype*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*BingNews*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*BingWeather*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*ZuneVideo*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*ZuneMusic*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*3DViewer*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Solitaire*\\\" | Remove-AppxPackage\"");
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"MicrosoftWindows.Client.WebExperiencePack\\\" | Remove-AppxPackage\"");
            }

            if (profile == "Privacy Profile")
            {
                cmds.Add("powershell -Command \"Stop-Service lfsvc -Force; Set-Service lfsvc -StartupType Disabled\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\CapabilityAccessManager\\\\ConsentStore\\\\webcam\\\" /v Value /t REG_SZ /d Deny /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\CapabilityAccessManager\\\\ConsentStore\\\\microphone\\\" /v Value /t REG_SZ /d Deny /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\CapabilityAccessManager\\\\ConsentStore\\\\contacts\\\" /v Value /t REG_SZ /d Deny /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Clipboard\\\" /v CloudClipboardAutomaticUpload /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\InputPersonalization\\\" /v RestrictImplicitInkCollection /t REG_DWORD /d 1 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Privacy\\\" /v TailoredExperiencesWithDiagnosticDataEnabled /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Speech_OneCore\\\\Preferences\\\" /v ModelDownloadAllowed /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Search\\\" /v HistoryViewEnabled /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKLM\\\\SOFTWARE\\\\Policies\\\\Microsoft\\\\Windows\\\\Windows Error Reporting\\\" /v Disabled /t REG_DWORD /d 1 /f\"");
            }

            if (profile == "Developer Profile")
            {
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v HideFileExt /t REG_DWORD /d 0 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v Hidden /t REG_DWORD /d 1 /f\"");
                cmds.Add("powershell -Command \"reg add \\\"HKLM\\\\SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\AppModelUnlock\\\" /v AllowDevelopmentWithoutDevLicense /t REG_DWORD /d 1 /f\"");
                cmds.Add("powershell -Command \"Set-ExecutionPolicy RemoteSigned -Scope CurrentUser -Force\"");
                cmds.Add("powershell -Command \"dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart\"");
                cmds.Add("powershell -Command \"Add-WindowsCapability -Online -Name OpenSSH.Client~~~~0.0.1.0\"");
            }

            return cmds.ToArray();
        }

        private string[] GetCustomProfileCommands(string file)
        {
            string json = System.IO.File.ReadAllText(file);
            var data = System.Text.Json.JsonDocument.Parse(json);
            var checkboxes = data.RootElement.GetProperty("checkboxes");

            bool Get(string key) => checkboxes.TryGetProperty(key, out var val) && val.GetBoolean();

            var cmds = new System.Collections.Generic.List<string>();

            // Animationen
            if (Get("ChkMenuDelay"))
                cmds.Add("reg add \"HKCU\\Control Panel\\Desktop\" /v MenuShowDelay /t REG_SZ /d 0 /f");
            if (Get("ChkTaskbarAnim"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v TaskbarAnimations /t REG_DWORD /d 0 /f\"");
            if (Get("ChkDynamicScrollbars"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Control Panel\\\\Accessibility\\\" /v DynamicScrollbars /t REG_DWORD /d 0 /f\"");
            if (Get("ChkVisualFX"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v VisualFXSetting /t REG_DWORD /d 2 /f\"");
            if (Get("ChkUserPrefMask"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v UserPreferencesMask /t REG_BINARY /d 9012078002000000 /f\"");
            if (Get("ChkMinAnimate"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Control Panel\\\\Desktop\\\" /v MinAnimate /t REG_SZ /d 0 /f\"");
            if (Get("ChkDragFullWindows"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Control Panel\\\\Desktop\\\" /v DragFullWindows /t REG_SZ /d 0 /f\"");
            if (Get("ChkTransparency"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Themes\\\\Personalize\\\" /v EnableTransparency /t REG_DWORD /d 0 /f\"");
            if (Get("ChkPreviewWindow"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v DisablePreviewDesktop /t REG_DWORD /d 1 /f\"");
            if (Get("ChkSearchboxMode"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Search\\\" /v SearchboxTaskbarMode /t REG_DWORD /d 1 /f\"");
            if (Get("ChkTouchPrediction"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Wisp\\\\Pen\\\" /v DisableHighContrastCursor /t REG_DWORD /d 1 /f\"");
            if (Get("ChkModeChangeAnim"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\Advanced\\\" /v ModeChangeAnimations /t REG_DWORD /d 0 /f\"");

            // Services
            if (Get("ChkDiagTrack"))
                cmds.Add("powershell -Command \"Stop-Service DiagTrack -Force; Set-Service DiagTrack -StartupType Disabled\"");
            if (Get("ChkWerSvc"))
                cmds.Add("powershell -Command \"Stop-Service WerSvc -Force; Set-Service WerSvc -StartupType Disabled\"");
            if (Get("ChkLfsvc"))
                cmds.Add("powershell -Command \"Stop-Service lfsvc -Force; Set-Service lfsvc -StartupType Disabled\"");
            if (Get("ChkPcaSvc"))
                cmds.Add("powershell -Command \"Stop-Service PcaSvc -Force; Set-Service PcaSvc -StartupType Disabled\"");
            if (Get("ChkPimIndex"))
                cmds.Add("powershell -Command \"Stop-Service PimIndexMaintenanceSvc -Force; Set-Service PimIndexMaintenanceSvc -StartupType Disabled\"");
            if (Get("ChkDps"))
                cmds.Add("powershell -Command \"Stop-Service DPS -Force; Set-Service DPS -StartupType Disabled\"");
            if (Get("ChkRetailDemo"))
                cmds.Add("powershell -Command \"Stop-Service RetailDemo -Force; Set-Service RetailDemo -StartupType Disabled\"");
            if (Get("ChkMapsBroker"))
                cmds.Add("powershell -Command \"Stop-Service MapsBroker -Force; Set-Service MapsBroker -StartupType Disabled\"");
            if (Get("ChkWpcMonSvc"))
                cmds.Add("powershell -Command \"Stop-Service WpcMonSvc -Force; Set-Service WpcMonSvc -StartupType Disabled\"");
            if (Get("ChkSCardSvr"))
                cmds.Add("powershell -Command \"Stop-Service SCardSvr -Force; Set-Service SCardSvr -StartupType Disabled\"");
            if (Get("ChkFax"))
                cmds.Add("powershell -Command \"Stop-Service Fax -Force; Set-Service Fax -StartupType Disabled\"");
            if (Get("ChkWisvc"))
                cmds.Add("powershell -Command \"Stop-Service wisvc -Force; Set-Service wisvc -StartupType Disabled\"");
            if (Get("ChkPhoneSvc"))
                cmds.Add("powershell -Command \"Stop-Service PhoneSvc -Force; Set-Service PhoneSvc -StartupType Disabled\"");
            if (Get("ChkSpooler"))
                cmds.Add("powershell -Command \"Stop-Service Spooler -Force; Set-Service Spooler -StartupType Disabled\"");
            if (Get("ChkWbioSrvc"))
                cmds.Add("powershell -Command \"Stop-Service WbioSrvc -Force; Set-Service WbioSrvc -StartupType Disabled\"");
            if (Get("ChkTermService"))
                cmds.Add("powershell -Command \"Stop-Service TermService -Force; Set-Service TermService -StartupType Disabled\"");
            if (Get("ChkWwanSvc"))
                cmds.Add("powershell -Command \"Stop-Service WwanSvc -Force; Set-Service WwanSvc -StartupType Disabled\"");
            if (Get("ChkXboxGipSvc"))
                cmds.Add("powershell -Command \"Stop-Service XboxGipSvc -Force; Set-Service XboxGipSvc -StartupType Disabled\"");
            if (Get("ChkXblAuthManager"))
                cmds.Add("powershell -Command \"Stop-Service XblAuthManager -Force; Set-Service XblAuthManager -StartupType Disabled\"");
            if (Get("ChkXblGameSave"))
                cmds.Add("powershell -Command \"Stop-Service XblGameSave -Force; Set-Service XblGameSave -StartupType Disabled\"");
            if (Get("ChkXboxNetApiSvc"))
                cmds.Add("powershell -Command \"Stop-Service XboxNetApiSvc -Force; Set-Service XboxNetApiSvc -StartupType Disabled\"");
            if (Get("ChkDosvc"))
                cmds.Add("powershell -Command \"Stop-Service DoSvc -Force; Set-Service DoSvc -StartupType Disabled\"");
            if (Get("ChkRemoteRegistry"))
                cmds.Add("powershell -Command \"Stop-Service RemoteRegistry -Force; Set-Service RemoteRegistry -StartupType Disabled\"");
            if (Get("ChkCscService"))
                cmds.Add("powershell -Command \"Stop-Service CscService -Force; Set-Service CscService -StartupType Disabled\"");
            if (Get("ChkIphlpsvc"))
                cmds.Add("powershell -Command \"Stop-Service Iphlpsvc -Force; Set-Service Iphlpsvc -StartupType Disabled\"");
            if (Get("ChkTabletInput"))
                cmds.Add("powershell -Command \"Stop-Service TabletInputService -Force; Set-Service TabletInputService -StartupType Disabled\"");
            if (Get("ChkSensorService"))
                cmds.Add("powershell -Command \"Stop-Service SensorService -Force; Set-Service SensorService -StartupType Disabled\"");
            if (Get("ChkSysMain"))
                cmds.Add("powershell -Command \"Stop-Service SysMain -Force; Set-Service SysMain -StartupType Disabled\"");
            if (Get("ChkFhsvc"))
                cmds.Add("powershell -Command \"Stop-Service fhsvc -Force; Set-Service fhsvc -StartupType Disabled\"");
            if (Get("ChkStiSvc"))
                cmds.Add("powershell -Command \"Stop-Service StiSvc -Force; Set-Service StiSvc -StartupType Disabled\"");
            if (Get("ChkLmhosts"))
                cmds.Add("powershell -Command \"Stop-Service lmhosts -Force; Set-Service lmhosts -StartupType Disabled\"");
            if (Get("ChkTrkWks"))
                cmds.Add("powershell -Command \"Stop-Service TrkWks -Force; Set-Service TrkWks -StartupType Disabled\"");
            if (Get("ChkCertPropSvc"))
                cmds.Add("powershell -Command \"Stop-Service CertPropSvc -Force; Set-Service CertPropSvc -StartupType Disabled\"");
            if (Get("ChkHyperV"))
                cmds.Add("powershell -Command \"Stop-Service vmms -Force; Set-Service vmms -StartupType Disabled\"");
            if (Get("ChkWcolorcp"))
                cmds.Add("powershell -Command \"Stop-Service WcolorcpSvc -Force; Set-Service WcolorcpSvc -StartupType Disabled\"");
            if (Get("ChkWebClient"))
                cmds.Add("powershell -Command \"Stop-Service WebClient -Force; Set-Service WebClient -StartupType Disabled\"");
            if (Get("ChkP2p"))
                cmds.Add("powershell -Command \"Stop-Service PNRPsvc -Force; Set-Service PNRPsvc -StartupType Disabled\"");

            // DataProtection
            if (Get("ChkTelemetry"))
                cmds.Add("powershell -Command \"Set-ItemProperty -Path \\\"HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\\\" -Name \\\"AllowDiagnosticData\\\" -Value 0\"");
            if (Get("ChkActivityHistory"))
                cmds.Add("powershell -Command \"reg add \\\"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\System\\\" /v PublishUserActivities /t REG_DWORD /d 0 /f\"");
            if (Get("ChkLocation"))
                cmds.Add("powershell -Command \"reg add \\\"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors\\\" /v DisableLocation /t REG_DWORD /d 1 /f\"");
            if (Get("ChkFeedback"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Siuf\\Rules\\\" /v NumberOfSIUFInSession /t REG_DWORD /d 0 /f\"");
            if (Get("ChkSearchHistory"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search\\\" /v HistoryViewEnabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkDiagnosticData"))
                cmds.Add("powershell -Command \"reg add \\\"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\\\" /v DiagnosticDataChannelUrl /t REG_SZ /d \\\"\\\" /f\"");
            if (Get("ChkErrorReporting"))
                cmds.Add("powershell -Command \"reg add \\\"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Error Reporting\\\" /v Disabled /t REG_DWORD /d 1 /f\"");
            if (Get("ChkHandwritingData"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\InputPersonalization\\\" /v RestrictImplicitInkCollection /t REG_DWORD /d 1 /f\"");
            if (Get("ChkAdvertisingId"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\\\" /v Enabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkTailoredExperiences"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Privacy\\\" /v TailoredExperiencesWithDiagnosticDataEnabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkSpeechRecognition"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Speech_OneCore\\Preferences\\\" /v ModelDownloadAllowed /t REG_DWORD /d 0 /f\"");
            if (Get("ChkCamera"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam\\\" /v Value /t REG_SZ /d Deny /f\"");
            if (Get("ChkMicrophone"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone\\\" /v Value /t REG_SZ /d Deny /f\"");
            if (Get("ChkContacts"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts\\\" /v Value /t REG_SZ /d Deny /f\"");
            if (Get("ChkCloudClipboard"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Clipboard\\\" /v CloudClipboardAutomaticUpload /t REG_DWORD /d 0 /f\"");

            // Ads
            if (Get("ChkAdsAdvertisingId"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo\\\" /v Enabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkStartMenuSuggestions"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\\" /v Start_IrisRecommendations /t REG_DWORD /d 0 /f\"");
            if (Get("ChkLockScreenAds"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\\\" /v RotatingLockScreenOverlayEnabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkAppSuggestions"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\\\" /v ContentDeliveryAllowed /t REG_DWORD /d 0 /f\"");
            if (Get("ChkBingSearch"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search\\\" /v BingSearchEnabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkExplorerAds"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\\" /v ShowSyncProviderNotifications /t REG_DWORD /d 0 /f\"");
            if (Get("ChkSettingsAds"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\\\" /v SoftLandingEnabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkTips"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\\\" /v SubscribedConten-310093Enabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkSetupAds"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement\\\" /v ScoobeSystemSettingEnabled /t REG_DWORD /d 0 /f\"");
            if (Get("ChkWelcomePage"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StartPage\\\" /v EnableWelcomeBack /t REG_DWORD /d 0 /f\"");
            if (Get("ChkPopups"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\\" /v StartupPage /t REG_DWORD /d 0 /f\"");
            if (Get("ChkWidgetAds"))
                cmds.Add("powershell -Command \"reg add \\\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\\\" /v WidgetContentEnabled /t REG_DWORD /d 0 /f\"");

            // App Removal
            if (Get("ChkCopilot"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Copilot*\\\" | Remove-AppxPackage\"");
            if (Get("ChkCortana"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Cortana*\\\" | Remove-AppxPackage\"");
            if (Get("ChkJournal"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"*Journal*\\\" | Remove-AppxPackage\"");
            if (Get("ChkDevHome"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.DevHome*\\\" | Remove-AppxPackage\"");
            if (Get("ChkXboxApp"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.XboxApp\\\" | Remove-AppxPackage\"");
            if (Get("ChkXboxGameBar"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.XboxGamingOverlay\\\" | Remove-AppxPackage\"");
            if (Get("ChkXboxConsoleCompanion"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.XboxConsoleCompanion\\\" | Remove-AppxPackage\"");
            if (Get("ChkXboxTCUI"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.XboxTCUI\\\" | Remove-AppxPackage\"");
            if (Get("ChkXboxIdentityProvider"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.XboxIdentityProvider\\\" | Remove-AppxPackage\"");
            if (Get("ChkXboxSpeechToText"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.XboxSpeechToTextOverlay\\\" | Remove-AppxPackage\"");
            if (Get("ChkSolitaire"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.MicrosoftSolitaireCollection\\\" | Remove-AppxPackage\"");
            if (Get("ChkTeamsNew"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"MSTeams\\\" | Remove-AppxPackage\"");
            if (Get("ChkTeamsOld"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Teams\\\" | Remove-AppxPackage\"");
            if (Get("ChkSkype"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.SkypeApp\\\" | Remove-AppxPackage\"");
            if (Get("ChkMailCalendar"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"microsoft.windowscommunicationsapps\\\" | Remove-AppxPackage\"");
            if (Get("ChkPeople"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.People\\\" | Remove-AppxPackage\"");
            if (Get("ChkMessaging"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Messaging\\\" | Remove-AppxPackage\"");
            if (Get("ChkPhoneLink"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.YourPhone\\\" | Remove-AppxPackage\"");
            if (Get("ChkStickyNotes"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.MicrosoftStickyNotes\\\" | Remove-AppxPackage\"");
            if (Get("ChkToDo"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.ToDo\\\" | Remove-AppxPackage\"");
            if (Get("ChkOneNote"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Office.OneNote\\\" | Remove-AppxPackage\"");
            if (Get("ChkOfficeHub"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.MicrosoftOfficeHub\\\" | Remove-AppxPackage\"");
            if (Get("ChkPowerBI"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.PowerBIDesktop\\\" | Remove-AppxPackage\"");
            if (Get("ChkPowerAutomate"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.PowerAutomateDesktop\\\" | Remove-AppxPackage\"");
            if (Get("ChkSway"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Sway\\\" | Remove-AppxPackage\"");
            if (Get("ChkPCManager"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.PCManager\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingNews"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingNews\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingWeather"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingWeather\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingFinance"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingFinance\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingSports"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingSports\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingFoodDrink"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingFoodandDrink\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingHealthFitness"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingHealthandFitness\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingTranslator"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingTranslator\\\" | Remove-AppxPackage\"");
            if (Get("ChkBingTravel"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.BingTravel\\\" | Remove-AppxPackage\"");
            if (Get("ChkMicrosoftNews"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.MicrosoftNews\\\" | Remove-AppxPackage\"");
            if (Get("Chk3DViewer"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.3DViewer\\\" | Remove-AppxPackage\"");
            if (Get("Chk3DBuilder"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.3DBuilder\\\" | Remove-AppxPackage\"");
            if (Get("ChkPaint3D"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Paint3D\\\" | Remove-AppxPackage\"");
            if (Get("ChkMixedReality"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.MixedReality*\\\" | Remove-AppxPackage\"");
            if (Get("ChkPrint3D"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Print3D\\\" | Remove-AppxPackage\"");
            if (Get("ChkFilmsTV"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.ZuneVideo\\\" | Remove-AppxPackage\"");
            if (Get("ChkGrooveMusic"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.ZuneMusic\\\" | Remove-AppxPackage\"");
            if (Get("ChkClipchamp"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Clipchamp.Clipchamp\\\" | Remove-AppxPackage\"");
            if (Get("ChkFeedbackHub"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.WindowsFeedbackHub\\\" | Remove-AppxPackage\"");
            if (Get("ChkGetHelp"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.GetHelp\\\" | Remove-AppxPackage\"");
            if (Get("ChkGetStarted"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.GetStarted\\\" | Remove-AppxPackage\"");
            if (Get("ChkQuickAssist"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.QuickAssist\\\" | Remove-AppxPackage\"");
            if (Get("ChkFamilySafety"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.FamilySafety\\\" | Remove-AppxPackage\"");
            if (Get("ChkNetworkSpeedTest"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.NetworkSpeedTest\\\" | Remove-AppxPackage\"");
            if (Get("ChkOneConnect"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.OneConnect\\\" | Remove-AppxPackage\"");
            if (Get("ChkAlarmsClock"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.WindowsAlarms\\\" | Remove-AppxPackage\"");
            if (Get("ChkSoundRecorder"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.SoundRecorder\\\" | Remove-AppxPackage\"");
            if (Get("ChkWidgets"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Windows.Widgets\\\" | Remove-AppxPackage\"");
            if (Get("ChkWidgetsPlatform"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Windows.WidgetsService\\\" | Remove-AppxPackage\"");
            if (Get("ChkWebExperiencePack"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"MicrosoftWindows.Client.WebExperiencePack\\\" | Remove-AppxPackage\"");
            if (Get("ChkCrossDevice"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.CrossDevice\\\" | Remove-AppxPackage\"");
            if (Get("ChkEdge"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Edge\\\" | Remove-AppxPackage\"");
            if (Get("ChkOneDrive"))
                cmds.Add("powershell -Command \"Stop-Service OneDrive -Force; taskkill /F /IM OneDrive.exe\"");
            if (Get("ChkOutlook"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.OutlookForWindows\\\" | Remove-AppxPackage\"");
            if (Get("ChkWhiteboard"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Whiteboard\\\" | Remove-AppxPackage\"");
            if (Get("ChkRemoteDesktop"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.RemoteDesktop\\\" | Remove-AppxPackage\"");
            if (Get("Chk365Companions"))
                cmds.Add("powershell -Command \"Get-AppxPackage -Name \\\"Microsoft.Microsoft365CentralizedDeploymentService\\\" | Remove-AppxPackage\"");

            return cmds.ToArray();
        }
    }
}
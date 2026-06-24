namespace WindowsDebloater.Core
{
    public static class Services
    {
        private static void RunPowerShellCommand(string arguments)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{arguments}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        private static void DisableService(string name) => RunPowerShellCommand($"Stop-Service -Name '{name}'" +
            $" -Force -ErrorAction SilentlyContinue; Set-Service -Name '{name}' -StartupType Disabled -ErrorAction SilentlyContinue");

        // ------------------------------------------------------------------------- DataProtection & Telemetry
        // Telemetry
        public static void DisableDiagTrack() => DisableService("DiagTrack");
        // Error Reporting
        public static void DisableWerSvc() => DisableService("WerSvc");
        // Location
        public static void DisableLfsvc() => DisableService("lfsvc");
        // Compatibility-Assistent
        public static void DisablePcaSvc() => DisableService("PcaSvc");
        // Customer Experience
        public static void DisablePimIndexMaintenanceSvc() => DisableService("PimIndexMaintenanceSvc");
        // Diagnostic Guideline
        public static void DisableDps() => DisableService("DPS");

        // ------------------------------------------------------------------------- Unnecessary Services
        // Retail-Demo
        public static void DisableRetailDemo() => DisableService("RetailDemo");
        // Offline-maps
        public static void DisableMapsBroker() => DisableService("MapsBroker");
        // Youth protection
        public static void DisableWpcMonSvc() => DisableService("WpcMonSvc");
        // Smartcard
        public static void DisableSCardSvr() => DisableService("SCardSvr");
        // Fax
        public static void DisableFax() => DisableService("Fax");
        // Insider-Service
        public static void DisableWisvc() => DisableService("wisvc");
        // Telephone Service
        public static void DisablePhoneSvc() => DisableService("PhoneSvc");

        // ------------------------------------------------------------------------- Often not used Services
        // Printer-Spooler
        public static void DisableSpooler() => DisableService("Spooler");
        // Biometrie
        public static void DisableWbioSrvc() => DisableService("WbioSrvc");
        // Remotedesktop
        public static void DisableTermService() => DisableService("TermService");
        // Mobile network hotspot
        public static void DisableWwanSvc() => DisableService("WwanSvc");

        // ------------------------------------------------------------------------- Gaming Services
        // Xbox-Accesories
        public static void DisableXboxGipSvc() => DisableService("XboxGipSvc");
        // Xbox-Login
        public static void DisableXblAuthManager() => DisableService("XblAuthManager");
        // Xbox-Savestates
        public static void DisableXblGameSave() => DisableService("XblGameSave");
        // Xbox-Network
        public static void DisableXboxNetApiSvc() => DisableService("XboxNetApiSvc");

        // ------------------------------------------------------------------------- Network and Data-sharing
        // Delivery optimization
        public static void DisableDosvc() => DisableService("Dosvc");
        // Remote registration
        public static void DisableRemoteRegistry() => DisableService("RemoteRegistry");
        // Offline files
        public static void DisableCscService() => DisableService("CscService");
        // IP Help Service
        public static void DisableIphlpsvc() => DisableService("iphlpsvc");

        // ------------------------------------------------------------------------- Hardware specific
        // Touch-Keyboard
        public static void DisableTabletInputService() => DisableService("TabletInputService");
        // Sensor-Service
        public static void DisableSensorService() => DisableService("SensorService");

        // ------------------------------------------------------------------------- Systemoptimization
        // SysMain
        public static void DisableSysMain() => DisableService("SysMain");
        // File History
        public static void DisableFhsvc() => DisableService("fhsvc");

        // ------------------------------------------------------------------------- Scanner
        // Scanner-Service
        public static void DisableStiSvc() => DisableService("StiSvc");

        // ------------------------------------------------------------------------- Old Networkprotocols
        // NetBIOS Help Service
        public static void DisableLmhosts() => DisableService("lmhosts");
        // Distributed links
        public static void DisableTrkWks() => DisableService("TrkWks");

        // ------------------------------------------------------------------------- Security & Virtualization
        // Certificate distribution
        public static void DisableCertPropSvc() => DisableService("CertPropSvc");
        // Hyper-V
        public static void DisableVmicguestinterface() => DisableService("vmicguestinterface");

        // ------------------------------------------------------------------------- Old Services
        // CRT monitors
        public static void DisableWcolorcp() => DisableService("wcolorcp");
        // Webclient
        public static void DisableWebClient() => DisableService("WebClient");
        // Peer-Network
        public static void DisableP2pSvc() => DisableService("p2psvc");
        public static void DisableP2pImSvc() => DisableService("p2pimsvc");

        // ------------------------------------------------------------------------- Groups
        public static void DisableAllTelemetry()
        {
            DisableDiagTrack();
            DisableWerSvc();
            DisableLfsvc();
            DisablePcaSvc();
            DisablePimIndexMaintenanceSvc();
            DisableDps();
        }

        public static void DisableAllUnnecessary()
        {
            DisableRetailDemo();
            DisableMapsBroker();
            DisableWpcMonSvc();
            DisableSCardSvr();
            DisableFax();
            DisableWisvc();
            DisablePhoneSvc();
        }

        public static void DisableAllOftenUnused()
        {
            DisableSpooler();
            DisableWbioSrvc();
            DisableTermService();
            DisableWwanSvc();
        }

        public static void DisableAllGaming()
        {
            DisableXboxGipSvc();
            DisableXblAuthManager();
            DisableXblGameSave();
            DisableXboxNetApiSvc();
        }

        public static void DisableAllNetwork()
        {
            DisableDosvc();
            DisableRemoteRegistry();
            DisableCscService();
            DisableIphlpsvc();
        }

        public static void DisableAllHardware()
        {
            DisableTabletInputService();
            DisableSensorService();
        }

        public static void DisableAllSystem()
        {
            DisableSysMain();
            DisableFhsvc();
            DisableStiSvc();
        }

        public static void DisableAllOld()
        {
            DisableLmhosts();
            DisableTrkWks();
            DisableCertPropSvc();
            DisableVmicguestinterface();
            DisableWcolorcp();
            DisableWebClient();
            DisableP2pSvc();
            DisableP2pImSvc();
        }
    }
}
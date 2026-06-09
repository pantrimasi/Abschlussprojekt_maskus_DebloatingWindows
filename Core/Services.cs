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

        // stop + disable
        private static void DisableService(string name) => RunPowerShellCommand($"Stop-Service -Name '{name}' -Force -ErrorAction SilentlyContinue; Set-Service -Name '{name}' -StartupType Disabled -ErrorAction SilentlyContinue");

        // ------------------------------------------------------------------------- Datenschutz
        // Telemetrie
        public static void DisableDiagTrack() => DisableService("DiagTrack");
        // Fehlerberichte
        public static void DisableWerSvc() => DisableService("WerSvc");
        // Standort
        public static void DisableLfsvc() => DisableService("lfsvc");
        // Kompatibilitäts-Assistent
        public static void DisablePcaSvc() => DisableService("PcaSvc");
        // Kundenerfahrung
        public static void DisablePimIndexMaintenanceSvc() => DisableService("PimIndexMaintenanceSvc");
        // Diagnose-Richtlinie
        public static void DisableDps() => DisableService("DPS");

        // ------------------------------------------------------------------------- Unnötige Services
        // Retail-Demo
        public static void DisableRetailDemo() => DisableService("RetailDemo");
        // Offline-Karten
        public static void DisableMapsBroker() => DisableService("MapsBroker");
        // Jugendschutz
        public static void DisableWpcMonSvc() => DisableService("WpcMonSvc");
        // Smartcard
        public static void DisableSCardSvr() => DisableService("SCardSvr");
        // Fax
        public static void DisableFax() => DisableService("Fax");
        // Insider-Service
        public static void DisableWisvc() => DisableService("wisvc");
        // Telefon-Dienst
        public static void DisablePhoneSvc() => DisableService("PhoneSvc");

        // ------------------------------------------------------------------------- Meistens nicht benutzt
        // Druckwarteschlange
        public static void DisableSpooler() => DisableService("Spooler");
        // Biometrie
        public static void DisableWbioSrvc() => DisableService("WbioSrvc");
        // Remotedesktop
        public static void DisableTermService() => DisableService("TermService");
        // Handynetz-Hotspot
        public static void DisableWwanSvc() => DisableService("WwanSvc");

        // ------------------------------------------------------------------------- Gaming Dienste
        // Xbox-Zubehör
        public static void DisableXboxGipSvc() => DisableService("XboxGipSvc");
        // Xbox-Anmeldung
        public static void DisableXblAuthManager() => DisableService("XblAuthManager");
        // Xbox-Speicherstände
        public static void DisableXblGameSave() => DisableService("XblGameSave");
        // Xbox-Netzwerk
        public static void DisableXboxNetApiSvc() => DisableService("XboxNetApiSvc");

        // ------------------------------------------------------------------------- Netzwerk und Datenfreigabe
        // Lieferoptimierung
        public static void DisableDosvc() => DisableService("Dosvc");
        // Remoteregistrierung
        public static void DisableRemoteRegistry() => DisableService("RemoteRegistry");
        // Offlinedateien
        public static void DisableCscService() => DisableService("CscService");
        // IP-Hilfsdienst
        public static void DisableIphlpsvc() => DisableService("iphlpsvc");

        // ------------------------------------------------------------------------- Hardwarespezifisch
        // Touch-Tastatur
        public static void DisableTabletInputService() => DisableService("TabletInputService");
        // Sensor-Dienst
        public static void DisableSensorService() => DisableService("SensorService");

        // ------------------------------------------------------------------------- Systemoptimierung
        // SysMain
        public static void DisableSysMain() => DisableService("SysMain");
        // Dateiverlauf
        public static void DisableFhsvc() => DisableService("fhsvc");

        // ------------------------------------------------------------------------- Scanner
        // Scanner-Dienst
        public static void DisableStiSvc() => DisableService("StiSvc");

        // ------------------------------------------------------------------------- Alte Netzwerkprotokolle
        // NetBIOS-Hilfsdienst
        public static void DisableLmhosts() => DisableService("lmhosts");
        // Verteilte Verknüpfungen
        public static void DisableTrkWks() => DisableService("TrkWks");

        // ------------------------------------------------------------------------- Sicherheit & Virtualisierung
        // Zertifikat-Verbreitung
        public static void DisableCertPropSvc() => DisableService("CertPropSvc");
        // Hyper-V
        public static void DisableVmicguestinterface() => DisableService("vmicguestinterface");

        // ------------------------------------------------------------------------- Veraltetes Zeug
        // Röhrenmonitore
        public static void DisableWcolorcp() => DisableService("wcolorcp");
        // Webclient
        public static void DisableWebClient() => DisableService("WebClient");
        // Peer-Netzwerk
        public static void DisableP2pSvc() => DisableService("p2psvc");
        public static void DisableP2pImSvc() => DisableService("p2pimsvc");
    }
}
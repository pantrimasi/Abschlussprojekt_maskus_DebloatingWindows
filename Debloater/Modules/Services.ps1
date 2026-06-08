function Disable-UselessServices
{
    # ------------------------------------------------------------------------- Datenschutz
    # Telemetrie
    Stop-Service -Name "DiagTrack" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "DiagTrack" -StartupType Disabled -ErrorAction SilentlyContinue

    # Fehlerberichte
    Stop-Service -Name "WerSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "WerSvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Standort
    Stop-Service -Name "lfsvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "lfsvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Kompatibilitäts-Assistent
    Stop-Service -Name "PcaSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "PcaSvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Kundenerfahrung
    Stop-Service -Name "PimIndexMaintenanceSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "PimIndexMaintenanceSvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Diagnose-Richtlinie
    Stop-Service -Name "DPS" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "DPS" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Unnötige Services
    # Retail-Demo
    Stop-Service -Name "RetailDemo" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "RetailDemo" -StartupType Disabled -ErrorAction SilentlyContinue

    # Offline-Karten
    Stop-Service -Name "MapsBroker" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "MapsBroker" -StartupType Disabled -ErrorAction SilentlyContinue

    # Jugendschutz
    Stop-Service -Name "WpcMonSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "WpcMonSvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Smartcard
    Stop-Service -Name "SCardSvr" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "SCardSvr" -StartupType Disabled -ErrorAction SilentlyContinue

    # Fax
    Stop-Service -Name "Fax" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "Fax" -StartupType Disabled -ErrorAction SilentlyContinue

    # Insider-Service
    Stop-Service -Name "wisvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "wisvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Telefon-Dienst
    Stop-Service -Name "PhoneSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "PhoneSvc" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Meistens nicht benutzte Dienste
    # Druckwarteschlange
    Stop-Service -Name "Spooler" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "Spooler" -StartupType Disabled -ErrorAction SilentlyContinue

    # Biometrie
    Stop-Service -Name "WbioSrvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "WbioSrvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Remotedesktop
    Stop-Service -Name "TermService" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "TermService" -StartupType Disabled -ErrorAction SilentlyContinue

    # Handynetz-Hotspot
    Stop-Service -Name "WwanSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "WwanSvc" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Gaming Dienste
    # Xbox-Zubehör
    Stop-Service -Name "XboxGipSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "XboxGipSvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Xbox-Anmeldung
    Stop-Service -Name "XblAuthManager" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "XblAuthManager" -StartupType Disabled -ErrorAction SilentlyContinue

    # Xbox-Speicherstände
    Stop-Service -Name "XblGameSave" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "XblGameSave" -StartupType Disabled -ErrorAction SilentlyContinue

    # Xbox-Netzwerk
    Stop-Service -Name "XboxNetApiSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "XboxNetApiSvc" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Netzwerk und Datenfreigabe
    # Lieferoptimierung
    Stop-Service -Name "Dosvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "Dosvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Remoteregistrierung
    Stop-Service -Name "RemoteRegistry" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "RemoteRegistry" -StartupType Disabled -ErrorAction SilentlyContinue

    # Offlinedateien
    Stop-Service -Name "CscService" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "CscService" -StartupType Disabled -ErrorAction SilentlyContinue

    # IP-Hilfsdienst
    Stop-Service -Name "iphlpsvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "iphlpsvc" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Hardwarespezifisch
    # Touch-Tastatur
    Stop-Service -Name "TabletInputService" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "TabletInputService" -StartupType Disabled -ErrorAction SilentlyContinue

    # Sensor-Dienst
    Stop-Service -Name "SensorService" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "SensorService" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Systemoptimierung
    # SysMain
    Stop-Service -Name "SysMain" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "SysMain" -StartupType Disabled -ErrorAction SilentlyContinue

    # Dateiverlauf
    Stop-Service -Name "fhsvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "fhsvc" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Scanner
    # Scanner-Dienst
    Stop-Service -Name "StiSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "StiSvc" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Alte Netzwerkprotokolle
    # NetBIOS-Hilfsdienst
    Stop-Service -Name "lmhosts" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "lmhosts" -StartupType Disabled -ErrorAction SilentlyContinue

    # Verteilte Verknüpfungen
    Stop-Service -Name "TrkWks" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "TrkWks" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Sicherheit & Virtualisierung
    # Zertifikat-Verbreitung
    Stop-Service -Name "CertPropSvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "CertPropSvc" -StartupType Disabled -ErrorAction SilentlyContinue

    # Hyper-V
    Stop-Service -Name "vmicguestinterface" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "vmicguestinterface" -StartupType Disabled -ErrorAction SilentlyContinue


    # ------------------------------------------------------------------------- Veraltete Reste
    # Röhrenmonitore
    Stop-Service -Name "wcolorcp" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "wcolorcp" -StartupType Disabled -ErrorAction SilentlyContinue

    # Webclient
    Stop-Service -Name "WebClient" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "WebClient" -StartupType Disabled -ErrorAction SilentlyContinue

    # Peer-Netzwerk
    Stop-Service -Name "p2psvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "p2psvc" -StartupType Disabled -ErrorAction SilentlyContinue
    Stop-Service -Name "p2pimsvc" -Force -ErrorAction SilentlyContinue
    Set-Service -Name "p2pimsvc" -StartupType Disabled -ErrorAction SilentlyContinue
}
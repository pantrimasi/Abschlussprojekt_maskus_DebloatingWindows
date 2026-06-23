# WindowsDebloater

*Eine moderne WPF-Anwendung für Windows 11 zum Debloating, Optimieren, Datenschutz und Remote-Management von Windows-Systemen.*

## Übersicht

WindowsDebloater ist ein Abschlussprojekt, das mit C# und WPF auf Basis von .NET 10 entwickelt wurde. Die Anwendung bietet eine benutzerfreundliche Oberfläche, um unnötige Windows-Komponenten zu entfernen, Datenschutzeinstellungen anzupassen, Dienste zu deaktivieren und eigene Optimierungsprofile zu erstellen.

Zusätzlich enthält die Anwendung Funktionen für Remote-Deployments über SSH, die Erstellung von Wiederherstellungspunkten sowie die Verwaltung von benutzerdefinierten Profilen.

## Funktionen

### Systemoptimierung
- Deaktivieren von Windows-Animationen
- Optimierung für bessere Leistung
- Deaktivieren unnötiger Dienste
- Reduzierung von Hintergrundprozessen

### Datenschutz
- Deaktivieren von Telemetrie
- Entfernen von Werbe-ID und personalisierten Vorschlägen
- Abschalten von Diagnose- und Feedbackdiensten
- Einschränkung von Standort- und Aktivitätsverfolgung

### App-Entfernung
- Entfernen von vorinstallierten Windows-Apps
- Deinstallation von Xbox-Komponenten
- Entfernen von Bing-Apps
- Entfernen von Office- und Kommunikations-Apps
- Entfernen von Widgets und weiteren optionalen Komponenten

### Profile
- Vordefinierte Profile:
  - Work
  - Gaming
  - Minimum
  - Developer
  - Privacy
- Eigene Profile erstellen
- Profile importieren und exportieren
- Profile als JSON speichern

### Backup-System
- Erstellen von Windows-Wiederherstellungspunkten
- Wiederherstellen früherer Systemzustände
- Lokale Speicherung der Backup-Metadaten

### Remote Deploy
- Verbindung über SSH
- Profile auf entfernten Geräten anwenden
- Live-Ausgabe aller ausgeführten Befehle
- Unterstützung von eigenen und vordefinierten Profilen

### Live-Systeminformationen
- CPU-Auslastung
- RAM-Auslastung
- Anzahl laufender Prozesse
- Anzahl installierter Programme

## Technologien

- C#
- WPF
- .NET 10
- XAML
- PowerShell
- Windows Registry
- JSON
- SSH.NET
- System.Management

## Projektstruktur

```text
WindowsDebloater/
├── GUI/
│   ├── MainWindow.xaml
│   └── Tabs/
├── Core/
│   ├── Animationen.cs
│   ├── Ads.cs
│   ├── DataProtection.cs
│   ├── Services.cs
│   ├── AppRemoval.cs
│   ├── Developer.cs
│   ├── ProfileManager.cs
│   ├── WindowsActivation.cs
│   ├── LiveUtilization.cs
│   ├── AskAdminPermissions.cs
│   └── Backup.cs
└── App.xaml
```

## Voraussetzungen

- Windows 11
- Administratorrechte
- .NET 10 Runtime
- Internetverbindung für bestimmte Funktionen

## Installation

1. Repository klonen:

```bash
git clone https://github.com/pantrimasi/Abschlussprojekt_maskus_DebloatingWindows.git
```

2. Projekt öffnen:

```bash
cd Abschlussprojekt_maskus_DebloatingWindows
```

3. Lösung in Visual Studio öffnen.

4. Projekt kompilieren und starten.

## Verwendung

### Optimierungen anwenden
1. Gewünschten Tab auswählen.
2. Einstellungen aktivieren.
3. Auf **Anwenden** klicken.

### Profil verwenden
1. Zum Tab **Profiles** wechseln.
2. Profil auswählen.
3. Anwenden bestätigen.

### Eigenes Profil erstellen
1. Auf **Profil erstellen** klicken.
2. Einstellungen auswählen.
3. Profil speichern.

### Remote Deploy
1. IP-Adresse und Zugangsdaten eingeben.
2. Profil auswählen.
3. Verbindung herstellen.
4. Profil ausführen.

## Architektur

Die Anwendung verwendet eine klassische Code-Behind-Architektur ohne MVVM.

Die Logik ist in drei Bereiche getrennt:

- `WindowsDebloater.Core`
- `WindowsDebloater.GUI`
- `WindowsDebloater.GUI.Tabs`

Langlaufende Prozesse werden mit `async` und `await` ausgeführt, damit die Benutzeroberfläche jederzeit reaktionsfähig bleibt.

## Datenspeicherung

### Profile
```text
%AppData%\WindowsDebloater\profiles\
```

### Backups
```text
%AppData%\WindowsDebloater\backups.json
```

## Screenshots

Füge hier Screenshots der Anwendung ein.

```md
![MainWindow](images/mainwindow.png)
![Profiles](images/profiles.png)
![RemoteDeploy](images/remotedeploy.png)
```

## Mitwirken

Verbesserungsvorschläge, Bug-Reports und Pull Requests sind willkommen.

## Lizenz

Dieses Projekt wurde als Abschlussprojekt erstellt und besitzt derzeit keine offizielle Lizenz.

## Autor

**PantriMasi**

GitHub: https://github.com/pantrimasi

## Repository

https://github.com/pantrimasi/Abschlussprojekt_maskus_DebloatingWindows

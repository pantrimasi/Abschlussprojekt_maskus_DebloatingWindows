# WindowsDebloater

*Eine moderne WPF-Anwendung zum Debloaten, Optimieren und Absichern von Windows 11.*

## Übersicht

WindowsDebloater ist ein Abschlussprojekt, das mit C# und .NET 10.0 entwickelt wurde. Die Anwendung bietet eine übersichtliche grafische Oberfläche, mit der Benutzer Windows 11 an ihre Bedürfnisse anpassen können. Dazu gehören das Entfernen vorinstallierter Apps, das Deaktivieren unnötiger Dienste, Datenschutz-Optimierungen, das Anwenden von Profilen sowie die Verwaltung von Backups und Remote-Deployments.

## Funktionen

- Debloating von vorinstallierten Windows-Apps
- Datenschutz- und Telemetrie-Einstellungen
- Deaktivieren unnötiger Windows-Dienste
- Vordefinierte Profile (Work, Gaming, Minimum, Developer, Privacy)
- Eigene Profile erstellen, importieren und exportieren
- Windows-Wiederherstellungspunkte erstellen und wiederherstellen
- Windows-Aktivierung über KMS
- Live-Anzeige von CPU-, RAM- und Prozessauslastung
- Remote-Deployment über SSH
- Modernes WPF-Design mit eigenem Fenstersystem

## Verwendete Technologien

- C#
- .NET 10.0
- WPF
- System.Text.Json
- System.Management
- SSH.NET
- PowerShell
- Windows Registry

## Projektstruktur

```text
WindowsDebloater/
├── GUI/
│   ├── MainWindow.xaml
│   └── Tabs/
├── Core/
├── App.xaml
└── App.xaml.cs
```

## Installation

1. Repository klonen:

```bash
git clone https://github.com/pantrimasi/Abschlussprojekt_maskus_DebloatingWindows.git
```

2. Projekt in Visual Studio öffnen.

3. NuGet-Pakete wiederherstellen.

4. Projekt im Release- oder Debug-Modus starten.

> Die Anwendung benötigt Administratorrechte, da Änderungen an Diensten, der Registry und Windows-Einstellungen vorgenommen werden.

## Profile

Die Anwendung enthält folgende Standardprofile:

- Work
- Gaming
- Minimum
- Developer
- Privacy

Zusätzlich können eigene Profile erstellt, gespeichert, exportiert und auf anderen Geräten importiert werden.

## Backup-System

Vor kritischen Änderungen können automatisch Windows-Wiederherstellungspunkte erstellt werden. Dadurch lassen sich Änderungen bei Bedarf wieder rückgängig machen.

## Remote Deploy

Über SSH können Profile auf entfernten Windows-Systemen angewendet werden. Eigene Profile werden automatisch in Befehle übersetzt und auf dem Zielsystem ausgeführt.

## Mitwirkende

- PantriMasi

## Projektstatus

Dieses Projekt wurde im Rahmen eines Abschlussprojekts entwickelt und dient Lern- und Demonstrationszwecken.

## Credits

Entwickelt von **PantriMasi**.

---

# WindowsDebloater

*A modern WPF application for debloating, optimizing and securing Windows 11.*

## Overview

WindowsDebloater is a graduation project developed with C# and .NET 10.0. The application provides a graphical interface that allows users to customize and optimize Windows 11 according to their needs. It includes app removal, privacy improvements, service management, profiles, backups and remote deployment.

## Features

- Remove preinstalled Windows applications
- Privacy and telemetry configuration
- Disable unnecessary Windows services
- Built-in profiles (Work, Gaming, Minimum, Developer, Privacy)
- Create, import and export custom profiles
- Create and restore Windows restore points
- Windows activation via KMS
- Live CPU, RAM and process monitoring
- Remote deployment via SSH
- Modern WPF interface with custom window design

## Technologies

- C#
- .NET 10.0
- WPF
- System.Text.Json
- System.Management
- SSH.NET
- PowerShell
- Windows Registry

## Project Structure

```text
WindowsDebloater/
├── GUI/
│   ├── MainWindow.xaml
│   └── Tabs/
├── Core/
├── App.xaml
└── App.xaml.cs
```

## Installation

1. Clone the repository:

```bash
git clone https://github.com/pantrimasi/Abschlussprojekt_maskus_DebloatingWindows.git
```

2. Open the project in Visual Studio.

3. Restore the NuGet packages.

4. Start the application in Release or Debug mode.

> Administrator privileges are required because the application modifies services, the registry and system settings.

## Profiles

The application includes the following built-in profiles:

- Work
- Gaming
- Minimum
- Developer
- Privacy

Users can also create, save, export and import their own profiles.

## Backup System

Windows restore points can be created automatically before critical changes, allowing users to revert modifications if necessary.

## Remote Deploy

Profiles can be applied to remote systems via SSH. Custom profiles are automatically translated into commands and executed on the target machine.

## Contributors

- PantriMasi

## Project Status

This project was created as a graduation project and is intended for educational and demonstration purposes.

## Credits

Developed by **PantriMasi**.

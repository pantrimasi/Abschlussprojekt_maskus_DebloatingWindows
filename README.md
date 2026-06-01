# Windows Debloating-Projekt

*Systematische Analyse, Automatisierung und Profilverwaltung für eine optimierte Windows-VM-Umgebung*

## Überblick

In diesem Projekt wird eine Windows-Umgebung innerhalb einer virtuellen Maschine als Grundlage für eine strukturierte Systemoptimierung genutzt. Ziel ist es, das System nicht einfach zu „entschlacken“, sondern nachvollziehbar zu analysieren, gezielt anzupassen und reproduzierbar zu konfigurieren.

Zu Beginn wird der Ist-Zustand des Systems untersucht. Dazu gehören installierte Programme, aktive Dienste, Autostart-Einträge sowie Hintergrundprozesse. Diese Analyse schafft eine klare Ausgangsbasis für alle weiteren Anpassungen.

Auf dieser Grundlage werden verschiedene Systemprofile definiert:
- Arbeitsprofil
- Gaming-Profil
- Minimalprofil

Jedes Profil hat eigene Anforderungen an Leistung, Stabilität und Hintergrundaktivitäten. Die Anpassung erfolgt automatisiert über PowerShell-Skripte.

Zur Bedienung wird zusätzlich eine grafische Oberfläche auf Basis von PowerShell Windows Forms entwickelt. Diese ermöglicht das einfache Wechseln zwischen Profilen und zeigt über ein Log-System alle vorgenommenen Änderungen nachvollziehbar an.

## Installation

1. Repository klonen:
   git clone https://github.com/pantrimasi/Abschlussprojekt_maskus_DebloatingWindows

2. Virtuelle Maschine mit Windows einrichten (empfohlen als Testumgebung)

3. PowerShell Skripte mit Administratorrechten ausführen

4. Optional: Windows Forms GUI starten zur Profilsteuerung

## Verwendung

Nach dem Setup können über die bereitgestellten Skripte oder die GUI verschiedene Systemprofile aktiviert werden. Jede Aktivierung passt Dienste, Autostart und Systemkomponenten automatisch an das gewählte Szenario an.

Das Log-System dokumentiert alle Änderungen, damit der Zustand des Systems jederzeit nachvollziehbar bleibt.

## Mitwirken

Beiträge sind möglich durch:
- Verbesserung bestehender Skripte
- Erweiterung der Profile
- Optimierung der GUI
- Dokumentation von Systemänderungen

Pull Requests sind willkommen.

## Lizenz & Credits

Projekt erstellt von PantriMasi im Rahmen eines Abschlussprojekts in der Fachrichtung Plattformentwicklung.

## Optionale Links

- GitHub Repository: https://github.com/pantrimasi/Abschlussprojekt_maskus_DebloatingWindows

## Vorteile und Nachteile

**Vorteile**
- Reproduzierbare Systemkonfiguration durch Automatisierung
- Klare Trennung von Nutzungsszenarien über Profile
- Verbesserte Übersicht durch Logging und GUI
- Reduzierter manueller Aufwand bei Systemanpassungen

**Nachteile**
- Erhöhter Initialaufwand bei Skripterstellung
- Potenzielle Kompatibilitätsprobleme bei Windows Updates
- Risiko von Fehlkonfigurationen bei tiefen Systemeingriffen
- Abhängigkeit von PowerShell und administrativen Rechten

## Source Directory

- VM Setup: Virtuelle Windows-Testumgebung
- Scripts: PowerShell Automatisierung für Debloating und Profilwechsel
- Profiles: Definition von Arbeits-, Gaming- und Minimal-Konfigurationen
- GUI: PowerShell Windows Forms Oberfläche zur Steuerung
- Logging: Protokollierung aller Systemänderungen

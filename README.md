# WindowsDebloater

*WindowsDebloater ist eine Desktop-Anwendung für Windows, die unnötige Funktionen, Werbung, Telemetrie und Hintergrunddienste mit wenigen Klicks deaktiviert. Das Ziel des Projekts ist es, ein Windows-System übersichtlicher, datenschutzfreundlicher und ressourcenschonender zu gestalten.*

## Übersicht

WindowsDebloater wurde mit C# und WPF unter .NET 10.0 entwickelt. Die Anwendung bietet eine grafische Oberfläche, über die verschiedene Optimierungen ausgewählt und angewendet werden können.

Der Fokus liegt auf:

- Deaktivieren von Windows-Werbung
- Verbessern des Datenschutzes
- Abschalten unnötiger Hintergrunddienste
- Entfernen von visuellen Effekten
- Reduzieren von Autostart-Einträgen

Alle Optimierungen können direkt über die Benutzeroberfläche ausgewählt werden.

## Funktionen

### Animationen

Das Modul `Animationen.cs` deaktiviert verschiedene visuelle Effekte von Windows.

Beispiele:

- Fensteranimationen
- Transparenzeffekte
- Aero Peek
- Touch-Feedback
- Menüverzögerungen

Nach dem Anwenden wird der Windows Explorer automatisch neu gestartet.

### Werbung

Das Modul `Ads.cs` deaktiviert verschiedene Werbe- und Vorschlagsfunktionen von Windows.

Beispiele:

- Startmenü-Vorschläge
- Sperrbildschirm-Werbung
- App-Empfehlungen
- Widget-Werbung
- Bing-Integration

### Datenschutz

Das Modul `DataProtection.cs` deaktiviert verschiedene Datenschutzfunktionen.

Beispiele:

- Telemetrie
- Aktivitätsverlauf
- Standortdienste
- Suchverlauf
- Fehlerberichterstattung
- Kamera- und Mikrofonzugriffe
- Cloud-Zwischenablage

### Dienste

Das Modul `Services.cs` deaktiviert verschiedene Windows-Dienste, die auf vielen Systemen nicht benötigt werden.

Unter anderem:

- Xbox-Dienste
- Datenerfassungsdienste
- Netzwerkdienste
- Veraltete Protokolle
- Virtualisierungsdienste

### Autostart

Das Modul `AutomaticStartupApps.cs` verwaltet die Autostart-Einträge.

Aktuell bleibt nur:

- SecurityHealthSystray

Alle anderen Einträge werden deaktiviert.

### Administratorrechte

Das Modul `AskAdminPermissions.cs` überprüft beim Start, ob die Anwendung mit Administratorrechten ausgeführt wird.

Falls dies nicht der Fall ist, startet sich die Anwendung automatisch mit einer UAC-Abfrage neu.

## Projektstruktur

```text
WindowsDebloater/
├── App.xaml
├── App.xaml.cs
├── GUI/
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs
└── Core/
    ├── Animationen.cs
    ├── Ads.cs
    ├── DataProtection.cs
    ├── Services.cs
    ├── AutomaticStartupApps.cs
    └── AdminHelper.cs
````

## Oberfläche

Die Benutzeroberfläche basiert auf WPF und ist in verschiedene Kategorien aufgeteilt:

* Animationen
* Datenschutz
* Werbung
* Dienste
* Autostart-Apps

Alle Optionen werden über Checkboxen gesteuert.

Mit dem Button **Anwenden** werden die ausgewählten Optimierungen ausgeführt.

## Technische Umsetzung

WindowsDebloater verwendet hauptsächlich:

* C#
* WPF
* .NET 10.0
* Registry-Anpassungen
* PowerShell-Befehle

Registry-Änderungen werden über `reg add` ausgeführt.

Windows-Dienste werden über PowerShell mit `Stop-Service` und `Set-Service` deaktiviert.

## Geplante Erweiterungen

Folgende Funktionen sind für zukünftige Versionen geplant:

* Profile (Gaming, Work, Privacy, Developer)
* Eigene Profile speichern und laden
* JSON-Import und Export
* Benchmark-Bereich
* Systemanalyse
* Statusübersicht aller Optimierungen
* Verbesserte Benutzeroberfläche
* Weitere Optimierungsmodule

## Mitwirkende

**Autor:** PantriMasi

## Lizenz

Dieses Projekt wurde als Ausbildungs- und Lernprojekt entwickelt.

function Disable-Animations {
    # ------------------------------------------------------------------------- Standard Stuff
    # Menü-Verzögerung
    reg add "HKCU\Control Panel\Desktop" /v MenuShowDelay /t REG_SZ /d "0" /f

    # Taskleisten-Animationen
    reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v TaskbarAnimations /t REG_DWORD /d 0 /f


    # ------------------------------------------------------------------------- Alles andere
    # Globaler Hauptschalter
    reg add "HKCU\Control Panel\Accessibility" /v DynamicScrollbars /t REG_DWORD /d 0 /f

    # Leistungsmodus
    reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects" /v VisualFXSetting /t REG_DWORD /d 2 /f

    # Globaler Performance-Filter
    reg add "HKCU\Control Panel\Desktop" /v UserPreferencesMask /t REG_BINARY /d 9012028010000000 /f

    # Fenster-Animationen
    reg add "HKCU\Control Panel\Desktop\WindowMetrics" /v MinAnimate /t REG_SZ /d "0" /f

    # Fenster-Inhalt
    reg add "HKCU\Control Panel\Desktop" /v DragFullWindows /t REG_SZ /d "0" /f

    # Transparenz
    reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize" /v EnableTransparency /t REG_DWORD /d 0 /f

    # Aero-Peek
    reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v DisablePreviewWindow /t REG_DWORD /d 1 /f

    # Startmenü-Animation
    reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Search" /v SearchboxInTaskbarMode /t REG_DWORD /d 1 /f

    # Touch-Feedback
    reg add "HKCU\Control Panel\Desktop" /v TouchPredictionLatency /t REG_DWORD /d 0 /f

    # Bildschirm-Umschaltung
    reg add "HKLM\SOFTWARE\Microsoft\Windows\Dwm" /v ForceDisableModeChangeAnimation /t REG_DWORD /d 1 /f

    # Explorer Neustart
    Stop-Process -Name explorer -Force
}

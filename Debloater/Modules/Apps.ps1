function Remove-EdgeForcefully {
    $EdgeInstallerPath = Get-ChildItem -Path "$env:ProgramFiles (x86)\Microsoft\Edge\Application" -Filter "setup.exe" -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1 -ExpandProperty FullName

    # 2. Prüfen, ob die setup.exe gefunden wurde
    if ($EdgeInstallerPath) {
        Write-Host "[Apps] Microsoft Edge Installer gefunden unter: $EdgeInstallerPath"
        Write-Host "[Apps] Deinstallation wird gestartet..."

        # 3. Offiziellen Microsoft-Uninstaller mit Force-Argumenten ausführen
        $Arguments = "--uninstall --system-level --force-uninstall"
        $Process = Start-Process -FilePath $EdgeInstallerPath -ArgumentList $Arguments -NoNewWindow -PassThru -Wait

        # 4. Überprüfen, ob der Prozess erfolgreich war
        if ($Process.ExitCode -eq 0) {
            Write-Host "[Apps] Microsoft Edge wurde erfolgreich entfernt :)"
        } else {
            Write-Host "[Apps] Fehler bei der Deinstallation. ExitCode: $($Process.ExitCode)"
        }
    } else {
        Write-Host "[Apps] Microsoft Edge Installer konnte nicht gefunden werden (bereits deinstalliert?)."
    }
}

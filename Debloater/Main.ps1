# ------------------------------------------------------------------------- Admin Auto-Relaunch
$IsAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

if (-not $IsAdmin) {
    Write-Host "Hole Administrator-Rechte..."
    Start-Process powershell.exe -ArgumentList "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs
    Exit
}

# ------------------------------------------------------------------------- Ab hier läuft das Skript als Admin


. "$PSScriptRoot\Modules\Privacy.ps1"
. "$PSScriptRoot\Modules\Ads.ps1"
. "$PSScriptRoot\Modules\Apps.ps1"
. "$PSScriptRoot\Modules\Services.ps1"
. "$PSScriptRoot\Modules\Animations.ps1"

Write-Host "Applying privacy settings..."
Disable-Privacy

Write-Host "Disabling ads..."
Disable-Ads

Write-Host "Removing Edge..."
Remove-EdgeForcefully

Write-Host "Disabling unnecessary services..."
Disable-UselessServices

Write-Host "Disabling animations..." -ForegroundColor Cyan
Disable-Animations

Write-Host "Done"
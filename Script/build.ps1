<#
    .SYNOPSIS
        Builds project.
#>

{
  $scriptDir = $PSScriptRoot
  $projectDir = Join-Path $scriptDir "..\Src\Qamur.Chatwork"
  $cleanScript = Join-Path $scriptDir "clean.ps1"
  Invoke-Expression "powershell $cleanScript"
  Invoke-Expression "dotnet build --configuration Release $projectDir"

}.Invoke()

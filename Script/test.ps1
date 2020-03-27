<#
    .SYNOPSIS
        Runs tests.
#>

{
    $scriptDir = $PSScriptRoot
    $testProjectDir = Join-Path $scriptDir "..\Src\Qamur.Chatwork.Test"
    $cleanScript = Join-Path $scriptDir "clean.ps1"
    $binDir = Join-Path $testProjectDir "bin"
    $objDir = Join-Path $testProjectDir "obj"

    Invoke-Expression "powershell $cleanScript"

    if (Test-Path $binDir)
    {
        Remove-Item -Path $binDir -Recurse
    }

    if (Test-Path $objDir)
    {
        Remove-Item -Path $objDir -Recurse
    }

    Invoke-Expression "dotnet test $testProjectDir"

}.Invoke();

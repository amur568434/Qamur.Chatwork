<#
    .SYNOPSIS
        Cleans project.
#>

{
    $scriptDir = $PSScriptRoot
    $projectDir = Join-Path $scriptDir "..\Src\Qamur.Chatwork"
    $binDir = Join-Path $projectDir "bin"
    $objDir = Join-Path $projectDir "obj"

    if (Test-Path $binDir)
    {
        Remove-Item -Path $binDir -Recurse
    }

    if (Test-Path $objDir)
    {
        Remove-Item -Path $objDir -Recurse
    }

}.Invoke()

<#

.PARAMETER Script
The build script to execute.
.PARAMETER Target
The build script target to run.

#>

[CmdletBinding()]
Param(
    [string]$Script = "build.cake",
	[ValidateSet("Default", "UnitTest", "NuGetPack")]
    [string]$Target
)

$ErrorActionPreference = 'Stop'

Set-Location -LiteralPath $PSScriptRoot

$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
$env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
$env:DOTNET_NOLOGO = '1'

dotnet tool restore
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

# Build Cake arguments
$cakeArguments = @("$Script");
if ($Target) { $cakeArguments += "--target=$Target" }

# Start Cake
Write-Host "Running build script..."
dotnet cake $cakeArguments
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

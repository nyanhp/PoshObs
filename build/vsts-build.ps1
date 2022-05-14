<#
This script publishes the module to the gallery.
It expects as input an ApiKey authorized to publish the module.

Insert any build steps you may need to take before publishing it here.
#>
param (
	$ApiKey,
	
	$WorkingDirectory,
	
	$Repository = 'PSGallery',
	
	[switch]
	$LocalRepo,
	
	[switch]
	$SkipPublish,
	
	[switch]
	$AutoVersion
)

#region Handle Working Directory Defaults
if (-not $WorkingDirectory)
{
	if ($env:RELEASE_PRIMARYARTIFACTSOURCEALIAS)
	{
		$WorkingDirectory = Join-Path -Path $env:SYSTEM_DEFAULTWORKINGDIRECTORY -ChildPath $env:RELEASE_PRIMARYARTIFACTSOURCEALIAS
	}
	else { $WorkingDirectory = $env:SYSTEM_DEFAULTWORKINGDIRECTORY }
}
if (-not $WorkingDirectory) { $WorkingDirectory = Split-Path $PSScriptRoot }
#endregion Handle Working Directory Defaults

# Prepare publish folder
Write-Host "Creating and populating publishing directory"
$publishDir = New-Item -Path $WorkingDirectory -Name publish -ItemType Directory -Force
Copy-Item -Path "$($WorkingDirectory)\PoshObs" -Destination $publishDir.FullName -Recurse -Force
$theModule = Import-PowerShellDataFile -Path "$($publishDir.FullName)\PoshObs\PoshObs.psd1"

#region Updating the Module Version
if ($AutoVersion)
{
	Write-Host  "Updating module version numbers."
	try { [version]$remoteVersion = (Find-Module 'PoshObs' -Repository $Repository -ErrorAction Stop -AllowPrerelease:$(-not [string]::IsNullOrWhiteSpace($theModule.PrivateData.PSData.Prerelease))).Version -replace '-\w+' }
	catch
	{
		throw "Failed to access $($Repository) : $_"
	}
	if (-not $remoteVersion)
	{
		throw "Couldn't find PoshObs on repository $($Repository) : $_"
	}
	$newBuildNumber = $remoteVersion.Build + 1
	[version]$localVersion = $theModule.ModuleVersion
	Update-ModuleManifest -Path "$($publishDir.FullName)\PoshObs\PoshObs.psd1" -ModuleVersion "$($localVersion.Major).$($localVersion.Minor).$($newBuildNumber)"
}
#endregion Updating the Module Version

#region Publish
if ($SkipPublish) { return }
if ($LocalRepo)
{
	# Dependencies must go first
	Write-Host  "Creating Nuget Package for module: PSFramework"
	New-PSMDModuleNugetPackage -ModulePath (Get-Module -Name PSFramework).ModuleBase -PackagePath .
	Write-Host  "Creating Nuget Package for module: PoshObs"
	New-PSMDModuleNugetPackage -ModulePath "$($publishDir.FullName)\PoshObs" -PackagePath .
}
else
{
	# Publish to Gallery
	Write-Host  "Publishing the PoshObs module to $($Repository)"
	Publish-Module -Path "$($publishDir.FullName)\PoshObs" -NuGetApiKey $ApiKey -Force -Repository $Repository
}
#endregion Publish
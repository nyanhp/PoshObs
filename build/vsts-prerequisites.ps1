param (
    [string]
    $Repository = 'PSGallery'
)

$modules = @("Pester", "PSScriptAnalyzer", 'PlayPs')

# Automatically add missing dependencies
$data = Import-PowerShellDataFile -Path "$PSScriptRoot\..\PoshObs\PoshObs.psd1"
foreach ($dependency in $data.RequiredModules) {
    if ($dependency -is [string]) {
        if ($modules -contains $dependency) { continue }
        $modules += $dependency
    }
    else {
        if ($modules -contains $dependency.ModuleName) { continue }
        $modules += $dependency.ModuleName
    }
}

foreach ($module in $modules) {
    Write-Host "Installing $module" -ForegroundColor Cyan
    Install-Module $module -Force -SkipPublisherCheck -Repository $Repository
    Import-Module $module -Force -PassThru
}

dotnet build "$PSScriptRoot\..\lib\PoshObsNet.csproj"
dotnet publish "$PSScriptRoot\..\lib\PoshObsNet.csproj" -o "$PSScriptRoot\..\PoshObs"
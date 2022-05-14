@{

    # Script module or binary module file associated with this manifest.
    RootModule           = 'PoshObsNet.dll'

    # Version number of this module.
    ModuleVersion        = '1.0.0'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # ID used to uniquely identify this module
    GUID                 = '5d5dced8-cd1a-45fa-a564-c82d74c47859'

    # Author of this module
    Author               = 'Jan-Hendrik Peters'

    # Company or vendor of this module
    CompanyName          = 'Jan-Hendrik Peters'

    # Copyright statement for this module
    Copyright            = '(c) Jan-Hendrik Peters. All rights reserved.'

    # Description of the functionality provided by this module
    Description          = 'PowerShell module to manage OBS'

    # Minimum version of the PowerShell engine required by this module
    PowerShellVersion    = '5.1'

    # Name of the PowerShell host required by this module
    # PowerShellHostName = ''

    # Minimum version of the PowerShell host required by this module
    # PowerShellHostVersion = ''

    # Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
    # DotNetFrameworkVersion = ''

    # Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
    # ClrVersion = ''

    # Processor architecture (None, X86, Amd64) required by this module
    # ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    # RequiredModules = @()

    # Assemblies that must be loaded prior to importing this module
    # RequiredAssemblies = @()

    # Script files (.ps1) that are run in the caller's environment prior to importing this module.
    # ScriptsToProcess = @()

    # Type files (.ps1xml) to be loaded when importing this module
    # TypesToProcess = @()

    # Format files (.ps1xml) to be loaded when importing this module
    # FormatsToProcess = @()

    # Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
    # NestedModules = @()

    # Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
    FunctionsToExport    = @( )

    # Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
    CmdletsToExport      = @(
        'Add-POFilterToSource',
        'Add-POSceneItem',
        'Connect-POWebSocket',
        'Copy-POSceneItem',
        'Disable-POAudioTrack',
        'Disable-PODStudioMode',
        'Disable-POMute',
        'Disconnect-POWebSocket',
        'Enable-POAudioTrack',
        'Enable-POMute',
        'Enable-POStudioMode',
        'Get-POAudioActive',
        'Get-POAudioMonitorType',
        'Get-POAudioTracks',
        'Get-POCurrentProfile',
        'Get-POCurrentScene',
        'Get-POCurrentSceneCollection',
        'Get-POCurrentTransition',
        'Get-POFilenameFormatting',
        'Get-POMediaDuration',
        'Get-POMediaSource',
        'Get-POMediaSourceSettings',
        'Get-POMediaState',
        'Get-POMediaTime',
        'Get-POMute',
        'Get-POOutput',
        'Get-POPreviewScene',
        'Get-POProfile',
        'Get-PORecordingFolder',
        'Get-PORecordingStatus',
        'Get-POReplayBufferStatus',
        'Get-POScene',
        'Get-POSceneCollection',
        'Get-POSceneItem',
        'Get-POSceneItemProperties',
        'Get-POSceneTransitionOverride',
        'Get-POSource',
        'Get-POSourceActive',
        'Get-POSourceDefaultSettings',
        'Get-POSourceFilter',
        'Get-POSourceFilterInfo',
        'Get-POSourceSettings',
        'Get-POSourceType',
        'Get-POSpecialSource',
        'Get-POStatistic',
        'Get-POStreamingStatus',
        'Get-POStreamSettings',
        'Get-POStudioModeStatus',
        'Get-POSyncOffset',
        'Get-POTextGDIPlusProperties',
        'Get-POTransition',
        'Get-POTransitionDuration',
        'Get-POTransitionPosition',
        'Get-POTransitionSettings',
        'Get-POVersion',
        'Get-POVideoInfo',
        'Get-POVirtualCamStatus',
        'Get-POVolume',
        'Move-POSourceFilter',
        'New-POScene',
        'New-POSource',
        'Open-POProjector',
        'Remove-POFilterFromSource',
        'Remove-POSceneItem',
        'Remove-POSceneTransitionOverride',
        'Reset-POSceneItem',
        'Restart-POMedia',
        'Save-POReplayBuffer',
        'Save-POSourceScreenshot',
        'Save-POStreamSettings',
        'Set-POAudioMonitorType',
        'Set-POCurrentProfile',
        'Set-POCurrentScene',
        'Set-POCurrentSceneCollection',
        'Set-POCurrentTransition',
        'Set-POFilenameFormatting',
        'Set-POMediaSourceSettings',
        'Set-POMediaTime',
        'Set-POPreviewScene',
        'Set-PORecordingFolder',
        'Set-POSceneItemOrder',
        'Set-POSceneItemProperties',
        'Set-POSceneTransitionOverride',
        'Set-POSourceFilterOrder',
        'Set-POSourceFilterSettings',
        'Set-POSourceFilterVisibility',
        'Set-POSourceName',
        'Set-POSourceRender',
        'Set-POSourceSettings',
        'Set-POStreamingSettings',
        'Set-POSyncOffset',
        'Set-POTextGDIPlusProperties',
        'Set-POTransitionDuration',
        'Set-POTransitionSettings',
        'Set-POVolume',
        'Start-POMedia',
        'Start-PONextMedia',
        'Start-POPreviousMedia',
        'Start-PORecording',
        'Start-POReplayBuffer',
        'Start-POResumeRecording',
        'Start-POStreaming',
        'Start-POTransitionToProgram',
        'Start-POVirtualCam',
        'Stop-POMedia',
        'Stop-PORecording',
        'Stop-POReplayBuffer',
        'Stop-POStreaming',
        'Stop-POVirtualCam',
        'Suspend-POMedia',
        'Suspend-PORecording',
        'Update-POBrowserSource'
    )

    # Variables to export from this module
    # VariablesToExport = '*'

    # Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
    # AliasesToExport = '*'

    # DSC resources to export from this module
    # DscResourcesToExport = @()

    # List of all modules packaged with this module
    # ModuleList = @()

    # List of all files packaged with this module
    # FileList = @()

    # Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
    PrivateData          = @{

        PSData = @{

            # Tags applied to this module. These help with module discovery in online galleries.
            Tags       = @('OBS', 'Streaming')

            # A URL to the license for this module.
            LicenseUri = 'https://raw.githubusercontent.com/nyanhp/PoshObs/main/LICENSE'

            # A URL to the main website for this project.
            ProjectUri = 'https://github.com/nyanhp/PoshObs'

            # A URL to an icon representing this module.
            IconUri    = 'https://raw.githubusercontent.com/nyanhp/PoshObs/main/assets/BeardlessIcon.jpg'

            # ReleaseNotes of this module
            # ReleaseNotes = ''

            # Prerelease string of this module
            Prerelease = 'alpha1'

            # Flag to indicate whether the module requires explicit user acceptance for install/update/save
            # RequireLicenseAcceptance = $false

            # External dependent modules of this module
            # ExternalModuleDependencies = @()

        } # End of PSData hashtable

    } # End of PrivateData hashtable

    # HelpInfo URI of this module
    # HelpInfoURI = ''

    # Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
    # DefaultCommandPrefix = ''

}


# PoshObs

This project wraps cmdlets around obs-websocket-dotnet to interact with OBS using PowerShell 5+.

## Installation and usage

To install the module, please use the PowerShell Gallery. At some point I'll also package a release,
but I hardly see the point.

```powershell
# Install
Install-Module -Repository PSGallery -Scope CurrentUser -Name PoshObs # -AllowPrerelease to get the GOOD STUFF

# Connect
Connect-POWebSocket -Uri ws://127.0.0.1:4444 -Credential (Get-Credential)

# Use!
Get-POCurrentScene
Set-POCurrentScene -Name Michael.MICHAEL!
Start-POVirtualCam

# Now join that boring team meeting ;)
```

## Build it yourself

Using the .NET Core SDK you can build that project your self. Why? Because I've gone
the easy route and implemented a bunch of C# cmdlets instead of writing PowerShell functions.

```powershell
./build/vsts-prerequisites.ps1
./build/vsts-build.ps1 -SkipPublish
```

## Requirements

- OBS with WebSocket plugin configured and enabled
- PowerShell 5 and newer
- An overwhelming urge to automate the crap out of things

## NuGet packages used

Licenses apply and so on.

- [PowerShellStandard.Library](https://github.com/PowerShell/PowerShellStandard)
- [obs-websocket-dotnet](https://github.com/BarRaider/obs-websocket-dotnet)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [WebSocketSharp](https://sta.github.io/websocket-sharp)
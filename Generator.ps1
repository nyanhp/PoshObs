# Scaffolding
$root = 'C:\Users\janhe\source\repos\PoshObs\lib\Cmdlets'
Add-Type -Path "C:\Users\janhe\.nuget\packages\obs-websocket-dotnet\4.9.1\lib\netstandard2.0\obs-websocket-dotnet.dll"
Add-Type -path "C:\Users\janhe\.nuget\packages\websocketsharp-netstandard\1.0.1\lib\netstandard2.0\websocket-sharp.dll"

$wbs = [OBSWebsocketDotNet.OBSWebsocket]::new()
$meth = $wbs | Get-Member -MemberType Method

foreach ($method in $meth)
{
    $paramText = foreach ($param in ($method.Definition -replace '(.*\(|\))' -split ','))
    {
        $typeName = ($param.Trim() -split '\s')[0]
        $paramName = ($param.Trim() -split '\s')[1]
        if ([string]::IsNullOrWhiteSpace($typeName) -or [string]::IsNullOrWhiteSpace($paramName)) { continue }
        "        [Parameter(Mandatory = true)]`r`n        public $typeName $paramName {get; set;}`r`n"
    }

    $text = @"
using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "PO$($method.Name)")]
    public class $($method.Name)Cmdlet : Cmdlet
    {
$paramText
        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.$($method.Name)();
        }
    }
}

"@

    $text | Set-Content -Path (Join-Path $root -ChildPath "$($Method.Name)Cmdlet.cs") -Encoding utf8nobom
}
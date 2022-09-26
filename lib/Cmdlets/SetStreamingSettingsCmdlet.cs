using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "POStreamingSettings")]
    public class SetStreamingSettingsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public OBSWebsocketDotNet.Types.StreamingService Service { get; set; }
        [Parameter(Mandatory = true)]
        public SwitchParameter Save { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetStreamServiceSettings(Service);
        }
    }
}


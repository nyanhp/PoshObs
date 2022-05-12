using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POSetStreamSettings")]
    public class SetStreamSettingsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public OBSWebsocketDotNet.Types.StreamingService service {get; set;}
         [Parameter(Mandatory = true)]
        public bool save {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetStreamSettings();
        }
    }
}


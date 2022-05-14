using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Move, "POSourceFilter")]
    public class MoveSourceFilterCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        public string FilterName { get; set; }
        [Parameter(Mandatory = true)]
        public OBSWebsocketDotNet.Types.FilterMovementType MovementType { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.MoveSourceFilter(Name, FilterName, MovementType);
        }
    }
}


using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Open, "POProjector")]
    public class OpenProjectorCmdlet : Cmdlet
    {
        [Parameter()]
        public int Monitor { get; set; }
        [Parameter()]
        public string Geometry { get; set; }
        [Parameter()]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.OpenSourceProjector(Name, Geometry, Monitor);
        }
    }
}


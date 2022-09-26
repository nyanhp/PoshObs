using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "POSourceFilterName")]
    public class SetSourceNameCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string SourceName { get; set; }
        [Parameter(Mandatory = true)]
        public string FilterName { get; set; }
        [Parameter(Mandatory = true)]
        public string NewName { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetSourceFilterName(SourceName, FilterName, NewName);
        }
    }
}


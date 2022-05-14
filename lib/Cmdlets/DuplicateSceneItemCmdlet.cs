using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Copy, "POSceneItem")]
    public class DuplicateSceneItemCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("Source")]
        public string SourceSceneName { get; set; }
        [Parameter(Mandatory = true)]
        [Alias("Destination")]
        public string DestinationSceneName { get; set; }
        [Parameter(Mandatory = true)]
        public int ItemID { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.DuplicateSceneItem(SourceSceneName,DestinationSceneName,ItemID);
        }
    }
}


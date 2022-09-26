using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "POSceneItem")]
    public class DeleteSceneItemCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public int ItemId { get; set; }
        [Parameter(Mandatory = true)]
        public string SceneName { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.RemoveSceneItem(SceneName, ItemId);
        }
    }
}


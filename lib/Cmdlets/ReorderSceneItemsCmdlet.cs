using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POReorderSceneItems")]
    public class ReorderSceneItemsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public System.Collections.Generic.List[OBSWebsocketDotNet.Types.SceneItemStub] sceneItems {get; set;}
         [Parameter(Mandatory = true)]
        public string sceneName {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.ReorderSceneItems();
        }
    }
}


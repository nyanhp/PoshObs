using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POSetSceneItemTransform")]
    public class SetSceneItemTransformCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string itemName {get; set;}
         [Parameter(Mandatory = true)]
        public float rotation {get; set;}
         [Parameter(Mandatory = true)]
        public float xScale {get; set;}
         [Parameter(Mandatory = true)]
        public float yScale {get; set;}
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

            ObsConnection.Instance.Connection.SetSceneItemTransform();
        }
    }
}


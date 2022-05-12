using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POCreateSource")]
    public class CreateSourceCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string sourceName {get; set;}
         [Parameter(Mandatory = true)]
        public string sourceKind {get; set;}
         [Parameter(Mandatory = true)]
        public string sceneName {get; set;}
         [Parameter(Mandatory = true)]
        public Newtonsoft.Json.Linq.JObject sourceSettings {get; set;}
         [Parameter(Mandatory = true)]
        public System.Nullable[bool] setVisible {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.CreateSource();
        }
    }
}


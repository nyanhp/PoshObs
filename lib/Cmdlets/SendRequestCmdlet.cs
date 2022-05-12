using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POSendRequest")]
    public class SendRequestCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string requestType {get; set;}
         [Parameter(Mandatory = true)]
        public Newtonsoft.Json.Linq.JObject additionalFields {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.SendRequest();
        }
    }
}


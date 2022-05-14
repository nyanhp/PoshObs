using System;
using System.Collections;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "POSource")]
    public class CreateSourceCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        public string Kind { get; set; }
        [Parameter(Mandatory = true)]
        public string SceneName { get; set; }
        [Parameter(Mandatory = true)]
        public Hashtable Settings { get; set; }
        [Parameter(Mandatory = true)]
        bool Visible { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.CreateSource(Name, Kind, SceneName, Newtonsoft.Json.Linq.JObject.FromObject(Settings), Visible);
        }
    }
}


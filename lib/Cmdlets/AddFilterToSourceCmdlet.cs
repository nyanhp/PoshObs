using System;
using System.Collections;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Add, "POFilterToSource")]
    public class AddFilterToSourceCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string SourceName { get; set; }
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        public string Type { get; set; }
        [Parameter(Mandatory = true)]
        public Hashtable Settings { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.AddFilterToSource(SourceName, Name, Type, Newtonsoft.Json.Linq.JObject.FromObject(Settings));
        }
    }
}


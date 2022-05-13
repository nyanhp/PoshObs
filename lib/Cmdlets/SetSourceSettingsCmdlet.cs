using System;
using System.Collections;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "POSourceSettings")]
    public class SetSourceSettingsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string SourceName { get; set; }
        [Parameter(Mandatory = true)]
        public Hashtable Settings { get; set; }
        [Parameter(Mandatory = true)]
        public string SourceType { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetSourceSettings(SourceName, Newtonsoft.Json.Linq.JObject.FromObject(Settings), SourceType);
        }
    }
}


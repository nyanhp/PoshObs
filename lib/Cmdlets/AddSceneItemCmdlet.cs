using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Add, "POSceneItem")]
    public class AddSceneItemCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string SceneName { get; set; }
        [Parameter(Mandatory = true)]
        public string SourceName { get; set; }
        [Parameter(Mandatory = true)]
        public bool Visible { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.AddSceneItem(SceneName, SourceName, Visible);
        }
    }
}


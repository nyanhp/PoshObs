using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POPlayPauseMedia")]
    public class PlayPauseMediaCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string sourceName {get; set;}
         [Parameter(Mandatory = true)]
        public System.Nullable[bool] playPause {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.PlayPauseMedia();
        }
    }
}


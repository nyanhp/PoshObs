using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POTransitionToProgram")]
    public class TransitionToProgramCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public int transitionDuration {get; set;}
         [Parameter(Mandatory = true)]
        public string transitionName {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.TransitionToProgram();
        }
    }
}


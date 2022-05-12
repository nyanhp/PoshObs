using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "POSetSceneTransitionOverride")]
    public class SetSceneTransitionOverrideCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string sceneName {get; set;}
         [Parameter(Mandatory = true)]
        public string transitionName {get; set;}
         [Parameter(Mandatory = true)]
        public int transitionDuration {get; set;}

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetSceneTransitionOverride();
        }
    }
}


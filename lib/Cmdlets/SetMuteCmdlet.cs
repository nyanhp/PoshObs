using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Enable, "POMute")]
    public class EnableMuteCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetMute(Name, true);
        }
    }

    [Cmdlet(VerbsLifecycle.Disable, "POMute")]
    public class DisableMuteCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetMute(Name, false);
        }
    }
}


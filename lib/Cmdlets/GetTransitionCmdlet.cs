using System;
using System.Linq;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "POTransition")]
    public class GetTransitionCmdlet : Cmdlet
    {
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
        }

        protected override void ProcessRecord()
        {
            foreach (var transition in ObsConnection.Instance.Connection.GetSceneTransitionList().Transitions)
            {
                if (! string.IsNullOrWhiteSpace(Name) && ! transition.Name.Equals(Name)) { continue; }
                WriteObject(transition);
            }
        }
    }
}


using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "POTransition")]
    public class GetTransitionListCmdlet : Cmdlet
    {
        [Parameter()]
        public SwitchParameter NameOnly {get; set;}
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
            if (NameOnly.IsPresent)
            {
                WriteObject(ObsConnection.Instance.Connection.ListTransitions());
                return;
            }
            WriteObject(ObsConnection.Instance.Connection.GetTransitionList());
        }
    }
}


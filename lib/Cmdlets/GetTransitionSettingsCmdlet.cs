using System;
using System.Linq;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "POTransitionSettings")]
    public class GetTransitionSettingsCmdlet : Cmdlet
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
        }

        protected override void ProcessRecord()
        {
            var transition = ObsConnection.Instance.Connection.GetSceneTransitionList().Transitions.First(trans => trans.Name.Equals(Name));
            WriteObject(transition.Settings);
        }
    }
}


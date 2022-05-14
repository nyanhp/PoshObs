using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "POSourceSettings")]
    public class GetSourceSettingsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        public string Type { get; set; }

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

            WriteObject(ObsConnection.Instance.Connection.GetSourceSettings(Name, Type));
        }
    }
}


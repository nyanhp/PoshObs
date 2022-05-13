using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "POSourceDefaultSettings")]
    public class GetSourceDefaultSettingsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Kind { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(ObsConnection.Instance.Connection.GetSourceDefaultSettings(Kind));
        }
    }
}


using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommunications.Connect, "POWebSocket")]
    public class ConnectObsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Uri { get; set; }

        [Parameter()]
        public PSCredential Credential { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose($"Attempting to open connection to web socket at {Uri}");
            try
            {
                ObsConnection.Instance.Connect(Uri, Credential);
            }
            catch (Exception obsExc)
            {
                var record = new ErrorRecord(obsExc, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"Unable to connect to {Uri}.");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
            }
        }
    }
}

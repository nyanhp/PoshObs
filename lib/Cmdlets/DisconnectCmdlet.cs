using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommunications.Disconnect, "POWebSocket")]
    public class DisconnectCmdlet : Cmdlet
    {

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                WriteVerbose("Already disconnected");
                return;
            }

            ObsConnection.Instance.Connection.Disconnect();
        }
    }
}


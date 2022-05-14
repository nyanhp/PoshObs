using System;
using System.Management.Automation;
using OBSWebsocketDotNet.Types;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "POSceneItemProperties")]
    public class SetSceneItemPropertiesCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        SceneItemProperties Properties { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            ObsConnection.Instance.Connection.SetSceneItemProperties(Properties, Name);
        }
    }
}


using System;
using System.Management.Automation;
using PoshObsNet.Data;
using System.Linq;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "POPreviewScene")]
    public class SetPreviewSceneCmdlet : Cmdlet
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

            var scene = ObsConnection.Instance.Connection.GetSceneList().Scenes.First(sc => sc.Name.Equals(Name));
            ObsConnection.Instance.Connection.SetPreviewScene(scene);
        }
    }
}


using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Open, "POProjector")]
    public class OpenProjectorCmdlet : Cmdlet
    {
        private string type = "Preview";
        private int monitor = -1;

        [Parameter()]
        [ValidateSet("Preview", "Source", "Scene", "StudioProgram", "Multiview")]
        public string Type { get => type; set => type = value; }
        [Parameter()]
        public int Monitor { get => monitor; set => monitor = value; }
        [Parameter()]
        public string Geometry { get; set; }
        [Parameter()]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                WriteError(record);
                return;
            }

            ObsConnection.Instance.Connection.OpenProjector(Type, Monitor, Geometry, Name);
        }
    }
}


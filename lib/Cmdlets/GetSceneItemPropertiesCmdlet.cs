using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "POSceneItemProperties")]
    public class GetSceneItemPropertiesCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ItemName")]
        public string Name {get; set;}
         [Parameter(Mandatory = true)]
        public string SceneName {get; set;}
        public SwitchParameter AsJson { get; set; }

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
            if (AsJson.IsPresent)
            {
                WriteObject(ObsConnection.Instance.Connection.GetSceneItemPropertiesJson(Name, SceneName));
            }
            else
            {
                WriteObject(ObsConnection.Instance.Connection.GetSceneItemProperties(Name, SceneName));
            }
        }
    }
}


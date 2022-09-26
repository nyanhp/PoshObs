using System;
using System.Management.Automation;
using PoshObsNet.Data;

namespace PoshObsNet.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Enable, "POAudioTrack")]
    public class EnableAudioTrackCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        public int TrackNumber { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            var tracks = ObsConnection.Instance.Connection.GetInputAudioTracks(Name);
            switch (TrackNumber)
            {
                case 1: { tracks.IsTrack1Active = false; break; }
                case 2: { tracks.IsTrack2Active = false; break; }
                case 3: { tracks.IsTrack3Active = false; break; }
                case 4: { tracks.IsTrack4Active = false; break; }
                case 5: { tracks.IsTrack5Active = false; break; }
                case 6: { tracks.IsTrack6Active = false; break; }
                default:
                    {

                        var exception = new System.Net.Http.HttpRequestException($"No track number {TrackNumber} found for input {Name}");
                        var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.InvalidArgument, ObsConnection.Instance);
                        ThrowTerminatingError(record);
                        return;
                    }
            }
        }
    }

    [Cmdlet(VerbsLifecycle.Disable, "POAudioTrack")]
    public class DisableAudioTrackCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true)]
        public int TrackNumber { get; set; }

        protected override void BeginProcessing()
        {
            if (!ObsConnection.Instance.Connection.IsConnected)
            {
                var exception = new System.Net.Http.HttpRequestException($"OBS WebSocket not connected");
                var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.ConnectionError, ObsConnection.Instance);
                ThrowTerminatingError(record);
                return;
            }

            var tracks = ObsConnection.Instance.Connection.GetInputAudioTracks(Name);
            switch (TrackNumber)
            {
                case 1: { tracks.IsTrack1Active = false; break; }
                case 2: { tracks.IsTrack2Active = false; break; }
                case 3: { tracks.IsTrack3Active = false; break; }
                case 4: { tracks.IsTrack4Active = false; break; }
                case 5: { tracks.IsTrack5Active = false; break; }
                case 6: { tracks.IsTrack6Active = false; break; }
                default:
                    {

                        var exception = new System.Net.Http.HttpRequestException($"No track number {TrackNumber} found for input {Name}");
                        var record = new ErrorRecord(exception, "ObsWebSocketConnectError", ErrorCategory.InvalidArgument, ObsConnection.Instance);
                        ThrowTerminatingError(record);
                        return;
                    }
            }
        }
    }
}


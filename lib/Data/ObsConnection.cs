using OBSWebsocketDotNet;
using System;
using System.Management.Automation;

namespace PoshObsNet.Data
{
    public sealed class ObsConnection
    {
        private static readonly Lazy<ObsConnection> lazy =
            new Lazy<ObsConnection>(() => new ObsConnection());

        public static ObsConnection Instance { get { return lazy.Value; } }
        public OBSWebsocket Connection { get; set; }

        private ObsConnection()
        {
            Connection = new OBSWebsocket();
        }

        public void Connect(string uri, PSCredential credential = null)
        {
            if (credential == null)
            {
                Connection.Connect(uri, String.Empty);
                return;
            }

            Connection.Connect(uri, credential.GetNetworkCredential().Password);
        }
    }
}

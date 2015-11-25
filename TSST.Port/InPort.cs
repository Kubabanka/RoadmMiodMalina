using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TSST.Messages;

namespace TSST.Port
{
    public class InPort
    {
        private BinaryReader reader;

        private bool observing;

        private string portNumber;

        public string PortNumber
        {
            get
            {
                return portNumber;
            }
            private set
            {
                portNumber = value;
            }
        }

        public event EventHandler<DataReceivedEventArgs> DataReceived;

        public InPort() { }

        public async Task Initialize(string ip, int port, string nodeId, string nodePortNumber)
        {
            var client = new TcpClient();
            await client.ConnectAsync(ip, port);
            var stream = client.GetStream();
            var writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);
            PortNumber = nodePortNumber;
            var id = string.Format("I#{0}:{1}", nodeId, nodePortNumber);
            var register = new RegisterMessage(id);
            string registerMsg = MessagesSerializer.Serialize(register, typeof(RegisterMessage));
            writer.Write(registerMsg);
            Thread observingThread = new Thread(new ThreadStart(ObserveReader));
            observing = true;
            observingThread.Start();
        }

        private void ObserveReader()
        {
            while (observing)
            {
                try
                {
                    var localReader = reader;
                    string receivedData = localReader.ReadString();
                    if (!String.IsNullOrEmpty(receivedData))
                    {
                        var dataReceivedEventHandler = DataReceived;
                        if (dataReceivedEventHandler != null && !string.IsNullOrEmpty(receivedData))
                            dataReceivedEventHandler(this, new DataReceivedEventArgs(receivedData));
                    }
                }
                catch
                {
                    observing = false;
                }
            }
        }
    }
}

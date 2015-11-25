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
    public class OutPort
    {
        private bool holding = false;
        private BinaryWriter writer;

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

        public void Initialize(string ip, int port, string nodeId, string nodePortNumber)
        {
            var client = new TcpClient();
            client.Connect(ip, port);
            var stream = client.GetStream();
            writer = new BinaryWriter(stream);
            var reader = new BinaryReader(stream);
            PortNumber = nodePortNumber;
            var id = string.Format("O#{0}:{1}", nodeId, nodePortNumber);
            var register = new RegisterMessage(id);
            string registerMsg = MessagesSerializer.Serialize(register, typeof(RegisterMessage));
            writer.Write(registerMsg);
            Thread observingThread = new Thread(new ParameterizedThreadStart(HoldConnection));
            holding = true;
            observingThread.Start(client);
        }

        public void Send(string data)
        {
            var sendingWriter = writer;
            if (sendingWriter == null)
                throw new NullReferenceException(nameof(writer));
            if (!String.IsNullOrEmpty(data))
            {
                try
                {
                    sendingWriter.Write(data);
                }
                catch
                {
                }
            }
        }

        private void HoldConnection(object obj)
        {
            var client = (TcpClient)obj;
            var stream = client.GetStream();
            var reader = new BinaryReader(stream);
            while (holding)
            {
                reader.ReadString(); 
            }
        }
    }
}

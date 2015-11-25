using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSST.Port;

namespace TSST.ROADM
{
    public class ROADM
    {
        private List<InPort> networkInPorts;
        private List<OutPort> networkOutPorts;
        private List<InPort> clientInPorts;
        private List<OutPort> clientOutPorts;

        public async Task Initialize(string configPath, string ip, int port)
        {
            var config = TSST.Configuration.ROADMConfig.GetConfiguration(configPath);
            string roadmId = config.ID;
            networkInPorts = new List<InPort>();
            networkOutPorts = new List<OutPort>();
            clientInPorts = new List<InPort>();
            clientOutPorts = new List<OutPort>();
            for (int i = 0; i < config.NetInputPorts; i++)
            {
                var inPort = new InPort();
                await inPort.Initialize(ip, port, roadmId, i.ToString());
                inPort.DataReceived += InPort_NetworkDataReceived;
                networkInPorts.Add(inPort);
            }
            for (int i = config.NetInputPorts; i < config.NetInputPorts + config.ClientInputPorts; i++)
            {
                var inPort = new InPort();
                await inPort.Initialize(ip, port, roadmId, i.ToString());
                inPort.DataReceived += InPort_ClientDataReceived;
                clientInPorts.Add(inPort);
            }
            for (int i = 0; i < config.NetOutputPorts; i++)
            {
                var outPort = new OutPort();
                outPort.Initialize(ip, port, roadmId, i.ToString());
                networkOutPorts.Add(outPort);
            }
            for (int i = config.NetOutputPorts; i < config.NetOutputPorts + config.ClientOutputPorts; i++)
            {
                var outPort = new OutPort();
                outPort.Initialize(ip, port, roadmId, i.ToString());
                clientOutPorts.Add(outPort);
            }
        }

        private void InPort_ClientDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InPort_NetworkDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            var port = clientOutPorts[20];
            port.Send("hello. Is it me U looking 4?");
        }
    }
}

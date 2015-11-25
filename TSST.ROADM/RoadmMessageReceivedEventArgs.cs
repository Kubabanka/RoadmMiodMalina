using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSST.Messages;

namespace TSST.ROADM
{
    public class RoadmMessageReceivedEventArgs: EventArgs
    {
        private string port;
        public string Port
        {
            get
            {
                return port;
            }
        }

        private ROADMMessage data;
        public ROADMMessage Data
        {
            get
            {
                return data;
            }
        }

        public RoadmMessageReceivedEventArgs(string port, ROADMMessage data)
        {
            this.port = port;
            this.data = data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.ROADM
{
    public class ClientMessageReceivedEventArgs: EventArgs
    {
        private string port;
        public string Port
        {
            get
            {
                return port;
            }
        }

        private string data;
        public string Data
        {
            get
            {
                return data;
            }
        }

        public ClientMessageReceivedEventArgs(string port, string data)
        {
            this.port = port;
            this.data = data;
        }
    }
}

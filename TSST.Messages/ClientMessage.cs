using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.Messages
{
    public class ClientMessage
    {
        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public ClientMessage() { }
        public ClientMessage(string data)
        {
            Data = data;
        }
    }
}

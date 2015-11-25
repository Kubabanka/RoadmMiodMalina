using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.Port
{
    public class DataReceivedEventArgs : EventArgs
    {
        private string data;

        public string Data { get { return data; } }

        public DataReceivedEventArgs(string data)
        {
            this.data = data;
        }

    }
}

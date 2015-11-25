using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSST.Messages
{
    public class RegisterMessage
    {
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public RegisterMessage(){}
        public RegisterMessage(string id)
        {
            this.Id = id;
        }
    }
}

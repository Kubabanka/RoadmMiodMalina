using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TSST.Configuration
{
    public class ROADMConfig
    {
        public string ID;
        public int ClientInputPorts;
        public int ClientOutputPorts;
        public int NetInputPorts;
        public int NetOutputPorts;

        public ROADMConfig()
        {
            ID = string.Empty;
            ClientInputPorts = 0;
            ClientOutputPorts = 0;
            NetInputPorts = 0;
            NetOutputPorts = 0;
        }

        public static ROADMConfig GetConfiguration(string name)
        {
            ROADMConfig con = new ROADMConfig();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(name);
            XmlSerializer ser = new XmlSerializer(con.GetType());
            return (ROADMConfig)ser.Deserialize(new StringReader(xmlDoc.InnerXml));
        }




    }
}

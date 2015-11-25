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
    public class ClientNodeConfig
    {
        public string ID;
        public int InputPorts;
        public int OutputPorts;

        public ClientNodeConfig()
        {
            ID = string.Empty;
            InputPorts = 0;
            OutputPorts = 0;
        }

        public static ClientNodeConfig GetConfiguration(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(name);
            XmlSerializer ser = new XmlSerializer(typeof(ROADMConfig));
            return (ClientNodeConfig)ser.Deserialize(new StringReader(xmlDoc.InnerXml));
        }




    }
}

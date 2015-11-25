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
    public class LinkConfig
    {
        public string SourceID;
        public string DestinationID;
        public int SourcePort;
        public int DestinationPort;

        public LinkConfig()
        {
            SourceID = string.Empty;
            DestinationID = string.Empty;
            SourcePort = 0;
            DestinationPort = 0;
        }

        public static List<LinkConfig> GetConfiguration(string name)
        {
            List<LinkConfig> con = new List<LinkConfig>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(name);
            XmlSerializer ser = new XmlSerializer(con.GetType());
            return (List<LinkConfig>)ser.Deserialize(new StringReader(xmlDoc.InnerXml));
        }
    }
}

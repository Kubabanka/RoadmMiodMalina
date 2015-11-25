using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TSST.Messages
{
    public static class MessagesSerializer
    {
        public static object Deserialize(string message, Type messageType)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));
            if (messageType == null)
                throw new ArgumentNullException(nameof(messageType));
            var serializer = new XmlSerializer(messageType);
            return serializer.Deserialize(new StringReader(message));
        }
        public static string Serialize(object message, Type messageType)
        {
            XmlSerializer serializer = new XmlSerializer(messageType);
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
            serializer.Serialize(xmlWriter, message);
            return stringWriter.ToString();
        }
    }
}

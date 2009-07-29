using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace FlixCloud.Client
{
    public class Thumbnails : IXmlSerializable
    {
        public Thumbnails()
        {
            Parameters = new Parameters();
        }

        public string Url { get; set; }
        public string Prefix { get; set; }
        public Parameters Parameters { get; set; }

        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            //This method is not implemented because
            //this class is never deserialized by the client

            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("url", Url);
            writer.WriteElementString("prefix", Prefix);

            if (Parameters.User != null && Parameters.Password != null)
            {
                writer.WriteStartElement("parameters");
                Parameters.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}

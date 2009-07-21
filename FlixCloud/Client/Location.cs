using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    public class Location : IXmlSerializable
    {
        public Location()
        {
            Parameters = new Parameters();
        }

        public string Url;
        public Parameters Parameters;

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            //This method is not implemented because
            //this class is never deserialized by the client

            throw new NotImplementedException();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("url", Url);

            if (Parameters.User != null || Parameters.Password != null)
            {
                writer.WriteStartElement("parameters");
                Parameters.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}

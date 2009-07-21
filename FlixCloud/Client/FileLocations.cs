using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    public class FileLocations : IXmlSerializable
    {
        public FileLocations()
        {
            Input = new Location();
            Output = new Location();
            Watermark = new Location();
        }

        public Location Input;
        public Location Output;
        public Location Watermark;

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            //This method is not implemented because
            //this class is never deserialized by the client

            throw new NotImplementedException();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("input");
            Input.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteStartElement("output");
            Output.WriteXml(writer);
            writer.WriteEndElement();

            if (Watermark.Url != null)
            {
                writer.WriteStartElement("watermark");
                Watermark.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}

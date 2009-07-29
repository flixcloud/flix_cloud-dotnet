using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace FlixCloud.Client
{
    public class FileLocations : IXmlSerializable
    {
        public FileLocations()
        {
            Input = new Location();
            Output = new Location();
            Watermark = new Location();
            Thumbnails = new Thumbnails();
        }

        public Location Input { get; set; }
        public Location Output { get; set; }
        public Location Watermark { get; set; }
        public Thumbnails Thumbnails { get; set; }

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

            if (Thumbnails.Url != null)
            {
                writer.WriteStartElement("thumbnails");
                Thumbnails.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}

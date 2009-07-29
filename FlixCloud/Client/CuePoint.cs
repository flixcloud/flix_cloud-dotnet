using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace FlixCloud.Client
{
    public class CuePoint: IXmlSerializable
    {
        public CuePoint()
        {
            Parameters = new List<CuePointParameter>();
        }

        public string Name { get; set; }
        public decimal Time  { get; set; }
        public IList<CuePointParameter> Parameters { get; set; }

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
            writer.WriteElementString("name", Name);
            writer.WriteStartElement("time");
            writer.WriteValue(Time);
            writer.WriteEndElement();

            foreach (CuePointParameter parameter in Parameters)
            {
                writer.WriteStartElement("parameter");
                parameter.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}

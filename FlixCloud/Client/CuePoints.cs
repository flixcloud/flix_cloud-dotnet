using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace FlixCloud.Client
{
    public class CuePoints: IXmlSerializable
    {
        public CuePoints()
        {
            Event = new List<CuePoint>();
            Navigation = new List<CuePoint>();
        }

        public IList<CuePoint> Event { get; set; }
        public IList<CuePoint> Navigation { get; set; }

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
            if (Event.Count > 0)
            {
                writer.WriteStartElement("event");
                foreach (CuePoint point in Event)
                {
                    WriteCuePoint(point, writer);
                }
                writer.WriteEndElement();
            }
            if (Navigation.Count > 0)
            {
                writer.WriteStartElement("navigation");
                foreach (CuePoint point in Navigation)
                {
                    WriteCuePoint(point, writer);
                }
                writer.WriteEndElement();
            }
        }

        public void WriteCuePoint(CuePoint point, XmlWriter writer)
        {
            writer.WriteStartElement("cue-point");
            point.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}

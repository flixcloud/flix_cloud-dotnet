using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace FlixCloud.Client
{
    public class CuePointParameter : IXmlSerializable
    {
        public string Key { get; set; }
        public string Value { get; set; }

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
            writer.WriteElementString("key", Key);
            writer.WriteElementString("value", Value);            
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    public class Parameters : IXmlSerializable
    {
        public string User;
        public string Password;

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
            writer.WriteElementString("user", User);
            if (Password != String.Empty)
            {
                writer.WriteElementString("password", Password);
            }
        }

        #endregion
    }
}

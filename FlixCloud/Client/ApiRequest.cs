using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    [XmlRoot(ElementName = "api-request")]
    public class ApiRequest : IXmlSerializable
    {
        public ApiRequest()
        {
            Locations = new FileLocations();
        }

        public string ApiKey;
        public int? RecipeID;
        public string RecipeName;
        public FileLocations Locations;

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
            writer.WriteElementString("api-key", ApiKey);

            if (RecipeID.HasValue)
            {
                writer.WriteElementString("recipe-id", RecipeID.Value.ToString());
            }
            if (RecipeName != null)
            {
                writer.WriteElementString("recipe-name", RecipeName);
            }

            writer.WriteStartElement("file-locations");
            Locations.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}

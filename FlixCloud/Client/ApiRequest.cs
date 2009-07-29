using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace FlixCloud.Client
{
    [XmlRoot(ElementName = "api-request")]
    public class ApiRequest : IXmlSerializable
    {
        public ApiRequest()
        {
            Locations = new FileLocations();
            CuePoints = new CuePoints();
        }

        public string ApiKey { get; set; }
        public int? RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string NotificationUrl { get; set; }
        public string PassThrough { get; set; }
        public FileLocations Locations { get; set; }
        public CuePoints CuePoints { get; set; }

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
            writer.WriteElementString("api-key", ApiKey);

            if (RecipeID.HasValue)
            {
                writer.WriteElementString("recipe-id", RecipeID.Value.ToString());
            }
            if (RecipeName != null)
            {
                writer.WriteElementString("recipe-name", RecipeName);
            }
            if (NotificationUrl != null)
            {
                writer.WriteElementString("notification-url", NotificationUrl);
            }
            if (PassThrough != null)
            {
                writer.WriteElementString("pass-through", PassThrough);
            }
            if (CuePoints.Event.Count > 0 || CuePoints.Navigation.Count > 0)
            {
                writer.WriteStartElement("cue-points");
                CuePoints.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteStartElement("file-locations");
            Locations.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}

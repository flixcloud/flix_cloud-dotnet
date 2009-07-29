using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    [Serializable]
    [XmlRoot(ElementName = "errors")]
    public class JobResponseError
    {
        //[XmlArrayItemAttribute(ElementName = "error", IsNullable = false)]
        [XmlElement(ElementName = "error")]
        public string[] Message { get; set; }
    }
}

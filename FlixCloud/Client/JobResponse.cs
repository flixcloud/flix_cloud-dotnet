using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    [Serializable]
    [XmlRoot(ElementName = "job")]
    public class JobResponse
    {
        [XmlElement(ElementName = "id")]
        public int Id;

        [XmlElement(ElementName = "initialized-job-at")]
        public DateTime InitializedAt;
    }
}

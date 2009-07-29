using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    [DataContract(Namespace = "")]
    public class TaskStatus
    {
        [XmlElement("task_id", Order = 1)]
        public string TaskId { get; set; }

        [XmlElement("state", Order = 2)]
        public string State { get; set; }

        [XmlElement("state", Order = 3)]
        public double StatePercent { get; set; }
    }
}

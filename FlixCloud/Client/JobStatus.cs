using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    [XmlRoot(ElementName = "job")]
    [XmlInclude(typeof(TaskStatus))]
    public class JobStatus
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("task-state")]
        public string TaskState { get; set; }

        [XmlElement("input-media-file-task", typeof(TaskStatus))]
        public TaskStatus InputTask { get; set; }

        [XmlElement("transcoding-task")]
        public TaskStatus TranscodingTask { get; set; }

        [XmlElement("output-media-file-task")]
        public TaskStatus OutputTask { get; set; }
    }
}

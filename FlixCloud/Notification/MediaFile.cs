using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlixCloud.Notification
{
    [DataContract(Namespace = "")]
    public class MediaFile
    {
        [DataMember(Name = "url", Order = 1)]
        public string Url;

        [DataMember(Name = "width", Order = 2)]
        public int Width;

        [DataMember(Name = "height", Order = 3)]
        public int Height;

        [DataMember(Name = "size", Order = 4)]
        public int Size;

        [DataMember(Name = "duration", Order = 5)]
        public int Duration;

        [DataMember(Name = "cost", Order = 6)]
        public int Cost;
    }
}

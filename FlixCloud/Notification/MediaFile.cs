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
        private string mWidth = null;

        public int? Width
        {
            get
            {
                return Helper.ConvertInt32(mWidth);
            }
        }

        [DataMember(Name = "height", Order = 3)]
        private string mHeight = null;

        public int? Height
        {
            get
            {
                return Helper.ConvertInt32(mHeight);
            }
        }

        [DataMember(Name = "size", Order = 4)]
        private string mSize = null;

        public Int64? Size
        {
            get
            {
                return Helper.ConvertInt64(mSize);
            }
        }

        [DataMember(Name = "duration", Order = 5)]
        private string mDuration = null;

        public int? Duration
        {
            get
            {
                return Helper.ConvertInt32(mDuration);
            }
        }

        [DataMember(Name = "cost", Order = 6)]
        public int Cost;
    }
}

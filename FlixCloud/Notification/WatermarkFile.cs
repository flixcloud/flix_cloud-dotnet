﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlixCloud.Notification
{
    [DataContract(Namespace = "")]
    public class WatermarkFile
    {
        [DataMember(Name = "url", Order = 1)]
        public string Url;

        [DataMember(Name = "size", Order = 2)]
        public string mSize;
        
        public Int64? Size
        {
            get
            {
                return Helper.ConvertInt64(mSize);
            }
        }

        [DataMember(Name = "cost", Order = 3)]
        public int Cost;
    }
}

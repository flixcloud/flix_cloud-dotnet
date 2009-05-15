using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlixCloud.Notification
{
    [DataContract(Name = "job", Namespace = "")]
    public class JobNotification
    {
        [DataMember(Name = "finished-job-at", Order = 1)]
        public DateTime FinishedAt;

        [DataMember(Name = "id", Order = 2)]
        public int Id;

        [DataMember(Name = "initialized-job-at", Order = 3)]
        public DateTime InitializedAt;

        [DataMember(Name = "recipe-name", Order = 4)]
        public string RecipeName;

        [DataMember(Name = "recipe-id", Order = 5)]
        public int RecipeID;

        [DataMember(Name = "state", Order = 6)]
        public string State;

        [DataMember(Name = "input-media-file", Order = 7)]
        public MediaFile InputMediaFile;

        [DataMember(Name = "output-media-file", Order = 8)]
        public MediaFile OutputMediaFile;

        [DataMember(Name = "watermark-file", Order = 9)]
        public WatermarkFile WatermarkFile;
    }
}

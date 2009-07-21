using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Xml;
using FlixCloud.Notification;

namespace FlixCloudNotification
{
    public class FlixCloudNotificationService : IFlixCloudNotification
    {
        public void OnNotify(JobNotification notification)
        {
            string fileName = @"c:\inetpub\ftproot\Pub\" +
                DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-tt") + ".xml";
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
            {
                DataContractSerializer serializeer = new DataContractSerializer(typeof(JobNotification));
                serializeer.WriteObject(writer, notification);
            }
        }
    }
}

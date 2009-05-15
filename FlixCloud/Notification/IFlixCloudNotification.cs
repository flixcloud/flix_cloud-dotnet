using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FlixCloud.Notification
{
    [ServiceContract]
    public interface IFlixCloudNotification
    {
        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "FlixCloudNotification",
            RequestFormat = WebMessageFormat.Xml)]
        void OnNotify(JobNotification notification);
    }
}

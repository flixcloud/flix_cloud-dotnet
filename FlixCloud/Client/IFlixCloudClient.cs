using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FlixCloud.Client
{
    [ServiceContract]
    public interface IFlixCloudClient
    {
        [XmlSerializerFormat]
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            UriTemplate = "")]
        JobResponse JobRequest(ApiRequest request);
    }
}

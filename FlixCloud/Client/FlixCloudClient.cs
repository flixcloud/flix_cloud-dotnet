using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace FlixCloud.Client
{
    public class FlixCloudClient : ClientBase<IFlixCloudClient>, IFlixCloudClient
    {
        public FlixCloudClient()
        {
            foreach (var operation in Endpoint.Contract.Operations)
            {
                operation.KnownTypes.Add(typeof(JobResponse));
                operation.KnownTypes.Add(typeof(JobResponseError));
            }
        }

        object IFlixCloudClient.UntypedJobRequest(ApiRequest request)
        {
            return this.Channel.UntypedJobRequest(request);
        }

        public JobResponse JobRequest(ApiRequest request)
        {
            object response = ((IFlixCloudClient)this).UntypedJobRequest(request);

            if (response is JobResponse)
            {
                return (JobResponse)response;
            }
            else if (response is JobResponseError)
            {
                JobResponseError errorResponse = (JobResponseError)response;
                StringBuilder errorMessageList = new StringBuilder();
                string errorSeparator = String.Empty;
                foreach (string error in errorResponse.Message)
                {
                    errorMessageList.Append(errorSeparator);
                    errorMessageList.Append(error);

                    errorSeparator = Environment.NewLine;
                }

                throw new FlixCloudException(errorMessageList.ToString());
            }
            else
            {
                throw new FlixCloudException("Unknown job response type");
            }
        }

        public JobStatus GetJobStatus(string apiKey, int jobId)
        {
            HttpWebRequest request = WebRequest.Create(
                "https://www.flixcloud.com/jobs/" + jobId.ToString() + "/status") as HttpWebRequest;
            request.ContentType = "application/xml";
            request.Accept = "application/xml";
            request.Credentials = new NetworkCredential("dotNETClient", apiKey);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(JobStatus));
                using (StringWriter writer = new StringWriter())
                {
                    return serializer.Deserialize(response.GetResponseStream()) as JobStatus;
                }
            }
        }
    }
}

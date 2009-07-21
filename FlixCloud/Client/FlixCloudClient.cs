using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

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
    }
}

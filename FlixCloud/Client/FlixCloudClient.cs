using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FlixCloud.Client
{
    public class FlixCloudClient : ClientBase<IFlixCloudClient>, IFlixCloudClient
    {
        public JobResponse JobRequest(ApiRequest request)
        {
            return this.Channel.JobRequest(request);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlixCloud.Client
{
    [Serializable]
    public class FlixCloudException: Exception
    {
        public FlixCloudException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}

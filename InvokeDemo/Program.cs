using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlixCloud.Client;
using System.Net;
using System.IO;

namespace InvokeDemo
{
    class Program
    {
        const string API_KEY = "***";

        static void Main(string[] args)
        {
            FlixCloudClient fc = new FlixCloudClient();
            using (fc)
            {
                ApiRequest request = new ApiRequest();
                request.ApiKey = API_KEY;
                request.RecipeID = 232;
                request.PassThrough = "Test";
                request.NotificationUrl = "http://mysite.com/fc";
                request.Locations.Input.Url = "ftp://mysite.com/Pub/intro.wmv";
                request.Locations.Input.Parameters.User = "Anonymous";
                request.Locations.Input.Parameters.Password = "whatever";
                request.Locations.Output.Url = "ftp://mysite.com/Pub/conv";
                request.Locations.Output.Parameters.User = "Anonymous";
                request.Locations.Output.Parameters.Password = "whatever";

                JobResponse job = (JobResponse)fc.JobRequest(request);

                Console.WriteLine(String.Format("ID: {0} DateTime: {1}", job.Id, job.InitializedAt));

                JobStatus js = fc.GetJobStatus(API_KEY, job.Id);
                Console.WriteLine("Status=" + js.TaskState);

                Console.WriteLine("Press ENTER to close the application");
                Console.ReadLine();
            }
        }
    }
}

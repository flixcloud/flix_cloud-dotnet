using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlixCloud.Client;

namespace InvokeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            FlixCloudClient fc = new FlixCloudClient();
            using (fc)
            {
                ApiRequest request = new ApiRequest();
                request.ApiKey = "icyn:kfs8in:0:7d18:7otj";
                request.RecipeID = 232;
                request.Locations.Input.Url = "ftp://stephan.pppoe.fiber-lan.eu/Pub/avtogol.mpg";
                request.Locations.Output.Url = "ftp://stephan.pppoe.fiber-lan.eu/Pub/converted.mpg";
                request.Locations.Watermark.Url = "ftp://stephan.pppoe.fiber-lan.eu/Pub/watermark.png";

                JobResponse job = fc.JobRequest(request);

                Console.WriteLine(String.Format("ID: {0} DateTime: {1}", job.Id, job.InitializedAt));
                Console.WriteLine("Press ENTER to close the application");
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlixCloud.Client;
using System.Xml.Serialization;
using System.IO;

namespace FlixCloud.Test
{
    /// <summary>
    /// Summary description for ApiRequestSerializationTest
    /// </summary>
    [TestClass]
    public class ApiRequestSerializationTest
    {
        public ApiRequestSerializationTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private static ApiRequest BuildApiRequest()
        {
            ApiRequest request = new ApiRequest();
            request.ApiKey = "MyApiKey";
            request.RecipeID = 232;
            request.Locations.Input.Url = "ftp://mysite.com/Pub/hello.mpg";
            request.Locations.Output.Url = "ftp://mysite.com/Pub/hello-converted.mpg";

            return request;
        }

        private static string SerializeRequest(ApiRequest request)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApiRequest));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, request);
                return writer.ToString();
            }
        }

        [TestMethod]
        public void SimpleRequestTest()
        {
            ApiRequest request = BuildApiRequest();

            string expected =
                @"<?xml version=""1.0"" encoding=""utf-16""?>" + Environment.NewLine +
                "<api-request>" + Environment.NewLine +
                "  <api-key>MyApiKey</api-key>" + Environment.NewLine +
                "  <recipe-id>232</recipe-id>" + Environment.NewLine +
                "  <file-locations>" + Environment.NewLine +
                "    <input>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello.mpg</url>" + Environment.NewLine +
                "    </input>" + Environment.NewLine +
                "    <output>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello-converted.mpg</url>" + Environment.NewLine +
                "    </output>" + Environment.NewLine +
                "  </file-locations>" + Environment.NewLine +
                "</api-request>";

            string actual = SerializeRequest(request);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UsernameAndPasswordRequestTest()
        {
            ApiRequest request = BuildApiRequest();
            request.Locations.Input.Parameters.User = "MyUser";
            request.Locations.Input.Parameters.Password = "MyPassword";

            string expected =
                @"<?xml version=""1.0"" encoding=""utf-16""?>" + Environment.NewLine +
                "<api-request>" + Environment.NewLine +
                "  <api-key>MyApiKey</api-key>" + Environment.NewLine +
                "  <recipe-id>232</recipe-id>" + Environment.NewLine +
                "  <file-locations>" + Environment.NewLine +
                "    <input>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello.mpg</url>" + Environment.NewLine +
                "      <parameters>" + Environment.NewLine +
                "        <user>MyUser</user>" + Environment.NewLine +
                "        <password>MyPassword</password>" + Environment.NewLine +
                "      </parameters>" + Environment.NewLine +
                "    </input>" + Environment.NewLine +
                "    <output>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello-converted.mpg</url>" + Environment.NewLine +
                "    </output>" + Environment.NewLine +
                "  </file-locations>" + Environment.NewLine +
                "</api-request>";

            string actual = SerializeRequest(request);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotificationUrlTest()
        {
            ApiRequest request = BuildApiRequest();
            request.NotificationUrl = "http://mysite.com/FlixCloud/FlixCloudNotificationService.svc/FlixCloudNotification";

            string expected =
                @"<?xml version=""1.0"" encoding=""utf-16""?>" + Environment.NewLine +
                "<api-request>" + Environment.NewLine +
                "  <api-key>MyApiKey</api-key>" + Environment.NewLine +
                "  <recipe-id>232</recipe-id>" + Environment.NewLine +
                "  <notification-url>http://mysite.com/FlixCloud/FlixCloudNotificationService.svc/FlixCloudNotification</notification-url>" + Environment.NewLine +
                "  <file-locations>" + Environment.NewLine +
                "    <input>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello.mpg</url>" + Environment.NewLine +
                "    </input>" + Environment.NewLine +
                "    <output>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello-converted.mpg</url>" + Environment.NewLine +
                "    </output>" + Environment.NewLine +
                "  </file-locations>" + Environment.NewLine +
                "</api-request>";

            string actual = SerializeRequest(request);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PassThroughUrlTest()
        {
            ApiRequest request = BuildApiRequest();
            request.PassThrough = "666";

            string expected =
                @"<?xml version=""1.0"" encoding=""utf-16""?>" + Environment.NewLine +
                "<api-request>" + Environment.NewLine +
                "  <api-key>MyApiKey</api-key>" + Environment.NewLine +
                "  <recipe-id>232</recipe-id>" + Environment.NewLine +
                "  <pass-through>666</pass-through>" + Environment.NewLine +
                "  <file-locations>" + Environment.NewLine +
                "    <input>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello.mpg</url>" + Environment.NewLine +
                "    </input>" + Environment.NewLine +
                "    <output>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello-converted.mpg</url>" + Environment.NewLine +
                "    </output>" + Environment.NewLine +
                "  </file-locations>" + Environment.NewLine +
                "</api-request>";

            string actual = SerializeRequest(request);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThumbnailsRequestTest()
        {
            ApiRequest request = BuildApiRequest();
            request.Locations.Thumbnails.Url = "ftp://mysite.com/Pub/";
            request.Locations.Thumbnails.Prefix = "thumb";
            request.Locations.Thumbnails.Parameters.User = "MyUser";
            request.Locations.Thumbnails.Parameters.Password = "MyPassword";

            string expected =
                @"<?xml version=""1.0"" encoding=""utf-16""?>" + Environment.NewLine +
                "<api-request>" + Environment.NewLine +
                "  <api-key>MyApiKey</api-key>" + Environment.NewLine +
                "  <recipe-id>232</recipe-id>" + Environment.NewLine +
                "  <file-locations>" + Environment.NewLine +
                "    <input>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello.mpg</url>" + Environment.NewLine +
                "    </input>" + Environment.NewLine +
                "    <output>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello-converted.mpg</url>" + Environment.NewLine +
                "    </output>" + Environment.NewLine +
                "    <thumbnails>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/</url>" + Environment.NewLine +
                "      <prefix>thumb</prefix>" + Environment.NewLine +
                "      <parameters>" + Environment.NewLine +
                "        <user>MyUser</user>" + Environment.NewLine +
                "        <password>MyPassword</password>" + Environment.NewLine +
                "      </parameters>" + Environment.NewLine +
                "    </thumbnails>" + Environment.NewLine +
                "  </file-locations>" + Environment.NewLine +
                "</api-request>";

            string actual = SerializeRequest(request);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CuePointRequestTest()
        {
            ApiRequest request = BuildApiRequest();
            request.CuePoints.Event.Add(new CuePoint { Name = "cuept4", Time = 1.4M });
            request.CuePoints.Navigation.Add(new CuePoint { Name = "cuept1", Time = 3.4M });
            CuePointParameter param1 = new CuePointParameter { Key = "First", Value = "Value1" };
            CuePointParameter param2 = new CuePointParameter { Key = "Second", Value = "Value2" };
            request.CuePoints.Navigation[0].Parameters.Add(param1);
            request.CuePoints.Navigation[0].Parameters.Add(param2);

            string expected =
                @"<?xml version=""1.0"" encoding=""utf-16""?>" + Environment.NewLine +
                "<api-request>" + Environment.NewLine +
                "  <api-key>MyApiKey</api-key>" + Environment.NewLine +
                "  <recipe-id>232</recipe-id>" + Environment.NewLine +
                "  <cue-points>" + Environment.NewLine +
                "    <event>" + Environment.NewLine +
                "      <cue-point>" + Environment.NewLine +
                "        <name>cuept4</name>" + Environment.NewLine +
                "        <time>1.4</time>" + Environment.NewLine +
                "      </cue-point>" + Environment.NewLine +
                "    </event>" + Environment.NewLine +
                "    <navigation>" + Environment.NewLine +
                "      <cue-point>" + Environment.NewLine +
                "        <name>cuept1</name>" + Environment.NewLine +
                "        <time>3.4</time>" + Environment.NewLine +
                "        <parameter>" + Environment.NewLine +
                "          <key>First</key>" + Environment.NewLine +
                "          <value>Value1</value>" + Environment.NewLine +
                "        </parameter>" + Environment.NewLine +
                "        <parameter>" + Environment.NewLine +
                "          <key>Second</key>" + Environment.NewLine +
                "          <value>Value2</value>" + Environment.NewLine +
                "        </parameter>" + Environment.NewLine +
                "      </cue-point>" + Environment.NewLine +
                "    </navigation>" + Environment.NewLine +
                "  </cue-points>" + Environment.NewLine +
                "  <file-locations>" + Environment.NewLine +
                "    <input>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello.mpg</url>" + Environment.NewLine +
                "    </input>" + Environment.NewLine +
                "    <output>" + Environment.NewLine +
                "      <url>ftp://mysite.com/Pub/hello-converted.mpg</url>" + Environment.NewLine +
                "    </output>" + Environment.NewLine +
                "  </file-locations>" + Environment.NewLine +
                "</api-request>";

            string actual = SerializeRequest(request);

            Assert.AreEqual(expected, actual);
        }
    }
}

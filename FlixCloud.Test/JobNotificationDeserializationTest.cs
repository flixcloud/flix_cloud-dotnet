using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlixCloud.Notification;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace FlixCloud.Test
{
    /// <summary>
    /// Summary description for JobNotificationDeserializationTest
    /// </summary>
    [TestClass]
    public class JobNotificationDeserializationTest
    {
        public JobNotificationDeserializationTest()
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

        [TestMethod]
        public void SimpleDeserializationTest()
        {
            string notificationXML =
                @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <job>
                    <id type=""integer"">63047</id>
                    <initialized-job-at type=""datetime"">2009-07-27T14:45:52Z</initialized-job-at>
                    <pass-through nil=""true""></pass-through>
                    <recipe-name>Ozer_SD_WMV</recipe-name>
                    <recipe-id type=""integer"">232</recipe-id>
                    <state>failed_job</state>
                    <error-message>Custom error message</error-message>
                    <finished-job-at type=""datetime"">2009-07-27T14:52:48Z</finished-job-at>
                    <input-media-file>
                      <url>ftp://mysite.com/Pub/movie.mpg</url>
                      <width></width>
                      <height></height>
                      <size></size>
                      <duration></duration>
                      <cost>0</cost>
                    </input-media-file>
                    <output-media-file>
                      <url>ftp://mysite.com/Pub/movie-converted.mov</url>
                      <width></width>
                      <height></height>
                      <size></size>
                      <duration></duration>
                      <cost>0</cost>
                    </output-media-file>
                </job>";

            JobNotification notification = Deserialize(notificationXML);

            Assert.AreEqual(63047, notification.Id);
            Assert.AreEqual(new DateTime(2009, 7, 27, 14, 45, 52), notification.InitializedAt);
            Assert.AreEqual(String.Empty, notification.PassThrough);
            Assert.AreEqual("Ozer_SD_WMV", notification.RecipeName);
            Assert.AreEqual(232, notification.RecipeID);
            Assert.AreEqual("failed_job", notification.State);
            Assert.AreEqual("Custom error message", notification.ErrorMessage);
            Assert.AreEqual(new DateTime(2009, 7, 27, 14, 52, 48), notification.FinishedAt);
            Assert.AreEqual("ftp://mysite.com/Pub/movie.mpg", notification.InputMediaFile.Url);
            Assert.IsNull(notification.InputMediaFile.Width);
            Assert.IsNull(notification.InputMediaFile.Height);
            Assert.IsNull(notification.InputMediaFile.Size);
            Assert.IsNull(notification.InputMediaFile.Duration);
            Assert.AreEqual(0, notification.InputMediaFile.Cost);
            Assert.AreEqual("ftp://mysite.com/Pub/movie-converted.mov", notification.OutputMediaFile.Url);
            Assert.IsNull(notification.OutputMediaFile.Width);
            Assert.IsNull(notification.OutputMediaFile.Height);
            Assert.IsNull(notification.OutputMediaFile.Size);
            Assert.IsNull(notification.OutputMediaFile.Duration);
            Assert.AreEqual(0, notification.OutputMediaFile.Cost);
        }

        private JobNotification Deserialize(string notificationXML)
        {
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(notificationXML)))
            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(
                memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null))
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(JobNotification));
                return dataContractSerializer.ReadObject(reader) as JobNotification;
            }
        }
    }
}

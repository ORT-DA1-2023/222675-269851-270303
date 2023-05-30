using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using Render3D.BackEnd.Utilities;
using Render3D.RenderLogic;

namespace Render3D.UnitTest
{
    [TestClass]
    public class LogAnalyticsTest
    {
        private List<Log> logsCreated;
        private const int _secondsPerMinute = 60;
        private Client client1;
        private Client client2;
        private LogAnalytics logAnalytics;

        [TestInitialize]
        public void Initialize()
        {
             client1 = new Client { Name = "client1" };
             client2 = new Client { Name = "client2" };
            Scene scene1 = new Scene { Name = "scene1", Client = client1 };
            Scene scene2 = new Scene { Name = "scene2", Client = client2 };
            Scene scene2_1 = new Scene { Name = "scene2.1", Client = client2 };

            DateTime startedRender = DateTimeProvider.Now;
            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(40);
            Log l1 = new Log(scene1);
            Log l2 = new Log(scene2, startedRender);
            Log l3 = new Log(scene2_1, startedRender);

            logsCreated = new List<Log> { l1, l2, l3 };
            logAnalytics = new LogAnalytics(logsCreated);

        }

        [TestMethod]
        public void GivenLogAnalyticsSetLogsList()
        {
            Assert.AreEqual(logsCreated, logAnalytics.LogsCreated);
        }

        [TestMethod]
        public void GivenLogAnalyticsReturnsAverageRenderTimeInSeconds()
        {
            int sec = logAnalytics.GetAverageRenderTimeInSeconds();
            Assert.AreEqual(80 / 3, sec);
        }

        [TestMethod]
        public void GivenLogAnalyticsReturnsAverageRenderTimeInMinutes()
        {
            int min = logAnalytics.GetAverageRenderTimeInMinutes();
            Assert.AreEqual(80 / (3*_secondsPerMinute), min);
        }

        [TestMethod]
        public void GivenLogAnalyticsReturnsClientWithMostRenderTime()
        {
            Client c =logAnalytics.ClientWithMostRenderTime();
            Assert.AreEqual(client2, c);
        }


    }
}

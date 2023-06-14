using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using Render3D.BackEnd.Utilities;
using Render3D.BackEnd.Logs;

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
        private const string _client1Name = "client1";
        private const string _client2Name = "client2";
        private const string _scene1Name = "scene1";
        private const string _scene2Name = "scene2";
        private const string _scene2_1Name = "scene2.1";
        private const int _addedSconds = 40;
        private const int _totalSeconds = 80;
        private const int _average3 = 3;

        [TestInitialize]
        public void Initialize()
        {
             client1 = new Client { Name = _client1Name };
             client2 = new Client { Name = _client2Name };
            Scene scene1 = new Scene { Name = _scene1Name, Client = client1 };
            Scene scene2 = new Scene { Name = _scene2Name, Client = client2 };
            Scene scene2_1 = new Scene { Name = _scene2_1Name, Client = client2 };

            DateTime startedRender = DateTimeProvider.Now;
            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(_addedSconds);
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
            Assert.AreEqual(_totalSeconds / _average3, sec);
        }

        [TestMethod]
        public void GivenLogAnalyticsReturnsAverageRenderTimeInMinutes()
        {
            int min = logAnalytics.GetAverageRenderTimeInMinutes();
            Assert.AreEqual(_totalSeconds / (_average3 * _secondsPerMinute), min);
        }

        [TestMethod]
        public void GivenLogAnalyticsReturnsClientWithMostRenderTime()
        {
            Client c =logAnalytics.ClientWithMostRenderTime();
            Assert.AreEqual(client2, c);
        }


    }
}

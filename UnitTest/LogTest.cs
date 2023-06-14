using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using Render3D.BackEnd.Utilities;
using Render3D.BackEnd.Logs;

namespace Render3D.UnitTest
{
    [TestClass]
    public class LogTest
    {
        private Scene _sceneSample;
        private readonly string _sceneSampleName = "sceneSampleName";
        private const string _clientSampleName = "clientSampleName";
        private const string _clientSamplePassword = "S4fePassword";
        private const string _0second = "0 second(s)";
        private const string _10seconds = "10 second(s)";
        private const string _59seconds = "59 second(s)";
        private const string _1minute = "1 minute(s)";
        private const string _59minutes = "59 minute(s)";
        private const string _1hour = "1 hour(s)";
        private const string _23hours = "23 hour(s)";
        private const string _1day = "1 day(s)";
        private const string _100days = "100 day(s)";
        private readonly Client clientSample = new Client() { Name = _clientSampleName, Password = _clientSamplePassword };
        private readonly List<Model> positionedModels = new List<Model>();
        private Model modelSample;
        private Material materialSample;
        Vector3D origin;
        Vector3D direction;
        Figure figure;



     [TestInitialize]
        public void Initialize()
        {
            _sceneSample = new Scene() { Name = _sceneSampleName };

            origin= new Vector3D(0, 0, 0);
            direction = new Vector3D(1, 1, 1);
            materialSample = new LambertianMaterial();
            figure = new Sphere();
            modelSample = new Model();
        }

        [TestMethod]
        public void GivenSceneLogReturnsItsName()
        {
            Log l = new Log(_sceneSample, DateTimeProvider.Now);
            Assert.AreEqual(_sceneSample.Name, l.Name);
        }

        [TestMethod]
        public void GivenPreviewLogReturnsPreviewAndName()
        {
            Log l = new Log(_sceneSample);
            Assert.AreEqual($"preview - {_sceneSample.Name}", l.Name);
        }

        [TestMethod]
        public void GivenValidSceneAssignsTheScene()
        {
            Log l = new Log(_sceneSample,DateTimeProvider.Now);
            Assert.AreEqual(_sceneSample, l.Scene);
        }

        [TestMethod]
        public void GivenValidPreviewAssignsTheScene()
        {
            Log l = new Log(_sceneSample);
            Assert.AreEqual(_sceneSample, l.Scene);
        }

        [TestMethod]
        public void GivenValidSceneAssignsTheClient()
        {
            Log l = new Log(_sceneSample, DateTimeProvider.Now);
            Assert.AreEqual(_sceneSample.Client, l.Client);
        }

        [TestMethod]
        public void GivenValidPreviewAssignsTheClient()
        {
            Log l = new Log(_sceneSample);
            Assert.AreEqual(_sceneSample.Client, l.Client);
        }

        [TestMethod]
        public void givenLogReturnsItsRenderTimeInSeconds() {
            Log l = new Log(_sceneSample);
            l.RenderTimeInSeconds = 1;
            Assert.AreEqual(1, l.RenderTimeInSeconds);
       
        }

        [TestMethod]
        public void GivenLogReturnsQuantityModelsInScene()
        {
            Log l = new Log(sceneSample,DateTimeProvider.Now);
            Assert.AreEqual(sceneSample.PositionedModels.Count, l.NumberElements);
        }

        [TestMethod]
        public void GivenNeverRenderedSceneLogReturnsNullAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            Log l = new Log(_sceneSample,DateTimeProvider.Now);
            Assert.AreEqual(null, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRenderedLessThanASecondAgoReturns0SecondsAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate= DateTimeProvider.Now;

            DateTimeProvider.Now=DateTimeProvider.Now.AddMilliseconds(999);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_0second, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered10SecondsAgoReturns10SecondsAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(10);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_10seconds, l.TimeWindowSinceLastRender);
        }


        [TestMethod]
        public void givenASceneRendered59SecondsAgoReturns59SecondsAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(59);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_59seconds, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered1minuteAgoReturns1minuteAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(60);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_1minute, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered59minutesAgoReturns59MinutesAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddMinutes(59);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_59minutes, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered1hourAgoReturns1HourAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddHours(1);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_1hour, l.TimeWindowSinceLastRender);
        }
        [TestMethod]
        public void givenASceneRendered23hours59MinutesAgoReturns23HoursAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddHours(23).AddMinutes(59);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_23hours, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered1DayAgoReturns1DayAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddDays(1);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_1day, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered100DayAgoReturns100DayAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            _sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddDays(100);
            Log l = new Log(_sceneSample, DateTimeProvider.Now);

            Assert.AreEqual(_100days, l.TimeWindowSinceLastRender);
        }

    }
}

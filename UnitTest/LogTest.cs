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
        private Scene sceneSample;
        private readonly string sceneSampleName = "sceneSampleName";
        private readonly Client clientSample = new Client() { Name = "Joe", Password = "S4fePassword" };
        private readonly List<Model> positionedModels = new List<Model>();
        private Model modelSample;
        private Material materialSample;

        [TestInitialize]
        public void Initialize()
        {
            sceneSample = new Scene() { Name = sceneSampleName };

            Vector3D origin = new Vector3D(0, 0, 0);
            Vector3D direction = new Vector3D(1, 1, 1);
            materialSample = new LambertianMaterial();
            Figure figure = new Sphere();
            modelSample = new Model();
        }

        [TestMethod]
        public void GivenSceneLogReturnsItsName()
        {
            Log l = new Log(sceneSample, DateTimeProvider.Now);
            Assert.AreEqual(sceneSample.Name, l.Name);
        }

        [TestMethod]
        public void GivenPreviewLogReturnsPreviewAndName()
        {
            Log l = new Log(sceneSample.Name);
            Assert.AreEqual($"preview - {sceneSample.Name}", l.Name);
        }


        [TestMethod]
        public void GivenLogReturnsItsRenderTimeInSeconds()
        {
            Log l = new Log(sceneSample, DateTime.Now);
            l.RenderTimeInSeconds = 1;
            Assert.AreEqual(1, l.RenderTimeInSeconds);

        }

        [TestMethod]
        public void GivenLogReturnsQuantityModelsInScene()
        {
            Log l = new Log(sceneSample, DateTimeProvider.Now);
            Assert.AreEqual(sceneSample.PositionedModels.Count, l.NumberElements);
        }

        [TestMethod]
        public void GivenNeverRenderedSceneLogReturnsNullAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            Log l = new Log(sceneSample, DateTimeProvider.Now);
            Assert.AreEqual(null, l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRenderedLessThanASecondAgoReturns0SecondsAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddMilliseconds(999);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("0 second(s)", l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered10SecondsAgoReturns10SecondsAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(10);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("10 second(s)", l.TimeWindowSinceLastRender);
        }


        [TestMethod]
        public void givenASceneRendered59SecondsAgoReturns59SecondsAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(59);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("59 second(s)", l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered1minuteAgoReturns1minuteAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddSeconds(60);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("1 minute(s)", l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered59minutesAgoReturns59MinutesAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddMinutes(59);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("59 minute(s)", l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered1hourAgoReturns1HourAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddHours(1);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("1 hour(s)", l.TimeWindowSinceLastRender);
        }
        [TestMethod]
        public void givenASceneRendered23hours59MinutesAgoReturns23HoursAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddHours(23).AddMinutes(59);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("23 hour(s)", l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered1DayAgoReturns1DayAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddDays(1);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("1 day(s)", l.TimeWindowSinceLastRender);
        }

        [TestMethod]
        public void givenASceneRendered100DayAgoReturns100DayAsTimeWindow()
        {
            DateTimeProvider.Now = DateTime.Now;
            sceneSample.LastRenderizationDate = DateTimeProvider.Now;

            DateTimeProvider.Now = DateTimeProvider.Now.AddDays(100);
            Log l = new Log(sceneSample, DateTimeProvider.Now);

            Assert.AreEqual("100 day(s)", l.TimeWindowSinceLastRender);
        }

    }
}
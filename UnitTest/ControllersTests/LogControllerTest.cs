using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.DataTransferObjects;
using RepositoryFactory;
using System;
using System.Collections.Generic;

namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]

    public class LogControllerTest
    {
        LogController logController;
        RepoFactory repo = new RepoFactory();

        [TestInitialize]
        public void Initialize()
        {
            logController = LogController.GetInstance();
            repo.Initialize();

            try
            {
                logController.ClientController.Login("ClientTest", "4Testing");
                List<LogDto> logDtos = logController.GetLogs();
                foreach (LogDto log in logDtos)
                {
                    logController.Delete(log);
                }
            }
            catch { }
            try
            {
                logController.ClientController.RemoveClient("ClientTest");
            }
            catch { }
        }
        [TestMethod]
        public void GivenAlogFromPreviewSavesIt()
        {
            logController.ClientController.SignIn("ClientTest", "4Testing");
            logController.AddLogFromPreview("model1");
            Assert.AreEqual(logController.GetLogs().Count, 1);
        }
        [TestMethod]
        public void GivenAlogFromSceneSavesIt()
        {
            logController.ClientController.SignIn("ClientTest", "4Testing");
            Scene scene = new Scene
            {
                Name = "Test",
                LastRenderizationDate = DateTime.Now,
            };
            logController.AddLogFromScene(scene, DateTime.Now);
            Assert.AreEqual(logController.GetLogs().Count, 1);
        }
        [TestMethod]
        public void GivenLogsAverageRenderTimeInSeconds()
        {
            logController.ClientController.SignIn("ClientTest", "4Testing");
            DateTime start = DateTime.Now;
            Scene scene1 = new Scene
            {
                Name = "Test1",
                LastRenderizationDate = DateTime.Now,
            };
            Scene scene2 = new Scene
            {
                Name = "Test2",
                LastRenderizationDate = DateTime.Now,
            };
            logController.AddLogFromScene(scene1, start.AddSeconds(-2));
            logController.AddLogFromScene(scene2, start.AddSeconds(-2));
            logController.GetLogs();
            Assert.AreEqual(logController.GetAverageRenderTimeInSeconds(), 2);
        }
        [TestMethod]
        public void GivenLogsAverageRenderTimeInMinutes()
        {
            logController.ClientController.SignIn("ClientTest", "4Testing");
            DateTime start = DateTime.Now;
            Scene scene1 = new Scene
            {
                Name = "Test1",
                LastRenderizationDate = DateTime.Now,
            };
            Scene scene2 = new Scene
            {
                Name = "Test2",
                LastRenderizationDate = DateTime.Now,
            };
            logController.AddLogFromScene(scene1, start.AddSeconds(-60));
            logController.AddLogFromScene(scene2, start.AddSeconds(-60));
            logController.GetLogs();
            Assert.AreEqual(logController.GetAverageRenderTimeInMinutes(), 1);
        }
        [TestMethod]
        public void GivenLogsGetClientWithMostRenderTime()
        {
            logController.ClientController.SignIn("ClientTest", "4Testing");
            DateTime start = DateTime.Now;
            Scene scene1 = new Scene
            {
                Name = "Test1",
                LastRenderizationDate = DateTime.Now,
            };
            Scene scene2 = new Scene
            {
                Name = "Test2",
                LastRenderizationDate = DateTime.Now,
            };
            logController.AddLogFromScene(scene1, start.AddSeconds(-2));
            logController.AddLogFromScene(scene2, start.AddSeconds(-2));
            logController.GetLogs();
            Assert.AreEqual(logController.ClientWithMostRenderTime(), "ClientTest : 4");
        }

        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                logController.ClientController.Login("ClientTest", "4Testing");
                List<LogDto> logDtos = logController.GetLogs();
                foreach (LogDto log in logDtos)
                {
                    logController.Delete(log);
                }
            }
            catch { }
            try
            {
                logController.ClientController.RemoveClient("ClientTest");
            }
            catch { }
        }

    }
}

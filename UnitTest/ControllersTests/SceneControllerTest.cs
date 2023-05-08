using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.Figures;

namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class SceneControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;
        private Client _clientSample;
        private SceneController _sceneController;
        private Camera _defaultCamera;

        [TestInitialize]
        public void Initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientSample = new Client() { Name = "clientSample1", Password = "passwordSample1" };
            _clientController = new ClientController();
            _clientController.DataWarehouse = _dataWarehouse;
            _sceneController = new SceneController();
            _sceneController.DataWarehouse = _dataWarehouse;
            _sceneController.ClientController = _clientController;
        }

        [TestMethod]
        public void GivenANewSceneAddsItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 0);
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenANewWrongSceneFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 0);
            _sceneController.AddScene("clientSample1", "");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "scene already exists")]
        public void GivenARepeatedModelFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 0);
            _sceneController.AddScene("clientSample1", "SceneSample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 1);
        }

    }
}

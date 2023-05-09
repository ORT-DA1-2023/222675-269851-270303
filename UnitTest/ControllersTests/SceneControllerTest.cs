using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;

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
        private Scene _scene;
        private Model _model;
        private Material _material;
        private Figure _figure;
        private Vector3D _vectorOfOnes;

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
            _defaultCamera = new Camera();
             _vectorOfOnes = new Vector3D(1, 1, 1);
            _figure = new Sphere() { Client = _clientSample, Name = "testFigure", Radius = 1 };
            _material = new LambertianMaterial() { Client = _clientSample, Name = "testMaterial" };
            _model = new Model() { Client = _clientSample, Name = "testModel", Figure = _figure, Material = _material };
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
        public void GivenARepeatedSceneFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 0);
            _sceneController.AddScene("clientSample1", "SceneSample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 1);
        }

        [TestMethod]
        public void GivenANewSceneNameItChanges()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            _sceneController.ChangeSceneName("clientSample1", "SceneSample1", "SceneSample2");
            Assert.AreEqual("SceneSample2", _sceneController.DataWarehouse.Scenes[0].Name);
        }
        [TestMethod]
        public void GivenARepeatedSceneNameItDoesNotChange()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            _sceneController.AddScene("clientSample1", "SceneSample2");
            _sceneController.ChangeSceneName("clientSample1", "SceneSample1", "SceneSample2");
            Assert.AreEqual("SceneSample1", _sceneController.DataWarehouse.Scenes[0].Name);
            Assert.AreEqual("SceneSample2", _sceneController.DataWarehouse.Scenes[1].Name);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void GivenAnIncorrectSceneNameItThrowsException()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            _sceneController.ChangeSceneName("clientSample1", "SceneSample1", "");
            Assert.AreEqual("SceneSample1", _sceneController.DataWarehouse.Scenes[0].Name);
        }
        [TestMethod]
        public void GivenANameDeletesTheScene()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 1);
            _sceneController.DeleteSceneInList("clientSample1", "SceneSample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 0);
        }
        [TestMethod]
        public void GivenANameDoesNotDeleteTheFigure()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 1);
            _sceneController.DeleteSceneInList("clientSample1", "SceneSample2");
            Assert.IsTrue(_sceneController.DataWarehouse.Scenes.Count == 1);
        }

        [TestMethod]
        public void GivenANewCameraAssignsItToTheScene()
        {
            _scene= new Scene() {Client=_clientSample, Name= "SceneSample1",Camera=_defaultCamera};
            string lookAt = "(1;1;1)";
            string lookFrom = "(1;1;1)";
            Camera testCamera = new Camera() { LookAt= _vectorOfOnes, LookFrom= _vectorOfOnes, Fov=30};
            _sceneController.EditCamera(_scene, lookAt, lookFrom, 30);
            Assert.IsTrue(_scene.Camera.Equals(testCamera));
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Fov must be between 0 and 160")]
        public void GivenAWrongCameraDoesNotAssignsItToTheScene()
        {
            _scene = new Scene() { Client = _clientSample, Name = "SceneSample1", Camera = _defaultCamera };
            string lookAt = "(1;1;1)";
            string lookFrom = "(1;1;1)";
            _sceneController.EditCamera(_scene, lookAt, lookFrom, -30);
        }

        [TestMethod]
        public void GivenTheScenesGetTheNextValidName()
        {  
            Assert.AreEqual(_sceneController.GetNextValidName(),"Blank_name_1");
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "Blank_name_1");
            Assert.AreEqual(_sceneController.GetNextValidName(), "Blank_name_2");
        }

        [TestMethod]
        public void GivenANewModelAddsItToTheListOfPositionedModels()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Scene scene = _sceneController.GetSceneByNameAndClient("clientSample1", "SceneSample1");
            _sceneController.AddModel(scene, _model, "(1;1;1)");
            Assert.IsTrue(scene.PositionedModels.Count==1);
            Assert.IsTrue(scene.PositionedModels[0].Figure.Position.Equals( _vectorOfOnes));  
        }
        [TestMethod]
        public void GivenAModelRemovesItFromTheListOfPositionedModels()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _sceneController.AddScene("clientSample1", "SceneSample1");
            Scene scene = _sceneController.GetSceneByNameAndClient("clientSample1", "SceneSample1");
            _sceneController.AddModel(scene, _model, "(1;1;1)");
            Assert.IsTrue(scene.PositionedModels.Count == 1);
            Model model= scene.PositionedModels[0];
            _sceneController.RemoveModel(scene, model);
            Assert.IsTrue(scene.PositionedModels.Count == 0);
        }

    }
}

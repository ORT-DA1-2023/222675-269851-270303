using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
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
        }

        [TestMethod]
        public void GivenNewSceneAddsItToList()
        {
          
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongSceneFailsAddingItToTheList()
        {
           
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "scene already exists")]
        public void GivenRepeatedSceneFailsAddingItToTheList()
        {
           
        }

        [TestMethod]
        public void GivenNewSceneNameItChanges()
        {
          
        }
        [TestMethod]
        public void GivenRepeatedSceneNameItDoesNotChange()
        {
         
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void GivenIncorrectSceneNameItThrowsException()
        {
        }
        [TestMethod]
        public void GivenNameDeletesScene()
        {
        }
        [TestMethod]
        public void GivenNameDoesNotDeleteFigure()
        {
        }

        [TestMethod]
        public void GivenNewCameraAssignsItToScene()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Fov must be between 0 and 160")]
        public void GivenWrongCameraDoesNotAssignsItToScene()
        {
        }

        [TestMethod]
        public void GivenScenesGetTheNextValidName()
        {
        }

        [TestMethod]
        public void GivenNewModelAddsItToListOfPositionedModels()
        { 
        }
        [TestMethod]
        public void GivenModelRemovesItFromListOfPositionedModels()
        {
           
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "no scene Found")]
        public void GivenModelWithoutFigureThrowsException()
        {
        }
        [TestMethod]
        public void GivenSceneWithModelsReturnsList()
        {
        }

    }
}

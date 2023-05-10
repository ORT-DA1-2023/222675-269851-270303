using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class ModelControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;
        private Client _clientSample;
        private Material _materialSample;
        private Figure _figure;
        private ModelController _modelController;
        private Model _modelSample;
        private readonly Colour _colour = new Colour(0, 0, 0);

        [TestInitialize]
        public void Initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse = _dataWarehouse };
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            _materialSample = new LambertianMaterial() { Client = _clientSample, Name = "materialSample1", Attenuation = _colour };
            _figure = new Sphere() { Client = _clientSample, Name = "figureSample1", Radius = 5 };
            _modelController = new ModelController() { ClientController = _clientController, DataWarehouse = _dataWarehouse };
            _modelSample = new Model() { Client = _clientSample, Name = "modelSample1", Figure = _figure, Material = _materialSample };
        }
        [TestMethod]
        public void GivenNewModelAddsItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongModelFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
            _modelController.AddAModelWithoutPreview("clientSample1", "", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "modelSample already exists")]
        public void GivenRepeatedModelFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
        }
        [TestMethod]
        public void givenNewModelNameItChanges()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.ChangeModelName("clientSample1", "modelSample1", "modelSample2");
            Assert.IsTrue(_modelController.DataWarehouse.Models[0].Name == "modelSample2");

        }
        [TestMethod]
        public void givenNewModelNameItDoesNotChange()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample2", _figure, _materialSample);
            _modelController.ChangeModelName("clientSample1", "modelSample1", "modelSample2");
            Assert.IsTrue(_modelController.DataWarehouse.Models[0].Name == "modelSample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models[1].Name == "modelSample2");
        }
        [TestMethod]
        public void GivenNameDeletesTheModel()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
            _modelController.DeleteModelInList("clientSample1", "modelSample1");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 0);
        }
        [TestMethod]
        public void GivenNameDoesNotDeleteTheModel()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithoutPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
            _modelController.DeleteModelInList("clientSample1", "modelSample2");
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
        }

        [TestMethod]
        public void GivenModelItAssignsItsPreview()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.DataWarehouse.Models.Count == 1);
            Assert.IsTrue(_dataWarehouse.Models[0].Preview != null);
        }
		
        [TestMethod]
        public void GivenModelWithFigureReturnsList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.GetModelsWithFigure("figureSample1").Count > 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "no Models Found")]
        public void GivenModelWithoutFigureThrowsException()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.GetModelsWithFigure("figureSample2");
        }
        [TestMethod]
        public void GivenModelWithMaterialReturnsList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithPreview("clientSample1", "modelSample1", _figure, _materialSample);
            Assert.IsTrue(_modelController.GetModelWithMaterial("materialSample1").Count > 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "no Models Found")]
        public void GivenModelWithoutModelThrowsException()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _modelController.AddAModelWithPreview("clientSample1", "modelSample1", _figure, _materialSample);
            _modelController.GetModelsWithFigure("materialSample2");
        }
    }
}


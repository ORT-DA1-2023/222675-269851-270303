using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class MaterialControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private MaterialController _materialController;
        private ClientController _clientController;
        private Client _clientSample;
        private Material _materialSample;
        private readonly Colour _color = new Colour(0, 0, 0);
        private readonly int[] _colorArray = new int[] { 0, 0, 0 };

        [TestInitialize]
        public void Initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse = _dataWarehouse };
            _materialController = new MaterialController() { DataWarehouse = _dataWarehouse, ClientController = _clientController };
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            _materialSample = new LambertianMaterial() { Client = _clientSample, Name = "materialSample1", Attenuation = _color };
        }
        [TestMethod]
        public void GivenNewMaterialAddsItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongMaterialFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddLambertianMaterial("clientSample1", "", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "materialSample already exists")]
        public void GivenRepeatedMaterialFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }
        [TestMethod]
        public void GivenNewMaterialNameItChanges()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            _materialController.ChangeMaterialName("clientSample1", "materialSample1", "materialSample2");
            Assert.IsTrue(_materialController.DataWarehouse.Materials[0].Name == "materialSample2");

        }
        [TestMethod]
        public void GivenNewMaterialNameItDoesNotChange()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            _materialController.AddLambertianMaterial("clientSample1", "materialSample2", _colorArray);
            _materialController.ChangeMaterialName("clientSample1", "materialSample1", "materialSample2");
            Assert.IsTrue(_materialController.DataWarehouse.Materials[0].Name == "materialSample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials[1].Name == "materialSample2");
        }
        [TestMethod]
        public void GivenNameDeletesTheMaterial()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
            _materialController.DeleteMaterialInList("clientSample1", "materialSample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
        }
        [TestMethod]
        public void GivenNameDoesNotDeleteTheMaterial()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddLambertianMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
            _materialController.DeleteMaterialInList("clientSample1", "materialSample2");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }

    }
}

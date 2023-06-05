using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
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

        private const string lambertianMaterialName = "lambertialMaterialSample1";
        private const string lambertianMaterialNameChange = "lambertialMaterialSample2";
        private const string clientSampleName = "clientSample1";
        private const string passwordSample = "PasswordExample1";


        [TestInitialize]
        public void Initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse = _dataWarehouse };
            _materialController = new MaterialController() { DataWarehouse = _dataWarehouse, ClientController = _clientController };
            _clientSample = new Client() { Name = clientSampleName, Password = passwordSample };
            _materialSample = new LambertianMaterial() { Client = _clientSample, Name = lambertianMaterialName, Attenuation = _color };
        }
        [TestMethod]
        public void GivenNewLambertianMaterialAddsItToTheList()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongLambertianMaterialFailsAddingItToTheList()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddLambertianMaterial(clientSampleName, "", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "lambertialMaterialSample1 already exists")]
        public void GivenRepeatedLambertianMaterialFailsAddingItToTheList()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }
        [TestMethod]
        public void GivenNewLambertianMaterialNameItChanges()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            _materialController.ChangeMaterialName(clientSampleName, lambertianMaterialName, lambertianMaterialNameChange);
            Assert.IsTrue(_materialController.DataWarehouse.Materials[0].Name == lambertianMaterialNameChange);

        }
        [TestMethod]
        public void GivenNewLambertianMaterialNameItDoesNotChange()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialNameChange, _colorArray);
            _materialController.ChangeMaterialName(clientSampleName, lambertianMaterialName, lambertianMaterialNameChange);
            Assert.IsTrue(_materialController.DataWarehouse.Materials[0].Name == lambertianMaterialName);
            Assert.IsTrue(_materialController.DataWarehouse.Materials[1].Name == lambertianMaterialNameChange);
        }
        [TestMethod]
        public void GivenNameDeletesTheLambertianMaterial()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
            _materialController.DeleteMaterialInList(clientSampleName, lambertianMaterialName);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
        }
        [TestMethod]
        public void GivenNameDoesNotDeleteTheLambertianMaterial()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            _materialController.AddLambertianMaterial(clientSampleName, lambertianMaterialName, _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
            _materialController.DeleteMaterialInList(clientSampleName, lambertianMaterialNameChange);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }

    }
}

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
      

        private const string lambertianMaterialName = "lambertialMaterialSample1";
        private const string lambertianMaterialNameChange = "lambertialMaterialSample2";
        private const string metallicMaterialName = "metallicMaterialSample1";
        private const string metallicMaterialNameChange = "metallicMaterialSample2";
        private const string clientSampleName = "clientSample1";
        private const string passwordSample = "PasswordExample1";
        private const double blurSample = 0.5;


        [TestInitialize]
        public void Initialize()
        {
          
        }
        [TestMethod]
        public void GivenNewLambertianMaterialAddsItToTheList()
        {
        }

        [TestMethod]
        public void GivenNewMetallicMaterialAddsItToTheList()
        {
            _clientController.SignIn(clientSampleName, passwordSample);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddMetallicMaterial(clientSampleName, metallicMaterialName, _colorArray, blurSample);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongLambertianMaterialFailsAddingItToTheList()
        {
           
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "materialSample already exists")]
        public void GivenRepeatedMaterialFailsAddingItToTheList()
        {
          
        }
        [TestMethod]
        public void GivenNewMaterialNameItChanges()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongMetallicMaterialFailsAddingItToTheList()
        {
           
        }
        [TestMethod]
        public void GivenNameDeletesTheMaterial()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "lambertialMaterialSample1 already exists")]
        public void GivenRepeatedLambertianMaterialFailsAddingItToTheList()
        {
        }

    }
}

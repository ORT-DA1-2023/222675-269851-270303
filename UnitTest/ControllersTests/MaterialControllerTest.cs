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

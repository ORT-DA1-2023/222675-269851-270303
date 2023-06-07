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
        public void GivenNewMaterialAddsItToTheList()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongMaterialFailsAddingItToTheList()
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
        public void GivenNewMaterialNameItDoesNotChange()
        {
           
        }
        [TestMethod]
        public void GivenNameDeletesTheMaterial()
        {

        }
        [TestMethod]
        public void GivenNameDoesNotDeleteTheMaterial()
        {
        }

    }
}

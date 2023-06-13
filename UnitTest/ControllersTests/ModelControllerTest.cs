using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class ModelControllerTest
    {

        [TestInitialize]
        public void Initialize()
        {
            }
        [TestMethod]
        public void GivenNewModelAddsItToTheList()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongModelFailsAddingItToTheList()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "modelSample already exists")]
        public void GivenRepeatedModelFailsAddingItToTheList()
        {
        }
        [TestMethod]
        public void GivenNewModelNameItChanges()
        {

        }
        [TestMethod]
        public void givenNewModelNameItDoesNotChange()
        {
          
        }
        [TestMethod]
        public void GivenNameDeletesTheModel()
        {
        }
        [TestMethod]
        public void GivenNameDoesNotDeleteTheModel()
        {
           
        }

        [TestMethod]
        public void GivenModelItAssignsItsPreview()
        {
            
        }

        [TestMethod]
        public void GivenModelWithFigureReturnsList()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "no Models Found")]
        public void GivenModelWithoutFigureThrowsException()
        {

        }
        [TestMethod]
        public void GivenModelWithMaterialReturnsList()
        {
         
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "no Models Found")]
        public void GivenModelWithoutModelThrowsException()
        {
        }
    }
}


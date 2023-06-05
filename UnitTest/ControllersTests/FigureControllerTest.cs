using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class FigureControllerTest
    {


        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void GivenNewFigureAddsItToTheList()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "the Radius must be greater than 1")]
        public void GivenNewWrongFigureFailsTryingToAddItToTheList()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "figure already exists")]
        public void GivenReapetedFigureFailsTryingToAddItToTheList()
        {
        }
        [TestMethod]
        public void GivenNewFigureNameItChanges()
        {
        }
        [TestMethod]
        public void GivenNewFigureNameItDoesNotChange()
        {
         
        }
        [TestMethod]
        public void GivenNameDeletesTheFigure()
        {
          
        }
        [TestMethod]
        public void GivenNameDoesNotDeleteTheFigure()
        {
         
        }
    }
}

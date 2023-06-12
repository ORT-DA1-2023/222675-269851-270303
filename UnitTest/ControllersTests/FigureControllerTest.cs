using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Utilities;
using RenderLogic.Services;
using RenderLogic.RepoInterface;
using renderRepository.RepoImplementation;

namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class FigureControllerTest
    {

        FigureController figureController;
        FigureService figureService;
        IFigureRepo figureRepo;

        [TestInitialize]
        public void Initialize()
        {
            figureController = FigureController.GetInstance();
            figureRepo = new FigureRepo();
            figureService = new FigureService(figureRepo);
            figureController.FigureService = figureService;
        }

        [TestMethod]
        public void GivenNewFigureSavesIt()
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

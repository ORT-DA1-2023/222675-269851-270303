using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Utilities;
using Render3D.RenderLogic.Services;
using Render3D.RenderLogic.RepoInterface;
using renderRepository.RepoImplementation;
using Render3D.RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
using RepositoryFactory;

namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class FigureControllerTest
    {
        FigureController figureController;
        RepoFactory repo = new RepoFactory();

        [TestInitialize]
        public void Initialize()
        {
            figureController = FigureController.GetInstance();
            repo.Initialize();
            try
            {
                figureController.ClientController.Login("ClientTest", "4Testing");
                List<FigureDto> figureDtos = figureController.GetFigures();
                foreach(FigureDto figureDto in figureDtos)
                {
                    figureController.Delete(figureDto);
                }
            }
            catch { }
            try
            {
                figureController.ClientController.RemoveClient("ClientTest");
            }
            catch { }
        }

        [TestMethod]
        public void GivenNewFigureSavesIt()
        {
            figureController.ClientController.SignIn("ClientTest", "4Testing");
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            Assert.AreEqual(figureController.GetFigures()[0].Name, "figureTest");
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "figure already exists")]
        public void GivenNewFigureItIsAlreadySaved()
        {
            figureController.ClientController.SignIn("ClientTest", "4Testing");
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
        }
        [TestMethod]
        public void GivenNewFigureNameItChanges()
        {
            figureController.ClientController.SignIn("ClientTest", "4Testing");
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            figureController.ChangeName(figureController.GetFigures()[0],"figureTest2");
            Assert.AreEqual(figureController.GetFigures()[0].Name, "figureTest2");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "That Name is already in use")]
        public void GivenNewFigureNameItDoesNotChange()
        {
            figureController.ClientController.SignIn("ClientTest", "4Testing");
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest2",
                Radius = 10,
            });
            figureController.ChangeName(figureController.GetFigures()[0], "figureTest2");
        }
        [TestMethod]
        public void GivenFigureDeletesIt()
        {
            figureController.ClientController.SignIn("ClientTest", "4Testing");
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            List<FigureDto> listDto = figureController.GetFigures();
            Assert.AreEqual(listDto.Count, 1);
            figureController.Delete(listDto[0]);
            List<FigureDto> listDto2 = figureController.GetFigures();
            Assert.AreEqual(listDto2.Count, 0);
        }
        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                figureController.ClientController.Login("ClientTest", "4Testing");
                List<FigureDto> figureDtos = figureController.GetFigures();
                foreach (FigureDto figureDto in figureDtos)
                {
                    figureController.Delete(figureDto);
                }
            }
            catch { }
            try
            {
                figureController.ClientController.RemoveClient("ClientTest");
            }
            catch { }
        }
    }
}

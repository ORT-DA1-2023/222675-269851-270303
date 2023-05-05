using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.Figures;

namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class FigureControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private FigureController _figureController;
        private ClientController _clientController;
        private Client _clientSample;
        private Figure _figureSample;

        [TestInitialize]
        public void initialize()
        {
            _dataWarehouse= new DataWarehouse();
             _clientController = new ClientController() { DataWarehouse=_dataWarehouse};
            _figureController = new FigureController() { DataWarehouse=_dataWarehouse, ClientController=_clientController};
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            _figureSample = new Sphere() { Client = _clientSample, Name = "figureSample1", Radius = 5 };
        }

        [TestMethod]
        public void GivenANewFigureAddsItToTheList()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((_figureController.DataWarehouse).Figures.Count == 0);
            _figureController.AddFigure("clientSample1", "figureSample1", 5);
            Assert.AreEqual(_figureSample.Name, _figureController.DataWarehouse.Figures[0].Name);
            Assert.IsTrue((_figureSample.Client).Equals(_figureController.DataWarehouse.Figures[0].Client));
            Assert.IsTrue((_figureController.DataWarehouse).Figures.Count == 1);
        }

        [TestMethod]
        public void GivenANewWrongFigureFailsTryingToAddItToTheList()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((_figureController.DataWarehouse).Figures.Count == 0);
            _figureController.AddFigure("clientSample1", "figureSample1", -5);
            Assert.IsTrue((_figureController.DataWarehouse).Figures.Count == 0);
        }
        [TestMethod]
        public void GivenAReapetedFigureFailsTryingToAddItToTheList()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((_figureController.DataWarehouse).Figures.Count == 0);
            _figureController.AddFigure("clientSample1", "figureSample1", 5);
            _figureController.AddFigure("clientSample1", "figureSample1", 5);
            Assert.IsTrue((_figureController.DataWarehouse).Figures.Count == 1);
        }
        [TestMethod]
        public void GivenANewFigureNameItChanges()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _figureController.AddFigure("clientSample1", "figureSample1", 5);
            _figureController.ChangeFigureName("clientSample1", "figureSample1", "figureSample2");
            Assert.AreEqual("figureSample2",_figureController.DataWarehouse.Figures[0].Name);
        }
        [TestMethod]
        public void GivenANewFigureNameItDoesNotChange()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _figureController.AddFigure("clientSample1", "figureSample1", 1);
            _figureController.AddFigure("clientSample1", "figureSample2", 5);
            _figureController.ChangeFigureName("clientSample1", "clientSample1", "figureSample2");
            Assert.AreEqual("figureSample1", _figureController.DataWarehouse.Figures[0].Name);
            Assert.AreEqual("figureSample2", _figureController.DataWarehouse.Figures[1].Name);
        }
        [TestMethod]
        public void GivenANameDeletesTheFigure()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _figureController.AddFigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(_figureController.DataWarehouse.Figures.Count == 1);
            _figureController.DeleteFigureInList("clientSample1", "figureSample1");
            Assert.IsTrue(_figureController.DataWarehouse.Figures.Count == 0);
        }
        [TestMethod]
        public void GivenANameDoesNotDeleteTheFigure()
        {
            _clientController.TryToSignIn("clientSample1", "PasswordExample1");
            _figureController.AddFigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(_figureController.DataWarehouse.Figures.Count == 1);
            _figureController.DeleteFigureInList("clientSample1", "figureSample2");
            Assert.IsTrue(_figureController.DataWarehouse.Figures.Count == 1);
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.Controllers;

namespace Render3D.UnitTest.ControlllersTests
{
    [TestClass]
    public class ClientControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;
        private Client _clientSample;

        [TestInitialize]
        public void initialize()
        {    
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse=_dataWarehouse};
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
        }

        [TestMethod]
        public void GivenANewClientReturnsTrueAfterAddingItToTheList()
        {
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 0);
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_clientSample.Equals((_clientController.DataWarehouse).Clients[0]));
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 1);
        }
        [TestMethod]
        public void GivenANewWrongClientReturnsFalseAfterTryingToAddItToTheList()
        {
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 0);
            _clientController.SignIn("", "");
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 0);
        }
        [TestMethod]
        public void GivenAClientReturnsTrueIfIsInTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_clientController.GetClientByName("clientSample1").Equals(_clientSample));
        }
        [TestMethod]
        public void GivenAClientReturnsFalseIfIsInNotTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_clientController.GetClientByName("clientSample2").Name==null);
        }
        [TestMethod]
        public void givenANameChecksIfIsValid()
        {
            Assert.IsTrue(_clientController.CheckName("clientSample1"));
        }
        [TestMethod]
        public void givenANameChecksIfIsNotValid()
        {
            Assert.IsFalse(_clientController.CheckName(""));
        }

        [TestMethod]
        public void givenAPasswordChecksIfIsValid()
        {
            Assert.IsTrue(_clientController.CheckPassword("ValidPassword1"));
        }
        [TestMethod]
        public void givenAPasswordChecksIfIsNotValid()
        {
            Assert.IsFalse(_clientController.CheckPassword(""));
        }
    }
}

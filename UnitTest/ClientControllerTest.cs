using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.Controllers;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ClientControllerTest
    {
        ClientController clientController;
        Client clientSample;

        [TestInitialize]
        public void initialize()
        {    
            clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
        }

        [TestMethod]
        public void GivenANewClientReturnsTrueAfterAddingItToTheList()
        {
            Assert.IsTrue((clientController.DataWarehouse).Clients.Count == 0);
            clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(clientSample.Equals((clientController.DataWarehouse).Clients[0]));
            Assert.IsTrue((clientController.DataWarehouse).Clients.Count == 1);
        }
        [TestMethod]
        public void GivenANewWrongClientReturnsFalseAfterTryingToAddItToTheList()
        {
            Assert.IsTrue((clientController.DataWarehouse).Clients.Count == 0);
            clientController.TryToSignIn("", "");
            Assert.IsTrue((clientController.DataWarehouse).Clients.Count == 0);
        }
        [TestMethod]
        public void GivenAClientReturnsTrueIfIsInTheList()
        {
            clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(clientController.ExistsThisClient("clientSample1", "PasswordExample1"));
        }
        [TestMethod]
        public void GivenAClientReturnsFalseIfIsInNotTheList()
        {
            clientController.TryToSignIn("clientSample1", "PasswordExample1");
            Assert.IsFalse(clientController.ExistsThisClient("clientSample2", "PasswordExample1"));
        }
    }
}

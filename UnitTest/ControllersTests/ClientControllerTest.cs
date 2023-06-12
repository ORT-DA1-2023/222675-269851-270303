using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.RepoInterface;
using Render3D.RenderLogic.Services;
using renderRepository.RepoImplementation;
using System;

namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class ClientControllerTest
    {
        ClientController clientController;
        ClientService clientService;
        IClientRepo clientRepo;

        [TestInitialize]
        public void Initialize()
        {
            clientController = ClientController.GetInstance();
            clientRepo = new ClientRepo();
            clientService = new ClientService(clientRepo);
            clientController.ClientService = clientService;
            try
            {
                clientController.RemoveClient("clientTest");
            }
            catch
            {

            }
        }

        [TestMethod]
        public void GivenNewClientSavesIt()
        {
            clientController.SignIn("ClientTest", "4Testing");
            clientController.Login("ClientTest", "4Testing");
            Assert.AreEqual(clientController.Client.Name, "ClientTest");
            clientController.RemoveClient("clientTest");
        }
        [TestMethod]
        public void GivenClientGetsIt()
        {
            clientController.SignIn("ClientTest", "4Testing");
            Assert.AreEqual(clientController.GetClient(), "ClientTest");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Client Already Exists")]
        public void GivenAClientThatAlreadyExistsThrowsException()
        {
            clientController.SignIn("ClientTest", "4Testing");
            clientController.SignIn("ClientTest", "4Testing");

        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "A Client with that name does not exist")]
        public void GivenClientThrowsExceptionIfItIsNotSaved()
        {
            clientController.Login("ClientTest", "4Testing");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Password incorrect")]
        public void GivenClientWithWrongPasswordThrowsException()
        {
            clientController.SignIn("ClientTest", "4Testing");
            clientController.Login("ClientTest", "4Testing2");
        }
        [TestMethod]
        public void GivenNameChecksIfIsValid()
        {
            clientController.CheckName("ClientTest");
        }
        [TestMethod]

        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenNameChecksIfIsNotValid()
        {
            clientController.CheckName("");
        }

        [TestMethod]
        public void GivenPasswordChecksIfIsValid()
        {
            clientController.CheckPassword("4Testing");
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 5 and 25")]
        public void GivenPasswordChecksIfIsNotValid()
        {
            clientController.CheckPassword("");
        }
        [TestMethod]
        public void LogsOut()
        {
            clientController.LogOut();
            Assert.AreEqual(clientController.Client, null);
        }
    }
}

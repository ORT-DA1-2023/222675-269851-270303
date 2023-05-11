using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class ClientControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;
        private Client _clientSample;

        [TestInitialize]
        public void Initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse = _dataWarehouse };
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
        }

        [TestMethod]
        public void GivenNewClientReturnsTrueAfterAddingItToTheList()
        {
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 0);
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_clientSample.Equals((_clientController.DataWarehouse).Clients[0]));
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenNewWrongClientThrowsExceptionAfterTryingToAddItToTheList()
        {
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 0);
            _clientController.SignIn("", "");
            Assert.IsTrue((_clientController.DataWarehouse).Clients.Count == 0);
        }
        [TestMethod]
        public void GivenClientReturnsTrueIfIsInTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_clientController.GetClientByName("clientSample1").Equals(_clientSample));
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The client doesnt exist")]
        public void GivenClientReturnsFalseIfIsNotInTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_clientController.GetClientByName("clientSample2").Name == null);
        }
        [TestMethod]
        public void GivenNameChecksIfIsValid()
        {
            _clientController.CheckName("clientSample1");
        }
        [TestMethod]

        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenNameChecksIfIsNotValid()
        {
            _clientController.CheckName("");
        }

        [TestMethod]
        public void GivenPasswordChecksIfIsValid()
        {
            _clientController.CheckPassword("ValidPassword1");
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 5 and 25")]
        public void GivenPasswordChecksIfIsNotValid()
        {
            _clientController.CheckPassword("");
        }
    }
}

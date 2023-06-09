using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest.ControllersTests
{
    [TestClass]
    public class ClientControllerTest
    {


        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void GivenNewClientReturnsTrueAfterAddingItToTheList()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenNewWrongClientThrowsExceptionAfterTryingToAddItToTheList()
        {

        }
        [TestMethod]
        public void GivenClientReturnsTrueIfIsInTheList()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The client doesnt exist")]
        public void GivenClientReturnsFalseIfIsNotInTheList()
        {
          }
        [TestMethod]
        public void GivenNameChecksIfIsValid()
        {
        }
        [TestMethod]

        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenNameChecksIfIsNotValid()
        {
        }

        [TestMethod]
        public void GivenPasswordChecksIfIsValid()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 5 and 25")]
        public void GivenPasswordChecksIfIsNotValid()
        {
        }
    }
}

using App;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace ClientTest
{
    [TestClass]
    public class ClientTest
    {
        private Client clientJoe;
        private const String Joe = "Joe";
        private const String thisNameIsTooLong = "thisNameHasMoreThan20Words";
        private const String correctPasword = "1234";
        [TestInitialize]
        public void initialize()
        {
            clientJoe = new Client()
            {
                Name = Joe,
                Password = correctPasword,
            };
        }

        [TestMethod]
        public void clientSignUpCorrectly()
        {
            Assert.IsNotNull(clientJoe);
            Assert.AreEqual(clientJoe.Name, "Joe");
            Assert.AreEqual(clientJoe.Password, "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")] 
        public void nameIsTooLong()
        {
            clientJoe.Name = thisNameIsTooLong;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void nameIsTooShort()
        {
            clientJoe.Name = "";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must be alphanumeric")]
        public void nameMustBeAlphanumeric()
        {
            clientJoe.Name = "";
        }

    }
}

using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Remoting.Channels;

namespace PersonTest
{
    [TestClass]
    public class PersonTest
    {


        private Person clientSample1;
        private Person clientSample2;
        private string validName = "clientName";
        private string invalidName = " ";
        private string validPassword = "S4FEPassWord";
        private string invalidPassword = "nocapitals";


        [TestInitialize]
        public void initialize()
        {
            clientSample1 = new Client();
            clientSample2 = new Client();
        }

        [TestMethod]
        public void givenAValidNameItAssignsIt()
        {

            clientSample1.Name = validName;
            Assert.AreEqual(clientSample1.Name, validName);
        }

        [ExpectedException(typeof(BackEndException), "Name must be alphanumerical")]
        [TestMethod]
        public void givenAnInvalidNameItThrowsABackEndException()
        {
            clientSample1.Name = invalidName;
        }

        //***
        [TestMethod]
        public void givenAValidPasswordItAssignsIt()
        {

            clientSample1.Password = validPassword;
            Assert.AreEqual(clientSample1.Password, validPassword);
        }

        [ExpectedException(typeof(BackEndException), "Password must contain at least one capital letter")]
        [TestMethod]
        public void givenAnInvalidPasswordItThrowsABackEndException()
        {
            clientSample1.Password = invalidPassword;
        }
        [TestMethod]
        public void givenTwoDifferentPersonsItReturnsTheyAreNotEquals()
        {
            clientSample1.Name = "client1Name";
            clientSample2.Name = "client2Name";
            Assert.IsFalse(clientSample1.Equals(clientSample2));
        }
    }
}
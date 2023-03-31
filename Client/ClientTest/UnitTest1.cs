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
        private const String thisPasswordIsTooLong = "thisPasswordIsIncorrectEvenThoughItCointainsAtLeast1NumberAnd1CapitalLetterA";
        private const String correctPasword = "thisIs4Saf3Passw0rd";
        private const String passwordWithoutNumbers = "ThisPasswordIsAlmostPerfect";
        private const String passwordWithoutCapitalLetter = "thispasswordishard2read";
        private const String passwordOnlyWithCapitalLetters = "THISPASSWORDISHARD2READ";
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
            Assert.AreEqual(clientJoe.Password, "thisIs4Saf3Passw0rd");
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
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void passwordIsTooLong()
        {
            clientJoe.Password = thisPasswordIsTooLong;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void passwordIsTooShort()
        {
            clientJoe.Password = "";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least 1 number")]
        public void passwordDoesntContainNumbers()
        {
            
            clientJoe.Password = passwordWithoutNumbers;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one capital letter")]
        public void passwordDoesntContainCapitalLetters()
        {
            clientJoe.Password = passwordWithoutCapitalLetter;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one lower case letter")]
        public void passwordDoesntContainLowerCaselLetters()
        {
            clientJoe.Password = passwordOnlyWithCapitalLetters;
        }



    }
}

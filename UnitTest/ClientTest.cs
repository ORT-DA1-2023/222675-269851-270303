using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ClientTest
    {
        private Client clientSample;
        private const String clientSampleName = "clientSampleName";
        private const String nonAlphanumericalName = "_*";
        private const String thisNameIsTooLong = "thisNameHasMoreThan20Chars";
        private const String thisNameIsTooShort = "ab";
        private const String thisPasswordIsTooLong = "thisPasswordIsIncorrectEvenThoughItCointainsAtLeast1NumberAnd1CapitalLetterA";
        private const String aValidPassword = "4V4lidPassw0rd";
        private const String passwordWithoutNumbers = "ThisPasswordIsAlmostPerfect";
        private const String passwordWithoutCapitalLetter = "thispasswordishard2read";


        [TestInitialize]
        public void initialize()
        {
            clientSample = new Client() { Name = clientSampleName };
        }

        [TestMethod]
        public void givenAValidNameItAssignsItToTheClient()
        {
            clientSample.Name = clientSampleName;
            Assert.AreEqual(clientSampleName, clientSample.Name);
        }

        [TestMethod]
        public void givenAValidPasswordItAssignsItToTheClient()
        {
            clientSample.Password = aValidPassword;
            Assert.AreEqual(clientSample.Password, aValidPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")] 
        public void givenATooLongNameItThrowsABackEndException()
        {
            clientSample.Name = thisNameIsTooLong;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void givenATooShortNameItThrowsABackEndException()
        {
            clientSample.Name = thisNameIsTooShort;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must be alphanumerical")]
        public void givenANonAlphanumericalNameItThrowsABackEndException()
        {
            clientSample.Name = nonAlphanumericalName;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void givenATooLongPasswordItThrowsABackEndException()
        {
            clientSample.Password = thisPasswordIsTooLong;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least 1 number")]
        public void givenAPasswordWithoutNumbersItThrowsABackEndException()
        {
            clientSample.Password = passwordWithoutNumbers;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void givenATooShortPasswordItThrowsABackEndException()
        {
            clientSample.Password = "1";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one capital letter")]
        public void givenAPasswordWithoutCapitalLettersItThrowsABackEndException()
        {
            clientSample.Password = passwordWithoutCapitalLetter;
        }

        [TestMethod]
        public void givenTwoClientsWithTheSameNameItReturnsTheyAreEqual()
        {
            Client anotherClient = new Client()
            {
                Name = clientSampleName,
            };
            Assert.IsTrue(clientSample.Equals(anotherClient));
        }

     

    }
}

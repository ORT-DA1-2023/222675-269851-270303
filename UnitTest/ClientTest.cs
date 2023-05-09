using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Utilities;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ClientTest
    {
        private Client clientSample;
        private const string clientSampleName = "clientSampleName";
        private const string nonAlphanumericalName = "_*/+-";
        private const string thisNameIsTooLong = "thisNameHasMoreThan20Chars";
        private const string thisNameIsTooShort = "ab";
        private const string thisPasswordIsTooLong = "thisPasswordIsIncorrectEvenThoughItCointainsAtLeast1NumberAnd1CapitalLetterA";
        private const string aValidPassword = "4V4lidPassw0rd";
        private const string passwordWithoutNumbers = "ThisPasswordIsNotPerfect";
        private const string passwordWithoutCapitalLetter = "thisp4ssword";


        [TestInitialize]
        public void Initialize()
        {
            clientSample = new Client() { Name = clientSampleName };
        }

        [TestMethod]
        public void GivenValidNameAssignsToClient()
        {
            clientSample.Name = clientSampleName;
            Assert.AreEqual(clientSampleName, clientSample.Name);
        }

        [TestMethod]
        public void GivenValidPasswordAssignsToClient()
        {
            clientSample.Password = aValidPassword;
            Assert.AreEqual(clientSample.Password, aValidPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenTooLongNameThrowsBackEndException()
        {
            clientSample.Name = thisNameIsTooLong;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void GivenTooShortNameThrowsBackEndException()
        {
            clientSample.Name = thisNameIsTooShort;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must be alphanumerical")]
        public void GivenNonAlphanumericalNameThrowsBackEndException()
        {
            clientSample.Name = nonAlphanumericalName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void GivenTooLongPasswordThrowsBackEndException()
        {
            clientSample.Password = thisPasswordIsTooLong;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one number")]
        public void GivenPasswordWithoutNumbersThrowsBackEndException()
        {
            clientSample.Password = passwordWithoutNumbers;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void GivenTooShortPasswordThrowsBackEndException()
        {
            clientSample.Password = "1";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one capital letter")]
        public void GivenPasswordWithoutCapitalLettersThrowsBackEndException()
        {
            clientSample.Password = passwordWithoutCapitalLetter;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must be alphanumerical")]
        public void GivenNonAlphanumericalPasswordThrowsBackEndException()
        {
            clientSample.Password = nonAlphanumericalName;
        }

        [TestMethod]
        public void GivenTwoClientsWithSameNameReturnTheyAreEqual()
        {
            Client client2 = new Client()
            {
                Name = clientSampleName,
            };
            Assert.IsTrue(clientSample.Equals(client2));
        }

        [TestMethod]
        public void GivenClientReturnsRegisterDate()
        {
            DateTimeProvider.Now = DateTime.Now;
            Client client2 = new Client();
            Assert.AreEqual(DateTimeProvider.Now, client2.RegisterDate);
        }

        [TestMethod]
        public void GivenTwoClientsAssignsDifferentDatesToEachOne()
        {
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTime FebruaryFirst2020 = new DateTime(2020, 2, 1);

            DateTimeProvider.Now = JanuaryFirst2020;
            clientSample = new Client();
            Assert.AreEqual(JanuaryFirst2020, clientSample.RegisterDate);

            DateTimeProvider.Now = FebruaryFirst2020;
            Client client2 = new Client();
            Assert.AreEqual(FebruaryFirst2020, client2.RegisterDate);
        }

    }
}

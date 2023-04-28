using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ClientTest
    {
        private Client client1;
        private const String client1Name = "client1Name";
        private const String nonAlphanumericalName = "_*/+-";
        private const String thisNameIsTooLong = "thisNameHasMoreThan20Chars";
        private const String thisNameIsTooShort = "ab";
        private const String thisPasswordIsTooLong = "thisPasswordIsIncorrectEvenThoughItCointainsAtLeast1NumberAnd1CapitalLetterA";
        private const String aValidPassword = "4V4lidPassw0rd";
        private const String passwordWithoutNumbers = "ThisPasswordIsAlmostPerfect";
        private const String passwordWithoutCapitalLetter = "thisp4ssword";


        [TestInitialize]
        public void initialize()
        {
            client1 = new Client() { Name = client1Name };
        }

        [TestMethod]
        public void givenAValidNameItAssignsItToTheClient()
        {
            client1.Name = client1Name;
            Assert.AreEqual(client1Name, client1.Name);
        }

        [TestMethod]
        public void givenAValidPasswordItAssignsItToTheClient()
        {
            client1.Password = aValidPassword;
            Assert.AreEqual(client1.Password, aValidPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")] 
        public void givenATooLongNameItThrowsABackEndException()
        {
            client1.Name = thisNameIsTooLong;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void givenATooShortNameItThrowsABackEndException()
        {
            client1.Name = thisNameIsTooShort;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must be alphanumerical")]
        public void givenANonAlphanumericalNameItThrowsABackEndException()
        {
            client1.Name = nonAlphanumericalName;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void givenATooLongPasswordItThrowsABackEndException()
        {
            client1.Password = thisPasswordIsTooLong;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least 1 number")]
        public void givenAPasswordWithoutNumbersItThrowsABackEndException()
        {
            client1.Password = passwordWithoutNumbers;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password length must be between 5 and 25")]
        public void givenATooShortPasswordItThrowsABackEndException()
        {
            client1.Password = "1";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one capital letter")]
        public void givenAPasswordWithoutCapitalLettersItThrowsABackEndException()
        {
            client1.Password = passwordWithoutCapitalLetter;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must be alphanumerical")]
        public void givenANonAlphanumericalPasswordItThrowsABackEndException()
        {
            client1.Password = nonAlphanumericalName;
        }


        [TestMethod]
        public void givenTwoClientsWithTheSameNameItReturnsTheyAreEqual()
        {
            Client client2 = new Client()
            {
                Name = client1Name,
            };
            Assert.IsTrue(client1.Equals(client2));
        }

        [TestMethod]
        public void givenAClientItReturnsTrueIfTheDateTimeIsCorrect()
        {
            DateTimeProvider.Now = DateTime.Now;
            Client client2 = new Client();
            Assert.AreEqual(DateTimeProvider.Now, client2.RegisterDate);
        }

        [TestMethod]
        public void givenTwoClientsItReturnsTrueIfTheSecondIsCreatedAfterTheFirstOne()
        {
            DateTime JanuaryFirst2020 = new DateTime(2020,1,1);
            DateTime FebruaryFirst2020 = new DateTime(2020, 2, 1);
            DateTimeProvider.Now = JanuaryFirst2020;
            client1 = new Client();
            Assert.AreEqual(JanuaryFirst2020, client1.RegisterDate);

            DateTimeProvider.Now = FebruaryFirst2020;
            Client client2 = new Client();

            Assert.AreEqual(FebruaryFirst2020, client2.RegisterDate);
 
         
        }

    }
}

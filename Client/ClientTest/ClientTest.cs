using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace ClientTest
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
        //private const String passwordOnlyWithCapitalLetters = "THISPASSWORDISHARD2READ";


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
        public void givenAPasswordWithourCapitalLettersItThrowsABackEndException()
        {
            clientSample.Password = passwordWithoutCapitalLetter;
        }

      /*  [TestMethod]
        [ExpectedException(typeof(BackEndException), "Password must contain at least one lower case letter")]
        public void passwordDoesntContainLowerCaselLetters()
        {
            clientSample.Password = passwordOnlyWithCapitalLetters;
        }*/

        [TestMethod]
        public void givenTwoClientsWithTheSameNameItReturnsTheyAreEqual()
        {
            Client anotherClient = new Client()
            {
                Name = clientSampleName,
            };
            Assert.IsTrue(clientSample.Equals(anotherClient));
        }

        [TestMethod]
        public void givenAFigureItAddesItToTheClientOwnFigures()
        {
            Figure fig = new Sphere() { Client = clientSample, Name = "Ring", Radius = 10 };
            Assert.IsTrue(clientSample.OwnedFigures.Count==0);
            clientSample.OwnedFigures.Add(fig);
            Assert.IsNotNull(clientSample.OwnedFigures);
            Assert.IsTrue(clientSample.OwnedFigures.Count == 1);
            Assert.AreEqual(clientSample.OwnedFigures[0], fig);
        }

        [TestMethod]
        public void givenAFigureItRemovesItFromClientOwnFigures()
        {
           
            Figure fig = new Sphere() { Client = clientSample, Name = "Ring", Radius = 10 };
            clientSample.OwnedFigures.Add(fig);
            Assert.IsTrue(clientSample.OwnedFigures.Count == 1);
            clientSample.OwnedFigures.Remove(fig);
            Assert.IsTrue(clientSample.OwnedFigures.Count == 0);

        }

        [TestMethod]
        public void givenAMaterialItAddsItToClientOwnMaterials()
        {
            Material mat = new lambertianMaterial() { Client = clientSample, Name = "Red", Color = new int[] { 255, 0, 0 } };
            Assert.IsTrue(clientSample.OwnedMaterials.Count == 0);
            clientSample.OwnedMaterials.Add(mat);
            Assert.IsTrue(clientSample.OwnedMaterials.Count == 1);
            Assert.AreEqual(clientSample.OwnedMaterials[0], mat);
        }
        [TestMethod]
        public void givenAMaterialItRemovesItFromClientOwnMaterials()
        {
            Material mat = new lambertianMaterial() { Client = clientSample, Name = "Red", Color = new int[] { 255, 0, 0 } };
            clientSample.OwnedMaterials.Add(mat);
            Assert.IsTrue(clientSample.OwnedMaterials.Count == 1);
            clientSample.OwnedMaterials.Remove(mat);
            Assert.IsTrue(clientSample.OwnedMaterials.Count == 0);
        }
        
        [TestMethod]
        public void givenAModelItAddsItToClientOwnModels()
        {
            Figure figure = new Sphere() { Client = clientSample, Name = "Ring", Radius = 10 };
            Material material = new lambertianMaterial() { Client = clientSample, Name = "Red", Color = new int[] { 255, 0, 0 } };
            Model model = new Model() { Client = clientSample, Name = "TestModel", Figure= figure, Material=material };
            Assert.IsTrue(clientSample.OwnedModels.Count == 0);
            clientSample.OwnedModels.Add(model);
            Assert.IsNotNull(clientSample.OwnedModels);
            Assert.IsTrue(clientSample.OwnedModels.Count == 1);
            Assert.AreEqual(clientSample.OwnedModels[0], model);
        }

        [TestMethod]
        public void givenAModelItRemovesItFromClientOwnModels()
        {
            Figure figure = new Sphere() { Client = clientSample, Name = "Ring", Radius = 10 };
            Material material = new lambertianMaterial() { Client = clientSample, Name = "Red", Color = new int[] { 255, 0, 0 } };
            Model model = new Model() { Client = clientSample, Name = "TestModel", Figure = figure, Material = material };
            clientSample.OwnedModels.Add(model);
            Assert.IsTrue(clientSample.OwnedModels.Count == 1);
            clientSample.OwnedModels.Remove(model);
            Assert.IsTrue(clientSample.OwnedModels.Count == 0);
        }

    }
}

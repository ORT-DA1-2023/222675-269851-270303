using App;
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

        [TestMethod]
        public void clientEquals()
        {
            Client clientJoe2 = new Client()
            {
                Name = Joe,
                Password = correctPasword,
            };
            Assert.IsTrue(clientJoe.Equals(clientJoe2));
        }

        [TestMethod]
        public void addFigureToClient()
        {
            Figure fig = new Sphere() { Client = clientJoe, Name = "Ring", Radius = 10 };
            Assert.IsTrue(clientJoe.OwnedFigures.Count==0);
            clientJoe.OwnedFigures.Add(fig);
            Assert.IsNotNull(clientJoe.OwnedFigures);
            Assert.IsTrue(clientJoe.OwnedFigures.Count == 1);
            Assert.AreEqual(clientJoe.OwnedFigures[0], fig);
        }

        [TestMethod]
        public void deleteFigureFromClient()
        {
           
            Figure fig = new Sphere() { Client = clientJoe, Name = "Ring", Radius = 10 };
            clientJoe.OwnedFigures.Add(fig);
            Assert.IsTrue(clientJoe.OwnedFigures.Count == 1);
            clientJoe.OwnedFigures.Remove(fig);
            Assert.IsTrue(clientJoe.OwnedFigures.Count == 0);

        }

        [TestMethod]
        public void addMaterialToClient()
        {
            Material mat = new lambertianMaterial() { Client = clientJoe, Name = "Red", Color = new int[] { 255, 0, 0 } };
            Assert.IsTrue(clientJoe.OwnedMaterials.Count == 0);
            clientJoe.OwnedMaterials.Add(mat);
            Assert.IsTrue(clientJoe.OwnedMaterials.Count == 1);
            Assert.AreEqual(clientJoe.OwnedMaterials[0], mat);
        }
        [TestMethod]
        public void deleteMaterialFromClient()
        {
            Material mat = new lambertianMaterial() { Client = clientJoe, Name = "Red", Color = new int[] { 255, 0, 0 } };
            clientJoe.OwnedMaterials.Add(mat);
            Assert.IsTrue(clientJoe.OwnedMaterials.Count == 1);
            clientJoe.OwnedMaterials.Remove(mat);
            Assert.IsTrue(clientJoe.OwnedMaterials.Count == 0);
        }
        
        [TestMethod]
        public void addModelToClient()
        {
            Figure figure = new Sphere() { Client = clientJoe, Name = "Ring", Radius = 10 };
            Material material = new lambertianMaterial() { Client = clientJoe, Name = "Red", Color = new int[] { 255, 0, 0 } };
            Model model = new Model() { Client = clientJoe, Name = "TestModel", Figure= figure, Material=material };
            Assert.IsTrue(clientJoe.OwnedModels.Count == 0);
            clientJoe.OwnedModels.Add(model);
            Assert.IsNotNull(clientJoe.OwnedModels);
            Assert.IsTrue(clientJoe.OwnedModels.Count == 1);
            Assert.AreEqual(clientJoe.OwnedModels[0], model);
        }

        [TestMethod]
        public void deleteModelFromClient()
        {
            Figure figure = new Sphere() { Client = clientJoe, Name = "Ring", Radius = 10 };
            Material material = new lambertianMaterial() { Client = clientJoe, Name = "Red", Color = new int[] { 255, 0, 0 } };
            Model model = new Model() { Client = clientJoe, Name = "TestModel", Figure = figure, Material = material };
            clientJoe.OwnedModels.Add(model);
            Assert.IsTrue(clientJoe.OwnedModels.Count == 1);
            clientJoe.OwnedModels.Remove(model);
            Assert.IsTrue(clientJoe.OwnedModels.Count == 0);
        }
        

    }
}

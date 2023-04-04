using App;
using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SphereTest
{
    [TestClass]
    public class SphereUnitTest
    {
        private const String Joe = "Joe";
        private const String correctPasword = "thisIs4Saf3Passw0rd";
        private const String thisNameIsTooLong = "thisNameHasMoreThan20Words";
        private Client clientJoe;
        private String figureName = "FigureName";
        private Figure newFigure;

        [TestInitialize]
        public void initialize()
        {
            clientJoe = new Client()
            {
                Name = Joe,
                Password = correctPasword,
            };

            newFigure = new Sphere()
            {
                Name = figureName,
                Client = clientJoe,
                Radius = 10,
            };

        }

        [TestMethod]
        public void CreateFigureCorrectly()
        {
            Assert.IsNotNull(newFigure);
            Assert.IsNotNull(newFigure.Client);
            Assert.AreEqual(newFigure.Name, "FigureName");
            Assert.AreEqual(newFigure.Client.Name, "Joe");
            Assert.AreEqual(newFigure.Client.Password, "thisIs4Saf3Passw0rd");
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void nameIsTooLong()
        {
            newFigure.Name = thisNameIsTooLong;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void nameIsTooShortEmpty()
        {
            newFigure.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void nameIsTooShort2Letters()
        {
            newFigure.Name = "Ab";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name length must be between 3 and 20")]
        public void nameIsTooShort1Letter()
        {
            newFigure.Name = "A";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void radiusIsNegative()
        {
            ((Sphere)newFigure).Radius = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void radiusIsZero()
        {
            ((Sphere)newFigure).Radius = 0;
        }

    }
}

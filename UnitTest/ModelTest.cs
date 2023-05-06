using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System.Drawing;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ModelTests
    {
        public Client client1;
        public Model model1;
        public Model model2;
        public string validName = "A valid Model Name";

        [TestInitialize]
        public void Initialize()
        {
            client1 = new Client()
            {
                Name = "client1Name",
            };
            model1 = new Model();

        }

        [TestMethod]
        public void givenAModelItReturnsItsName()
        {
            model1.Name = validName;
            Assert.AreEqual(model1.Name, validName);
        }

        [TestMethod]
        public void givenABitmapNullItDoesNotAssignsTheModel()
        {
            Bitmap preview = null;
            model1.Preview = preview;
            Assert.AreEqual(model1.Preview, null);
        }

        [TestMethod]
        public void givenAClientItAssignsItAsTheModelOwner()
        {
            model1.Client = client1;
            Assert.AreEqual(model1.Client, client1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void givenAnEmptyNameItThrowsABackEndException()
        {
            model1.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not start or end with spaces")]
        public void givenANameWithSpacesAtTheBeginningItThrowsABackEndException()
        {
            model1.Name = " " + validName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not start or end with spaces")]
        public void givenANameWithSpacesAtTheEndItThrowsABackEndException()
        {
            model1.Name = validName + " ";
        }
        [TestMethod]
        public void givenAModelItReturnsItsFigure()
        {
            Figure figure1 = new Sphere() { Name = "figureName" };
            Model model1 = new Model()
            {
                Client = client1,
                Figure = figure1,
            };
            Assert.AreEqual(model1.Figure, figure1);
        }

        [TestMethod]
        public void givenAModelItReturnsItsMaterial()
        {
            Material material1 = new LambertianMaterial { Client = client1, Name = "materialName" };

            Model model1 = new Model()
            {
                Client = client1,
                Material = material1
            };
            Assert.AreEqual(model1.Material, material1);
        }

    }
}

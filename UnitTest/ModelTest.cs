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
        public Client clientSample1;
        public Model modelSample1;
        public Model modelSample2;
        public readonly string validName = "A valid Model Name";

        [TestInitialize]
        public void Initialize()
        {
            clientSample1 = new Client()
            {
                Name = "clientSampleName",
            };
            modelSample1 = new Model();

        }

        [TestMethod]
        public void GivenModelReturnsItsName()
        {
            modelSample1.Name = validName;
            Assert.AreEqual(modelSample1.Name, validName);
        }

        [TestMethod]
        public void GivenNullBitmapDoesNotAssignToModel()
        {
            Bitmap oldPreview = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            modelSample1.Preview = oldPreview;
            Bitmap newPreview = null;
            modelSample1.Preview = newPreview;
            Assert.AreEqual(modelSample1.Preview, oldPreview);
        }

        [TestMethod]
        public void GivenBitmapNotNullAssignsToModel()
        {
            Bitmap preview = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            modelSample1.Preview = preview;
            Assert.AreEqual(modelSample1.Preview, preview);
        }

        [TestMethod]
        public void GivenClientAssignsItAsModelOwner()
        {
            modelSample1.Client = clientSample1;
            Assert.AreEqual(modelSample1.Client, clientSample1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenEmptyNameThrowsBackEndException()
        {
            modelSample1.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not start or end with spaces")]
        public void GivenNameStartingWithSpaceThrowsBackEndException()
        {
            modelSample1.Name = " " + validName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not start or end with spaces")]
        public void GivenNameEndingWithSpacesThrowsBackEndException()
        {
            modelSample1.Name = validName + " ";
        }
        [TestMethod]
        public void GivenModelReturnsItsFigure()
        {
            Figure figureSample = new Sphere() { Name = "figureName" };
            Model modelSample = new Model()
            {
                Client = clientSample1,
                Figure = figureSample,
            };
            Assert.AreEqual(modelSample.Figure, figureSample);
        }

        [TestMethod]
        public void GivenModelReturnsItsMaterial()
        {
            Material materialSample = new LambertianMaterial { Client = clientSample1, Name = "materialName" };
            Model modelSample = new Model()
            {
                Client = clientSample1,
                Material = materialSample
            };
            Assert.AreEqual(modelSample.Material, materialSample);
        }
        [TestMethod]
        public void GivenModelReturnsToString()
        {
            Figure figureSample = new Sphere() { Name = "figureName" };
            Model modelSample = new Model()
            {
                Client = clientSample1,
                Figure = figureSample,
                Name = validName,
            };
            string expected = $"{validName}({figureSample.Position.X},{figureSample.Position.Y},{figureSample.Position.Z})";
            Assert.AreEqual(modelSample.ToString(), expected);
        }

    }
}

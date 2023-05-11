using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class FigureTest
    {
        private Client clientSample1;
        private Figure figureSample1;
        private readonly string figureSample1Name = "A valid name";
        private readonly Vector3D positionSample = new Vector3D(0, 0, 0);

        [TestInitialize]
        public void Initialize()
        {
            clientSample1 = new Client() { Name = "clientSampleName" };
            figureSample1 = new Sphere() { Client = clientSample1, Name = figureSample1Name };
        }

        [TestMethod]
        public void GivenValidVectorAssignsToFigure()
        {
            figureSample1.Position = positionSample;
            Assert.AreEqual(positionSample, figureSample1.Position);

        }

        [TestMethod]
        public void GivenValidNameAssignsToFigure()
        {
            figureSample1.Name = figureSample1Name;
            Assert.AreEqual(figureSample1Name, figureSample1.Name);
        }

        [TestMethod]
        public void GivenFigureAssignsClientAsOwner()
        {
            figureSample1.Client = clientSample1;
            Assert.AreEqual(figureSample1.Client, clientSample1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameStartingWithSpacesThrowsBackEndException()
        {
            figureSample1.Name = " " + figureSample1Name;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameEndingWithSpacesThrowsBackEndException()
        {
            figureSample1.Name = figureSample1Name + " ";
        }

        [TestMethod]
        public void GivenFigureReturnsItsOwner()
        {
            Assert.AreEqual(figureSample1.Client, clientSample1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not be empty")]
        public void GivenEmptyFigureNameThrowsBackEndException()
        {
            figureSample1.Name = "";
        }
    }
}

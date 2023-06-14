using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class FigureTest
    {
        private Client _clientSample1;
        private Figure _figureSample1;
        private readonly string _figureSample1Name = "A valid name";
        private readonly Vector3D _positionSample = new Vector3D(0, 0, 0);
        private const string _nameClient = "clientSampleName";

        [TestInitialize]
        public void Initialize()
        {
            _clientSample1 = new Client() { Name = _nameClient };
            _figureSample1 = new Sphere() { Client = _clientSample1, Name = _figureSample1Name };
        }

        [TestMethod]
        public void GivenValidVectorAssignsToFigure()
        {
            _figureSample1.Position = _positionSample;
            Assert.AreEqual(_positionSample, _figureSample1.Position);

        }

        [TestMethod]
        public void GivenValidNameAssignsToFigure()
        {
            _figureSample1.Name = _figureSample1Name;
            Assert.AreEqual(_figureSample1Name, _figureSample1.Name);
        }

        [TestMethod]
        public void GivenFigureAssignsClientAsOwner()
        {
            _figureSample1.Client = _clientSample1;
            Assert.AreEqual(_figureSample1.Client, _clientSample1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameStartingWithSpacesThrowsBackEndException()
        {
            _figureSample1.Name = " " + _figureSample1Name;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameEndingWithSpacesThrowsBackEndException()
        {
            _figureSample1.Name = _figureSample1Name + " ";
        }

        [TestMethod]
        public void GivenFigureReturnsItsOwner()
        {
            Assert.AreEqual(_figureSample1.Client, _clientSample1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not be empty")]
        public void GivenEmptyFigureNameThrowsBackEndException()
        {
            _figureSample1.Name = "";
        }
    }
}

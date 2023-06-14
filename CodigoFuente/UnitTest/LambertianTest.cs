using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class LambertianTest
    {
        private LambertianMaterial _materialSample;
        private readonly string _validMaterialName = "LambertianMaterialName";
        private Client _clientSample;
        private readonly string _clientSampleName = "clientSampleName";
        private const string _emptyString = "";
        private readonly Vector3D _validVectorIntersection = new Vector3D(1, 1, 1);
        private readonly Vector3D _validVectorNormal = new Vector3D(0, 0, 2);
        private readonly Colour _colourSample = new Colour(0, 0, 0);
        private const double _validModule = 2.3;
        private HitRecord3D _hitSample;

        [TestInitialize]
        public void Initialize()
        {
            _clientSample = new Client()
            {
                Name = _clientSampleName
            };
            _materialSample = new LambertianMaterial
            {
                Client = _clientSample
            };

            _hitSample = new HitRecord3D()
            {
                Intersection = _validVectorIntersection,
                Normal = _validVectorNormal,
                Attenuation = _colourSample,
                Module = _validModule,
            };
        }
        [TestMethod]
        public void GivenValidNameAssignsToLambertarianMaterial()
        {
            Assert.IsNotNull(_materialSample);
            _materialSample.Name = _validMaterialName;
            Assert.AreEqual(_validMaterialName, _materialSample.Name);

        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenEmptyNameThrowsBackEndException()
        {
            _materialSample.Name = _emptyString;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void GivenNameStartingWithSpaceThrowsBackEndException()
        {
            _materialSample.Name = " " + _validMaterialName;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void GivenNameEndingWithSpaceThrowsBackEndException()
        {
            _materialSample.Name = _validMaterialName + " ";
        }

        [TestMethod]
        public void GivenMaterialReturnsItsClient()
        {
            Assert.AreEqual(_materialSample.Client, _clientSample);
        }

        [TestMethod]
        public void GivenMaterialReturnsItsToString()
        {
            _materialSample.Name = _validMaterialName;
            _materialSample.Attenuation = new Colour(1, 1, 0);
            Assert.AreEqual(_materialSample.ToString(), $"{_validMaterialName} (255,255,0)");
        }

        [TestMethod]
        public void GivenARaySetsItToMaterial()
        {
            Vector3D origin = new Vector3D(0, 0, 1);
            Vector3D direction = new Vector3D(0, 0, 1);
            Ray ray = new Ray(origin, direction);
            _materialSample.Ray = ray;
            Assert.AreEqual(ray, _materialSample.Ray);
        }

        [TestMethod]
        public void GivenRayReflectedVerifiesItsOriginComesFromIntersection()
        {
            Ray reflected = _materialSample.ReflectsTheLight(_hitSample);
            Assert.AreEqual(reflected.Origin, _hitSample.Intersection);
        }
    }
}

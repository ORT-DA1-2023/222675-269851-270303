using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
namespace Render3D.UnitTest
{
    [TestClass]
    public class SphereTest
    {

        private Client _clientSample;
        private readonly String _validSphereName = "Name of the sphere";
        private Sphere _sphereSample;
        private readonly double _validRadius = 2;
        private readonly int _roughnessSample = 0;
        private readonly Vector3D _positionSample = new Vector3D(0, 0, 0);
        private readonly Colour _colourSample = new Colour(1, 0.5, 0.1);
        private const string _clientSampleName = "clientSampleName";
        private const double _radiusSample = 2.3;
        private const double _radiusOne = 1;
        private const double _radiusZero = 0;
        private const double _radiusNegative = -1;
        private const double _minDistance = 0;
        private const double _maxDistance = 2;
        private const double _minDistanceSample = 1;
        private const int _moduleMinZero = 0;
        private const int _moduleMaxZero = 0;
        private double _moduleMaxSample;
        private double _moduleMinSample;
        private Ray _rayIntersectionSample;
        private HitRecord3D _hitRecordSample;


        [TestInitialize]
        public void Initialize()
        {
            _clientSample = new Client() { Name = _clientSampleName };
            _sphereSample = new Sphere();
        }

        [TestMethod]
        public void GivenValidVectorAssignsToFigure()
        {
            _sphereSample.Position = _positionSample;
            Assert.AreEqual(_positionSample, _sphereSample.Position);
        }

        [TestMethod]
        public void GivenSphereCreatedWithConstructorWithAttributesAssignsCorrectlyAllAttributes()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            double radius = _radiusSample;
            Sphere sphere = new Sphere(allOnes, radius);
            Assert.AreEqual(radius, sphere.Radius);
            Assert.AreEqual(sphere.Position, sphere.Position);
        }

        [TestMethod]
        public void GivenValidModuleAndTwoVectorsReturnsHitRecord()
        {
            _rayIntersectionSample = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));
            _moduleMaxSample = _moduleMaxZero;
            _moduleMinSample = _moduleMinZero;
            _hitRecordSample = new HitRecord3D();
            Assert.IsFalse(_hitRecordSample.Equals(_sphereSample.FigureHitRecord(_rayIntersectionSample, _moduleMinSample, _moduleMaxSample, _colourSample, _roughnessSample)));
        }


        [TestMethod]
        public void GivenValidNameAssigndToSphere()
        {
            _sphereSample.Name = _validSphereName;
            Assert.AreEqual(_validSphereName, _sphereSample.Name);

        }

        [TestMethod]
        public void GivenSphereAssignsClientAsOwner()
        {
            _sphereSample.Client = _clientSample;
            Assert.AreEqual(_sphereSample.Client, _clientSample);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void GivenNegativeRadiusThrowsBackEndException()
        {
            _sphereSample.Radius = _radiusNegative;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void GivenZeroRadiusThrowsBackEndException()
        {
            _sphereSample.Radius = _radiusZero;
        }

        [TestMethod]
        public void GivenValidRadiusAssignsItToSphere()
        {
            _sphereSample.Radius = _validRadius;
            Assert.AreEqual(_sphereSample.Radius, _validRadius);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameStartingWithSpacesThrowsBackEndException()
        {
            _sphereSample.Name = " " + _validSphereName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameEndingWithSpacesThrowsBackEndException()
        {
            _sphereSample.Name = _validSphereName + " ";
        }
        [TestMethod]
        public void GivenAFigureReturnsItsToString()
        {
            _sphereSample.Name = _validSphereName;
            _sphereSample.Radius = _validRadius;
            Assert.AreEqual(_sphereSample.ToString(), _validSphereName + " " + _validRadius);
        }
        [TestMethod]
        public void GivenRayWhichHitsASphereReturnsThereWasHit()
        {
            Sphere sphere = new Sphere() { Position = new Vector3D(1, 1, 1), Radius = _radiusOne };
            Vector3D direction = new Vector3D(1, 1, 1);
            Vector3D origin = new Vector3D(0, 0, 0);
            Ray ray = new Ray(origin, direction);
            double minDistance = _minDistance;
            double maxDistance = _maxDistance;

            Assert.IsTrue(sphere.WasHit(ray, minDistance, maxDistance));
        }
        [TestMethod]
        public void GivenRayWhichHitsSphereButNotInRangeReturnsThereWasNoHit()
        {
            Sphere sphere = new Sphere() { Position = new Vector3D(10, 10, 10), Radius = _radiusOne };
            Vector3D direction = new Vector3D(1, 1, 1);
            Vector3D origin = new Vector3D(0, 0, 0);
            Ray ray = new Ray(origin, direction);
            double minDistance = _minDistance;
            double maxDistance = _maxDistance;

            Assert.IsFalse(sphere.WasHit(ray, minDistance, maxDistance));
        }

        [TestMethod]
        public void GivenRayWhichDoesNotHitSphereReturnsFalse()
        {
            Sphere sphere = new Sphere() { Position = new Vector3D(0, 0, 0), Radius = _radiusOne };
            Vector3D direction = new Vector3D(1, 1, 1);
            Vector3D origin = new Vector3D(2, 0, 0);
            Ray ray = new Ray(origin, direction);
            double minDistance = _minDistanceSample;
            double maxDistance = _maxDistance;

            Assert.IsFalse(sphere.WasHit(ray, minDistance, maxDistance));
        }

    }
}

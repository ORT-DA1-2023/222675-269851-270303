using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using System;

using Render3D.BackEnd.Materials;
namespace Render3D.UnitTest
{
    [TestClass]
    public class SphereTest
    {

        private Client clientSample;
        private readonly String validSphereName = "Name of the sphere";
        private Sphere sphereSample;
        private readonly double validRadius = 2;
        private readonly Vector3D positionSample = new Vector3D(0, 0, 0);
        private readonly Colour colourSample = new Colour(1, 0.5, 0.1);

        private double moduleMaxSample;
        private double moduleMinSample;
        private Ray rayIntersectionSample;
        private HitRecord3D hitRecordSample;


        [TestInitialize]
        public void Initialize()
        {
            clientSample = new Client() { Name = "clientSampleName" };
            sphereSample = new Sphere();
        }

        [TestMethod]
        public void GivenValidVectorAssignsToFigure()
        {
            sphereSample.Position = positionSample;
            Assert.AreEqual(positionSample, sphereSample.Position);
        }

        [TestMethod]
        public void GivenSphereCreatedWithConstructorWithAttributesAssignsCorrectlyAllAttributes()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            double radius = 2.3;
            Sphere sphere = new Sphere(allOnes, radius);
            Assert.AreEqual(radius, sphere.Radius);
            Assert.AreEqual(sphere.Position, sphere.Position);
        }

        [TestMethod]
        public void GivenValidModuleAndTwoVectorsReturnsHitRecord()
        {
            rayIntersectionSample = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));
            moduleMaxSample = 0;
            moduleMinSample = 0;
            hitRecordSample = new HitRecord3D();
            Assert.IsFalse(hitRecordSample.Equals(sphereSample.FigureHitRecord(rayIntersectionSample, moduleMinSample, moduleMaxSample, colourSample)));
        }


        [TestMethod]
        public void GivenValidNameAssigndToSphere()
        {
            sphereSample.Name = validSphereName;
            Assert.AreEqual(validSphereName, sphereSample.Name);

        }

        [TestMethod]
        public void GivenSphereAssignsClientAsOwner()
        {
            sphereSample.Client = clientSample;
            Assert.AreEqual(sphereSample.Client, clientSample);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void GivenNegativeRadiusThrowsBackEndException()
        {
            sphereSample.Radius = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void GivenZeroRadiusThrowsBackEndException()
        {
            sphereSample.Radius = 0;
        }

        [TestMethod]
        public void GivenValidRadiusAssignsItToSphere()
        {
            sphereSample.Radius = validRadius;
            Assert.AreEqual(sphereSample.Radius, validRadius);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameStartingWithSpacesThrowsBackEndException()
        {
            sphereSample.Name = " " + validSphereName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void GivenNameEndingWithSpacesThrowsBackEndException()
        {
            sphereSample.Name = validSphereName + " ";
        }
        [TestMethod]
        public void GivenAFigureReturnsItsToString()
        {
            sphereSample.Name = validSphereName;
            sphereSample.Radius= validRadius;
            Assert.AreEqual(sphereSample.ToString(),validSphereName +" "+ validRadius);
        }
        [TestMethod]
        public void GivenRayWhichHitsASphereReturnsThereWasHit()
        {
            Sphere sphere = new Sphere() { Position = new Vector3D(1, 1, 1), Radius = 1 };
            Vector3D direction = new Vector3D(1, 1, 1);
            Vector3D origin = new Vector3D(0, 0, 0);
            Ray ray = new Ray(origin, direction);
            double minDistance = 0;
            double maxDistance = 2;

            Assert.IsTrue(sphere.WasHit(ray, minDistance, maxDistance));
        }
        [TestMethod]
        public void GivenRayWhichHitsSphereButNotInRangeReturnsThereWasNoHit()
        {
            Sphere sphere = new Sphere() { Position = new Vector3D(10, 10, 10), Radius = 1 };
            Vector3D direction = new Vector3D(1, 1, 1);
            Vector3D origin = new Vector3D(0, 0, 0);
            Ray ray = new Ray(origin, direction);
            double minDistance = 0;
            double maxDistance = 2;

            Assert.IsFalse(sphere.WasHit(ray, minDistance, maxDistance));
        }

        [TestMethod]
        public void GivenRayWhichDoesNotHitSphereReturnsFalse()
        {
            Sphere sphere = new Sphere() { Position = new Vector3D(0, 0, 0), Radius = 1 };
            Vector3D direction = new Vector3D(1, 1, 1);
            Vector3D origin = new Vector3D(2, 0, 0);
            Ray ray = new Ray(origin, direction);
            double minDistance = 1;
            double maxDistance = 2;

            Assert.IsFalse(sphere.WasHit(ray, minDistance, maxDistance));
        }

    }
}

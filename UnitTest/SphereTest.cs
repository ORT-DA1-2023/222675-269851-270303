using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class SphereTest
    {

        private Client clientSample;
        private readonly String validSphereName = "Name of the sphere";
        private Sphere newSphericalFigure;
        private readonly double validRadius = 2;
        private readonly Vector3D positionSample = new Vector3D(0, 0, 0);
        private readonly Colour colorSample = new Colour(1, 0.5, 0.1);

        private double moduleMaxSample;
        private double moduleMinSample;
        private Ray rayIntersection;
        private HitRecord3D hitRecord;


        [TestInitialize]
        public void initialize()
        {
            clientSample = new Client() { Name = "client1Name" };

            newSphericalFigure = new Sphere();
        }

        [TestMethod]
        public void givenAValidVectorItAssignsItToTheFigure()
        {
            newSphericalFigure.Position = positionSample;
            Assert.AreEqual(positionSample, newSphericalFigure.Position);
        }

        [TestMethod]
        public void givenASphereCreatedWithTheConstructorWithAttributesItAssignsCorrectlyTheAttributes()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            double radius = 2.3;
            Sphere sphere = new Sphere(allOnes, radius);
            Assert.AreEqual(radius, sphere.Radius);
            Assert.AreEqual(sphere.Position, sphere.Position);
        }

        [TestMethod]
        public void givenAValidModuleAnd2VectorItReturnsAHitRecord()
        {
            rayIntersection = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));
            moduleMaxSample = 0;
            moduleMinSample = 0;
            hitRecord = new HitRecord3D();
            Assert.IsFalse(hitRecord.Equals(newSphericalFigure.FigureHitRecord(rayIntersection, moduleMinSample, moduleMaxSample, colorSample)));
        }


        [TestMethod]
        public void givenAValidNameItAssignsItToTheSphere()
        {
            newSphericalFigure.Name = validSphereName;
            Assert.AreEqual(validSphereName, newSphericalFigure.Name);

        }

        [TestMethod]
        public void givenASphereItAssignsAClientAsItsOwner()
        {
            newSphericalFigure.Client = clientSample;
            Assert.AreEqual(newSphericalFigure.Client, clientSample);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void givenANegativeRadiusItThrowsABackEndException()
        {
            newSphericalFigure.Radius = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The radius must be greater than 0")]
        public void givenAZeroRadiusItThrowsABackEndException()
        {
            newSphericalFigure.Radius = 0;
        }

        [TestMethod]
        public void givenAValidRadiusOfItAssignsItToTheSphere()
        {
            newSphericalFigure.Radius = validRadius;
            Assert.AreEqual(newSphericalFigure.Radius, validRadius);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void givenANameThatStartsWithSpacesItThrowsABackEndException()
        {
            newSphericalFigure.Name = " " + validSphereName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void givenANameThatEndsWithSpacesItThrowsABackEndException()
        {
            newSphericalFigure.Name = validSphereName + " ";
        }
        [TestMethod]
        public void givenARayWhichHitsASphereItReturnsTrue()
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
        public void givenARayWhichHitsASphereButNotInRangeItReturnsFalse()
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
        public void givenARayWhichDoesNotHitASphereItReturnsFalse()
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

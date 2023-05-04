using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class SphereTest
    {
       
        private Client clientSample;
        private String validSphereName = "Name of the sphere";
        private Sphere newSphericalFigure;
        private double validRadius = 2;
        private Vector3D positionSample = new Vector3D(0, 0, 0);
        private Vector3D colorSample = new Vector3D(255, 1, 66);

        private double moduleMaxSample;
        private double moduleMinSample;
        private Ray rayIntersection;
        private HitRecord3D hitRecord;


        [TestInitialize]
        public void initialize()
        {
            clientSample = new Client(){Name = "client1Name"};

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
          Sphere sphere = new Sphere(allOnes,radius);
            Assert.AreEqual (radius, sphere.Radius);
            Assert.AreEqual(sphere.Position, sphere.Position);
        }

        [TestMethod]
        public void givenAValidModuleAnd2VectorItReturnsAHitRecord()
        {
            rayIntersection = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));
            moduleMaxSample = 0;
            moduleMinSample = 0;
            hitRecord = new HitRecord3D();
            Assert.IsFalse(hitRecord.Equals(newSphericalFigure.IsFigureHit(rayIntersection, moduleMinSample, moduleMaxSample, colorSample)));
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
            newSphericalFigure.Name = validSphereName+" ";
        }
    }
}

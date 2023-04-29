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
        private Decimal validRadius = 2;
        private Vector3D positionSample = new Vector3D(0, 0, 0);


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

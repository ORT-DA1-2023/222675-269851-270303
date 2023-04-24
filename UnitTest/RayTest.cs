using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Render3D.UnitTest
{
    [TestClass]
    public class RayTest
    {
        private Vector3D Origin=new Vector3D(1,1,1);
        private Vector3D Direction = new Vector3D(2, 2, 2);
        private Vector3D calculatedVectorPointedAt;
        private Vector3D expectedVectorPointedAt = new Vector3D(3, 3, 3);
        private Ray defaultRay;

        [TestInitialize]
        public void initialize()
        {
          defaultRay= new Ray(Origin,Direction);
        }
        [TestMethod]
        public void givenARayItReturnsTheCorrectVectors()
        {
            Assert.AreEqual(defaultRay.Origin.X,Origin.X);
            Assert.AreEqual(defaultRay.Origin.Y, Origin.Y);
            Assert.AreEqual(defaultRay.Origin.Z, Origin.Z);
            Assert.AreEqual(defaultRay.Direction.X, Direction.X);
            Assert.AreEqual(defaultRay.Direction.Y, Direction.Y);
            Assert.AreEqual(defaultRay.Direction.Z, Direction.Z);
        }
        [TestMethod]
        public void givenARayReturnTheVectorPointedAtAFloat()
        {
            calculatedVectorPointedAt = defaultRay.PointAt(1);
            Assert.AreEqual(calculatedVectorPointedAt.X,expectedVectorPointedAt.X);
            Assert.AreEqual(calculatedVectorPointedAt.Y, expectedVectorPointedAt.Y);
            Assert.AreEqual(calculatedVectorPointedAt.Z, expectedVectorPointedAt.Z);
        }
        [TestMethod]
        public void givenARayItSetsItsDirection()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            defaultRay.Direction = allOnes;
            Assert.AreEqual(allOnes, defaultRay.Direction);
        }
        [TestMethod]
        public void givenARayItSetsItsOrigin()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            defaultRay.Origin = allOnes;
            Assert.AreEqual(allOnes, defaultRay.Origin);
        }
    }
}

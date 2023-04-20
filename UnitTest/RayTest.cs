using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class RayTest
    {
        private Vector3D Origin=new Vector3D(1,1,1);
        private Vector3D Direction = new Vector3D(2, 2, 2);
        private Vector3D vectorPointedAt = new Vector3D(3, 3, 3);
        private Ray defaultRay;

        [TestInitialize]
        public void initialize()
        {
          defaultRay= new Ray(Origin,Direction);
        }
        [TestMethod]
        public void givenARayItAssignsTheCorrectVectors()
        {
            Assert.IsTrue(defaultRay.Origin.Equals(Origin));
            Assert.IsTrue(defaultRay.Direction.Equals(Direction));
        }
        [TestMethod]
        public void givenARayReturnTheVectorPointedAtAFloat()
        {
            Assert.AreEqual(defaultRay.PointAt(1), vectorPointedAt);
        }
    }
}

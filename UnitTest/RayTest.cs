using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class RayTest
    {
        private readonly Vector3D origin = new Vector3D(1, 1, 1);
        private readonly Vector3D direction = new Vector3D(2, 2, 2);
        private Vector3D calculatedVectorPointedAt;
        private readonly Vector3D expectedVectorPointedAt = new Vector3D(3, 3, 3);
        private Ray defaultRay;

        [TestInitialize]
        public void Initialize()
        {
            defaultRay = new Ray(origin, direction);
        }
        [TestMethod]
        public void GivenRayReturnsCorrectVectors()
        {
            Assert.AreEqual(defaultRay.Origin.X, origin.X);
            Assert.AreEqual(defaultRay.Origin.Y, origin.Y);
            Assert.AreEqual(defaultRay.Origin.Z, origin.Z);
            Assert.AreEqual(defaultRay.Direction.X, direction.X);
            Assert.AreEqual(defaultRay.Direction.Y, direction.Y);
            Assert.AreEqual(defaultRay.Direction.Z, direction.Z);
        }
        [TestMethod]
        public void GivenRayReturnVectorPointedAtADouble()
        {
            calculatedVectorPointedAt = defaultRay.PointAt(1);
            Assert.AreEqual(calculatedVectorPointedAt.X, expectedVectorPointedAt.X);
            Assert.AreEqual(calculatedVectorPointedAt.Y, expectedVectorPointedAt.Y);
            Assert.AreEqual(calculatedVectorPointedAt.Z, expectedVectorPointedAt.Z);
        }
        [TestMethod]
        public void GivenRayAssignsItsDirection()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            defaultRay.Direction = allOnes;
            Assert.AreEqual(allOnes, defaultRay.Direction);
        }
        [TestMethod]
        public void GivenRayAssignsItsOrigin()
        {
            Vector3D allOnes = new Vector3D(1, 1, 1);
            defaultRay.Origin = allOnes;
            Assert.AreEqual(allOnes, defaultRay.Origin);
        }
    }
}

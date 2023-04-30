using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class CameraTest
    {
        private Camera cameraSample;
        private Vector3D allOnes;
        private Vector3D allTwos;
        private Vector3D oneTwoThree;
        
        private int validFov = 30;
       
        private const int smallestValidFov = 0;
        private const int largestValidFov = 160;

        private int tooSmallFov = -1;
        private int tooLargeFov = 161;

        [TestInitialize]
        public void Initialize()
        {
            cameraSample = new Camera();
            allOnes = new Vector3D(1, 1, 1);
            allTwos = new Vector3D(2, 2, 2);
            oneTwoThree = new Vector3D(1, 2, 3);
        }

        [TestMethod]
        public void givenAVectorItAssignsItAsLookFrom()
        {
            cameraSample.LookFrom = allOnes;
            Assert.AreEqual(allOnes, cameraSample.LookFrom);
        }

        [TestMethod]
        public void givenAVectorItAssignsItAsLookAt()
        {
            cameraSample.LookAt = allOnes;
            Assert.AreEqual(allOnes, cameraSample.LookAt);
        }

        [TestMethod]
        public void givenAValidFovItAssignsIt()
        {
            cameraSample.Fov = validFov;
            Assert.AreEqual(validFov, cameraSample.Fov);
        }

        [TestMethod]
        public void givenTheLargestValidFovItAssignsIt()
        {
            cameraSample.Fov = largestValidFov;
            Assert.AreEqual(largestValidFov, cameraSample.Fov);
        }
        [TestMethod]
        public void givenTheSmallestValidFovItAssignsIt()
        {
            cameraSample.Fov = smallestValidFov;
            Assert.AreEqual(smallestValidFov, cameraSample.Fov);
        }

        [ExpectedException(typeof(BackEndException), "FoV must be between 0 and 160")]
        [TestMethod]
        public void givenATooSmallFovItThrowsABackendException()
        {
            cameraSample.Fov = tooSmallFov;
        }
        [ExpectedException(typeof(BackEndException), "FoV must be between 0 and 160")]

        [TestMethod]
        public void givenATooLargeFovItThrowsABackendException()
        {
            cameraSample.Fov = tooLargeFov;
        }
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class CameraTest
    {
        private Camera cameraSample;
        private readonly Vector3D allOnes = new Vector3D(1, 1, 1);
        private readonly Vector3D allTwos = new Vector3D(2, 2, 2);
        private readonly Vector3D oneTwoThree = new Vector3D(1, 2, 3);
        private readonly int validFov = 30;

        private const int smallestValidFov = 0;
        private const int largestValidFov = 160;
        private const double validAspectRatio = 1;
        private const double validWidthHalf = 1;
        private const double validHeightHalf = 1;


        private readonly int tooSmallFov = -1;
        private readonly int tooLargeFov = 161;

        [TestInitialize]
        public void Initialize()
        {
            cameraSample = new Camera();
        }

        [TestMethod]
        public void givenAValidWidthHalfItAssingsToTheCamara()
        {
            cameraSample.WidthHalf = validWidthHalf;
            Assert.AreEqual(validWidthHalf, cameraSample.WidthHalf);
        }

        [TestMethod]
        public void grivenAValidFovItCalculatesThetaToAssingsTheCamera()
        {
            double theta = validFov * Math.PI / 180;
            cameraSample.Theta = theta;
            Assert.AreEqual(theta, cameraSample.Theta);
        }

        [TestMethod]
        public void givenAValidHeightHalfItAssingsToTheCamara()
        {
            cameraSample.HeightHalf = validHeightHalf;
            Assert.AreEqual(validHeightHalf, cameraSample.HeightHalf);
        }



        [TestMethod]
        public void givenAValidAspectRatioItAssingsToTheCamera()
        {
            cameraSample.AspectRatio = validAspectRatio;
            Assert.AreEqual(validAspectRatio, cameraSample.AspectRatio);
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


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

        private readonly int smallestValidFov = 0;
        private readonly int largestValidFov = 160;
        private readonly double validAspectRatio = 1;
        private readonly double validWidthHalf = 1;
        private readonly double validHeightHalf = 1;
        private readonly double validLensRadius = 2;
        private readonly double validAperture = 2;

        private readonly int tooSmallFov = -1;
        private readonly int tooLargeFov = 161;

        [TestInitialize]
        public void Initialize()
        {
            cameraSample = new Camera();
        }

        [TestMethod]
        public void GivenValidWidthHalfAssingsToCamera()
        {
            cameraSample.WidthHalf = validWidthHalf;
            Assert.AreEqual(validWidthHalf, cameraSample.WidthHalf);
        }

        [TestMethod]
        public void GivenValidFovAssignsThetaToCamera()
        {
            double theta = validFov * Math.PI / 180;
            cameraSample.Theta = theta;
            Assert.AreEqual(theta, cameraSample.Theta);
        }

        [TestMethod]
        public void GivenValidHeightHalfAssingsToCamara()
        {
            cameraSample.HeightHalf = validHeightHalf;
            Assert.AreEqual(validHeightHalf, cameraSample.HeightHalf);
        }

        [TestMethod]
        public void GivenValidAspectRatioAssingsToCamera()
        {
            cameraSample.AspectRatio = validAspectRatio;
            Assert.AreEqual(validAspectRatio, cameraSample.AspectRatio);
        }

        [TestMethod]
        public void GivenVectorAssignsAsLookFrom()
        {
            cameraSample.LookFrom = allOnes;
            Assert.AreEqual(allOnes, cameraSample.LookFrom);
        }

        [TestMethod]
        public void GivenVectorAssignsAsLookAt()
        {
            cameraSample.LookAt = allOnes;
            Assert.AreEqual(allOnes, cameraSample.LookAt);
        }

        [TestMethod]
        public void GivenValidFovAssignsIt()
        {
            cameraSample.Fov = validFov;
            Assert.AreEqual(validFov, cameraSample.Fov);
        }

        [TestMethod]
        public void GivenAValidLensRadiusAssignsIt()
        {
            cameraSample.LensRadius = validLensRadius;
            Assert.AreEqual(cameraSample.LensRadius, validLensRadius);
        }

        [TestMethod]
        public void GivenLargestValidFovAssignsIt()
        {
            cameraSample.Fov = largestValidFov;
            Assert.AreEqual(largestValidFov, cameraSample.Fov);
        }

        [TestMethod]
        public void GivenSmallestValidFovAssignsIt()
        {
            cameraSample.Fov = smallestValidFov;
            Assert.AreEqual(smallestValidFov, cameraSample.Fov);
        }

        [ExpectedException(typeof(BackEndException), "FoV must be between 0 and 160")]
        [TestMethod]
        public void GivenTooSmallFovThrowsABackendException()
        {
            cameraSample.Fov = tooSmallFov;
        }

        [ExpectedException(typeof(BackEndException), "FoV must be between 0 and 160")]
        [TestMethod]
        public void GivenTooLargeFovThrowsABackendException()
        {
            cameraSample.Fov = tooLargeFov;
        }

        [TestMethod]
        public void GivenCameraCreatedWithConstructorWithParametersToBlurAssignsProperties()
        {
            Camera camera = new Camera(allOnes, allTwos, oneTwoThree, validFov, validAspectRatio, validAperture);
            Assert.IsTrue(allOnes.Equals(camera.LookFrom));
            Assert.IsTrue(allTwos.Equals(camera.LookAt));
            Assert.IsTrue(oneTwoThree.Equals(camera.VectorUp));
            Assert.IsTrue(camera.Fov == validFov);
            Assert.IsTrue(camera.AspectRatio == validAspectRatio);
            Assert.IsTrue(camera.LensRadius == validAperture / 2);
        }

        [TestMethod]
        public void GivenCameraCreatedWithConstructorWithParametersAssignsProperties()
        {
            Camera camera = new Camera(allOnes, allTwos, oneTwoThree, validFov, validAspectRatio);
            Assert.IsTrue(allOnes.Equals(camera.LookFrom));
            Assert.IsTrue(allTwos.Equals(camera.LookAt));
            Assert.IsTrue(oneTwoThree.Equals(camera.VectorUp));
            Assert.IsTrue(camera.Fov == validFov);
            Assert.IsTrue(camera.AspectRatio == validAspectRatio);
        }

    }
}


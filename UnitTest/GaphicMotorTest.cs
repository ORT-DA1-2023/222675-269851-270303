using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Figures;
using System.Drawing;
using System.IO.Pipes;
using System.IO;

namespace Render3D.UnitTest
{
    [TestClass]
    public class GraphicMotorTest
    {
        private GraphicMotor graphicMotorSample;
        private GraphicMotor graphicMotorDefaultSample = new GraphicMotor();
        private const int resolutionHeightSample = 500;
        private const int resolutionHeightSampleDefault = 3;
        private const int negativeResolutionHeightSample = -1;
        private const int zeroResolutionHeightSample = 0;
        private const int pixelSamplingSample = 79;
        private const int pixelSamplingSampleDefault = 50;
        private const int negativePixelSamplingSample = -1;
        private const int zeroPixelSamplingSample = 0;
        private const int maximumDepthSample = 30;
        private const int maximumDepthSampleDefault = 20;
        private const int negativeMaximumDepth = -1;
        private const int zeroMaximumDepth = 0;
        private Scene sceneSample;
        private Bitmap bitmapSample;



        [TestInitialize]
        public void initialize()
        {
            graphicMotorSample = new GraphicMotor();
        }

        [TestMethod]
        public void givenAValidSceneRenderMethodReturnsABitmap()
        {
            //bitmapSample = new Bitmap(ppmStreamSample);
            sceneSample = new Scene();
            Assert.AreEqual(graphicMotorSample.Render(sceneSample), null);
        }


        [TestMethod]
        public void givenAdefaultGraphicMotorItComparesTheDefaultPixelSampling()
        {
            Assert.AreEqual(graphicMotorDefaultSample.PixelSampling, pixelSamplingSampleDefault);
        }

        [TestMethod]
        public void givenAdefaultGraphicMotorItComparesTheDefaultMaximumDepth()
        {
            Assert.AreEqual(graphicMotorDefaultSample.MaximumDepth, maximumDepthSampleDefault);
        }

        [TestMethod]
        public void givenAdefaultGraphicMotorItComparesTheDefaultResolution()
        {
            Assert.AreEqual(graphicMotorDefaultSample.ResolutionHeight, resolutionHeightSampleDefault);
        }

        [TestMethod]
        public void givenAValidResolutionItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.ResolutionHeight = resolutionHeightSample;
            Assert.AreEqual(resolutionHeightSample, graphicMotorSample.ResolutionHeight);
        }

        [TestMethod]
        public void givenAValidPixelSamplingItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.PixelSampling = pixelSamplingSample;
            Assert.AreEqual(pixelSamplingSample, graphicMotorSample.PixelSampling);
        }

        [TestMethod]
        public void givenAValidMaximumDepthItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.MaximumDepth = maximumDepthSample;
            Assert.AreEqual(maximumDepthSample, graphicMotorSample.MaximumDepth);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void givenANegativeMaximumDepthItThrowsABackEndException()
        {
            graphicMotorSample.MaximumDepth = negativeMaximumDepth;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void givenAZeroMaximumDepthItThrowsABackEndException()
        {
            graphicMotorSample.MaximumDepth = zeroMaximumDepth;
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void givenANegativePixelSamplingItThrowsABackEndException()
        {
            graphicMotorSample.PixelSampling = negativePixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void givenAZeroPixelSamplingItThrowsABackEndException()
        {
            graphicMotorSample.PixelSampling = zeroPixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void givenANegativeResolutionItThrowsABackEndException()
        {
            graphicMotorSample.ResolutionHeight = negativeResolutionHeightSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void givenAZeroResolutionItThrowsABackEndException()
        {
            graphicMotorSample.ResolutionHeight = zeroResolutionHeightSample;
        }

    }
}

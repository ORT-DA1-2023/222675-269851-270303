using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System.Drawing;

namespace Render3D.UnitTest
{
    [TestClass]
    public class GraphicMotorTest
    {
        private GraphicMotor graphicMotorSample;
        private Scene sceneSample;

        private const int _resolutionHeightSample = 500;
        private const int _resolutionWidthSampleDefault = 300;
        private const int _negativeResolutionHeightSample = -1;
        private const int _zeroResolutionHeightSample = 0;

        private const int _pixelSamplingSample = 79;
        private const int _pixelSamplingSampleDefault = 50;
        private const int _negativePixelSamplingSample = -1;
        private const int _zeroPixelSamplingSample = 0;

        private const int _maximumDepthSample = 30;
        private const int _maximumDepthSampleDefault = 20;
        private const int _negativeMaximumDepth = -1;
        private const int _zeroMaximumDepth = 0;
        private const int _radiusSample = 3;

        [TestInitialize]
        public void Initialize()
        {
            graphicMotorSample = new GraphicMotor();
        }

        [TestMethod]
        public void GivenValidSceneRenderMethodReturnsBitmap()
        {
            sceneSample = new Scene();
            Assert.AreNotEqual(graphicMotorSample.Render(sceneSample, false), null);
        }

        [TestMethod]
        public void GivenNonEmptySceneCreatesNonNullPreview()
        {
            Model model = new Model()
            {
                Figure = new Sphere() { Position = new Vector3D(0, 0, 0), Radius = _radiusSample },
                Material = new LambertianMaterial() { Attenuation = new Colour(1, 1, 1) },
            };

            GraphicMotor graphicMotor = new GraphicMotor();
            Bitmap bitmap = graphicMotor.RenderModelPreview(model);
            Assert.IsNotNull(bitmap);
        }




        [TestMethod]
        public void GivenAdefaultGraphicMotorItComparesDefaultPixelSampling()
        {
            Assert.AreEqual(graphicMotorSample.PixelSampling, _pixelSamplingSampleDefault);
        }

        [TestMethod]
        public void GivenDefaultGraphicMotorItHasDefaultPixelSampling()
        {
            Assert.AreEqual(graphicMotorSample.PixelSampling, _pixelSamplingSampleDefault);
        }

        [TestMethod]
        public void GivenDefaultGraphicMotorItHasDefaultMaximumDepth()
        {
            Assert.AreEqual(graphicMotorSample.MaximumDepth, _maximumDepthSampleDefault);
        }

        [TestMethod]
        public void GivenDefaultGraphicMotorItHasDefaultResolution()
        {
            Assert.AreEqual(graphicMotorSample.ResolutionWidth, _resolutionWidthSampleDefault);
        }

        [TestMethod]
        public void GivenValidResolutionAssignsToGraphicMotor()
        {
            graphicMotorSample.ResolutionWidth = _resolutionHeightSample;
            Assert.AreEqual(_resolutionHeightSample, graphicMotorSample.ResolutionWidth);
        }

        [TestMethod]
        public void GivenValidPixelSamplingAssignsToGraphicMotor()
        {
            graphicMotorSample.PixelSampling = _pixelSamplingSample;
            Assert.AreEqual(_pixelSamplingSample, graphicMotorSample.PixelSampling);
        }

        [TestMethod]
        public void GivenValidMaximumDepthAssignsToGraphicMotor()
        {
            graphicMotorSample.MaximumDepth = _maximumDepthSample;
            Assert.AreEqual(_maximumDepthSample, graphicMotorSample.MaximumDepth);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void GivenNegativeMaximumDepthThrowsBackEndException()
        {
            graphicMotorSample.MaximumDepth = _negativeMaximumDepth;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The maximum depth must be greater than 0.")]
        public void GivenZeroMaximumDepthThrowsBackEndException()
        {
            graphicMotorSample.MaximumDepth = _zeroMaximumDepth;
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void GivenNegativePixelSamplingThrowsBackEndException()
        {
            graphicMotorSample.PixelSampling = _negativePixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The pixel sampling must be greater than 0.")]
        public void GivenZeroPixelSamplingThrowsBackEndException()
        {
            graphicMotorSample.PixelSampling = _zeroPixelSamplingSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void GivenNegativeResolutionThrowsABackEndException()
        {
            graphicMotorSample.ResolutionWidth = _negativeResolutionHeightSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void GivenZeroResolutionThrowsBackEndException()
        {
            graphicMotorSample.ResolutionWidth = _zeroResolutionHeightSample;
        }

        [TestMethod]
        public void GivenGraphicMotorReturnsAspectRatio()
        {
            GraphicMotor motor = new GraphicMotor() { ResolutionWidth = _resolutionWidthSampleDefault };
            double ratio = motor.AspectRatio();
            Assert.AreEqual(1.5, ratio);
        }
    }
}

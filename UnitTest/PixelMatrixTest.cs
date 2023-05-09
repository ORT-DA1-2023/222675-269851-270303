using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class PixelMatrixTest
    {
        private const int width = 3;
        private const int height = 2;
        private Colour[,] matrixPPMSample;
        private PixelMatrix pixelMatrixSample;

        [TestInitialize]
        public void Initialize()
        {
            pixelMatrixSample = new PixelMatrix();
        }

        [TestMethod]
        public void GivenValidMatrixAssingsToPixelMatrix()
        {
            matrixPPMSample = new Colour[width, height];
            pixelMatrixSample.Matrix = matrixPPMSample;
            Assert.AreEqual(matrixPPMSample, pixelMatrixSample.Matrix);

        }
    }
}

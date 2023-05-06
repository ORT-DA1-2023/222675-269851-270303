using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class PixelMatrixTest
    {
        private const int width = 3;
        private const int height = 2;
        private Colour[,] matrixPPM;
        private PixelMatrix pixelMatrixSample;

        [TestInitialize]
        public void initialize()
        {
            pixelMatrixSample = new PixelMatrix();
        }


        [TestMethod]
        public void givenAValidMatrixItAssingsToThePixelMatrix()
        {
            matrixPPM = new Colour[width, height];
            pixelMatrixSample.Matrix = matrixPPM;
            Assert.AreEqual(matrixPPM, pixelMatrixSample.Matrix);

        }
    }
}

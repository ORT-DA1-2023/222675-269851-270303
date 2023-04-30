using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Drawing;

namespace Render3D.UnitTest
{
    [TestClass]
    public class PixelMatrixTest
    {
        private const int width = 3;
        private const int height = 2;
        private Vector3D[,] matrixPPM;
        private PixelMatrix pixelMatrixSample;

        [TestInitialize]
        public void initialize()
        {
            pixelMatrixSample = new PixelMatrix();
        }


        [TestMethod]
        public void givenAValidMatrixItAssingsToThePixelMatrix()
        {
            matrixPPM = new Vector3D[width,height];
            pixelMatrixSample.Matrix = matrixPPM;
            Assert.AreEqual(matrixPPM,pixelMatrixSample.Matrix);

        }
    }
}

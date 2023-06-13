using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Render3D.UnitTest
{
    [TestClass]
    public class OutputSaverTest
    {/*
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void GivenNullDestinationJPGThrowsBackEndException()
        {
            Bitmap bitmap = new Bitmap(10, 10);

            string destinationPath = null;
            ISavingFormat savingFormat = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, savingFormat);

            outputSaver.Save();
        }

        [TestMethod]
        public void givenBitmapSavesItAsJPG()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            string destinationPath = "C:\\Users\\diego\\OneDrive\\Escritorio\\PRUEBAS DA1\\test.jpg";
            ISavingFormat format = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);
            outputSaver.Save();

            Assert.IsTrue(File.Exists(destinationPath));
            Assert.AreEqual(".jpg", Path.GetExtension(destinationPath).ToLower());

            if (File.Exists(destinationPath))
                File.Delete(destinationPath);
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void GivenBitmapAndInvalidPathThrowsBackEndExceptionCaseJPG()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            string destinationPath = "invalid/path/test.jpg";
            ISavingFormat format = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);

            outputSaver.Save();
        }

        [TestMethod]
        public void GivenBitmapSavesItAsPNG()
        {
            Bitmap bitmap = new Bitmap(10, 10);
            string destinationPath = "C:\\Users\\diego\\OneDrive\\Escritorio\\PRUEBAS DA1\\test.png";
            ISavingFormat format = new PNGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);

            outputSaver.Save();
            Assert.IsTrue(File.Exists(destinationPath));
            Assert.AreEqual(".png", Path.GetExtension(destinationPath).ToLower());

            if (File.Exists(destinationPath)) File.Delete(destinationPath);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void GivenBitmapAndInvalidPathThrowsBackEndExceptionCasePNG()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            string invalidDirectory = "invalid/path/test.png";
            ISavingFormat format = new PNGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, invalidDirectory, format);

            outputSaver.Save();
        }

        [TestMethod]
        public void GivenBitmapSavesItAsPPM()
        {
            Bitmap bitmap = new Bitmap(2, 2);
            string destinationPath = "C:\\Users\\diego\\OneDrive\\Escritorio\\PRUEBAS DA1\\test.ppm";
            ISavingFormat format = new PPMSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, format);

            outputSaver.Save();

            Assert.IsTrue(File.Exists(destinationPath));

            Assert.AreEqual(".ppm", Path.GetExtension(destinationPath).ToLower());
            if (File.Exists(destinationPath))
                File.Delete(destinationPath);
        }*/
    }
}




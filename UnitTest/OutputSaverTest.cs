using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Render3D.BackEnd.IODrivers;
using Render3D.BackEnd.FileFormat;

namespace Render3D.UnitTest
{
    [TestClass]
    public class OutputSaverTest
    {
        Bitmap bitmapSample;


        [TestInitialize]
        public void Initialize()
        {
            bitmapSample = new Bitmap(20, 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Value cannot be null")]
        public void GivenNullDestinationJPGThrowsBackEndException()
        {
            string destinationPath = null;
            ISavingFormat savingFormat = new JPGSavingDriver();
            OutputDriver o = new OutputDriver(savingFormat);
            o.Save(bitmapSample, destinationPath);
        }
        
        [TestMethod]
        public void GivenBitmapSavesItAsJPG()
        {
            string destinationPath = "test.jpg";
            ISavingFormat format = new JPGSavingDriver();
            OutputDriver outputSaver = new OutputDriver(format);
            outputSaver.Save(bitmapSample, destinationPath);

            Assert.IsTrue(File.Exists(destinationPath));
            Assert.AreEqual(".jpg", Path.GetExtension(destinationPath).ToLower());

            if (File.Exists(destinationPath))
                File.Delete(destinationPath);
        }

        
        [TestMethod]
        [ExpectedException(typeof(System.Runtime.InteropServices.ExternalException))]
        public void GivenBitmapAndInvalidPathThrowsBackEndExceptionCaseJPG()
        {
            string destinationPath = "invalid/path/test.jpg";
            ISavingFormat format = new JPGSavingDriver();
            OutputDriver outputSaver = new OutputDriver(format);

            outputSaver.Save(bitmapSample, destinationPath);
        }
        
        [TestMethod]
        public void GivenBitmapSavesItAsPNG()
        {
            string destinationPath = "test.png";
            ISavingFormat format = new PNGSavingDriver();
            OutputDriver outputSaver = new OutputDriver(format);

            outputSaver.Save(bitmapSample, destinationPath);

            Assert.IsTrue(File.Exists(destinationPath));
            Assert.AreEqual(".png", Path.GetExtension(destinationPath).ToLower());

            if (File.Exists(destinationPath)) File.Delete(destinationPath);
        }
        
        [TestMethod]
        [ExpectedException(typeof(System.Runtime.InteropServices.ExternalException))]
        public void GivenBitmapAndInvalidPathThrowsBackEndExceptionCasePNG()
        {
            string invalidDirectory = "invalid/path/test.png";
            ISavingFormat format = new PNGSavingDriver();
            OutputDriver outputSaver = new OutputDriver(format);

            outputSaver.Save(bitmapSample, invalidDirectory);
        }

        [TestMethod]
        public void GivenBitmapSavesItAsPPM()
        {
            string destinationPath = "test.ppm";
            ISavingFormat format = new PPMSavingDriver();
            OutputDriver outputSaver = new OutputDriver(format);

            outputSaver.Save(bitmapSample, destinationPath);

            Assert.IsTrue(File.Exists(destinationPath));

            Assert.AreEqual(".ppm", Path.GetExtension(destinationPath).ToLower());
            if (File.Exists(destinationPath))
                File.Delete(destinationPath);
        }
    }
}




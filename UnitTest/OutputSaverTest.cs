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
    {

        [TestMethod]
        public void givenPPMSavesItAsJPG()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            string destinationPath = "output";
            SavingFormat savingFormat = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, savingFormat);

            outputSaver.Save();

            Assert.IsTrue(File.Exists(destinationPath));
            Assert.AreEqual(ImageFormat.Jpeg, Image.FromFile(destinationPath).RawFormat);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Could not save the file")]
        public void givenNullDestinationThrowsBackEndException()
        {
            Bitmap bitmap = new Bitmap(10, 10);

            string destinationPath = null;
            SavingFormat savingFormat = new JPGSavingFormat();
            OutputSaver outputSaver = new OutputSaver(bitmap, destinationPath, savingFormat);

            outputSaver.Save();
        }

    }
}


using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class LambertianTest
    {
        private LambertianMaterial materialSample;
        private string validMaterialName = "LambertianMaterialName";
        private int[] colorLowerThan = { -1, -1, -1 };
        private int[] colorGreaterThan = { 266, 266, 266 };
        private int[] validColor = { 15, 15, 15 };

        private Client clientSample;
        private string clientSampleName = "client1Name";


        [TestInitialize]
        public void initialize()
        {
            clientSample = new Client()
            {
                Name = clientSampleName
            };
            materialSample = new LambertianMaterial();
            materialSample.Client = clientSample;

        }
        [TestMethod]
        public void givenAValidNameItAssignsItToTheLambertarianMaterial()
        {
            Assert.IsNotNull(materialSample);
            materialSample.Name = validMaterialName;
            Assert.AreEqual(validMaterialName,materialSample.Name);
            
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void givenAnEmptyNameItThrowsABackEndException()
        {
            materialSample.Name = "";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void givenANameThatStartsWithSpaceItThrowsABackEndException()
        {
            materialSample.Name = " "+validMaterialName;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void givenANameThatEndsWithSpaceItThrowsABackEndException()
        {
            materialSample.Name =validMaterialName + " ";
        }
        
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "color cant be lower than 0 or greater than 255")]
        public void givenASmallerThanPossibleRGBItThrowsABackendException()
        { 
            ((LambertianMaterial)materialSample).Color=colorLowerThan;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "color cant be lower than 0 or greater than 255")]
        public void givenABiggerThanPossibleRGBItThrowsABackendException()
        {
            ((LambertianMaterial)materialSample).Color = colorGreaterThan;
        }
        [TestMethod]
        public void givenAValidRGBItAssignsItToTheMaterial()
        {
            materialSample.Color = new int[3];
            for (int i = 0; i < 3; i++)
            {
                materialSample.Color[i] = validColor[i];
                Assert.IsTrue(materialSample.Color[i] == validColor[i]);
            }
        }
        [TestMethod]
        public void givenAMaterialItReturnsItsClient()
        {
            Assert.AreEqual(materialSample.Client, clientSample);
        }

    }
}

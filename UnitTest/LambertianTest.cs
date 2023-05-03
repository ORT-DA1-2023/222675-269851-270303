using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.GraphicMotorUtility;
namespace Render3D.UnitTest
{
    [TestClass]
    public class LambertianTest
    {
        private LambertianMaterial materialSample;
        private string validMaterialName = "LambertianMaterialName";
        private Vector3D colorLowerThan = new Vector3D( -1, -1, -1 );
        private Vector3D colorGreaterThan = new Vector3D(266, 266, 266);
        private Vector3D validColor = new Vector3D(15, 15, 15);

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
            materialSample.Color = new Vector3D (1,2,3);
            Assert.IsTrue(materialSample.Color.X == 1);
            Assert.IsTrue(materialSample.Color.Y == 2);
            Assert.IsTrue(materialSample.Color.Z == 3);

        }
        [TestMethod]
        public void givenAMaterialItReturnsItsClient()
        {
            Assert.AreEqual(materialSample.Client, clientSample);
        }

        [TestMethod]
        public void givenAMaterialReturnsAString()
        {
            materialSample.Name = validMaterialName;
            materialSample.Color = validColor;
            Assert.AreEqual (materialSample.ToString(), validMaterialName+ " ("+ validColor.X+ ","+validColor.Y+","+validColor.Z+")");
        }

    }
}

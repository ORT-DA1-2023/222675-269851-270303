using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class LambertianTest
    {
        private LambertianMaterial materialSample;
        private readonly string validMaterialName = "LambertianMaterialName";

        private Client clientSample;
        private readonly string clientSampleName = "client1Name";


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
            Assert.AreEqual(validMaterialName, materialSample.Name);

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
            materialSample.Name = " " + validMaterialName;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void givenANameThatEndsWithSpaceItThrowsABackEndException()
        {
            materialSample.Name = validMaterialName + " ";
        }

        [TestMethod]
        public void givenAMaterialItReturnsItsClient()
        {
            Assert.AreEqual(materialSample.Client, clientSample);
        }

    }
}

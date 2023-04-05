using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaterialsTests
{
    [TestClass]
    public class LambertianTest
    {
        private string joe = "Joe";
        private string correctPassword = "Hello1234";
        private Material newMaterial;
        private string name = "Lambertian";
        private int[] color = { 15, 15, 15 };
        private int[] colorLowerThan = { -1, -1, -1 };
        private int[] colorGreaterThan = { 266, 266, 266 };
        private Client clientJoe;
        [TestInitialize]
        public void initialize()
        {
            clientJoe = new Client()
            {
                Name = joe,
                Password = correctPassword,
            };
            newMaterial = new lambertianMaterial()
            {
                Name = name,
                Client = clientJoe,
                Color = color,

            };


        }
        [TestMethod]
        public void CreateMaterialCorrectly()
        {
            Assert.IsNotNull(newMaterial);
            Assert.AreEqual(newMaterial.Name, "Lambertian");
            Assert.IsTrue(newMaterial.Client.Equals(clientJoe));
            Assert.AreEqual(((lambertianMaterial)newMaterial).Color,color);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be void")]
        public void nameIsNull()
        {
            newMaterial.Name = "";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void nameStartsWithSpace()
        {
            newMaterial.Name = " "+correctPassword;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void nameEndsWithSpace()
        {
            newMaterial.Name =correctPassword+ " ";
        }
        
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "color cant be lower than 0 or greater than 255")]
        public void colorIsLowerThan()
        { 
            ((lambertianMaterial)newMaterial).Color=colorLowerThan;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "color cant be lower than 0 or greater than 255")]
        public void colorIsGreaterThan()
        {
            ((lambertianMaterial)newMaterial).Color = colorGreaterThan;
        }

    }
}

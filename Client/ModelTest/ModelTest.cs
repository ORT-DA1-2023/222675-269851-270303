using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ModelTest
{
    [TestClass]
    public class ModelTests
    {
        public Client clientJoe;
        public Model model1;
       
        [TestInitialize]
        public void initialize()
        {
            clientJoe = new Client()
            {
                Name = "Joe",
                Password = "correctP4ssw0rd",
            };
            model1 = new Model()
            {
                Name = "model1Name",
                Figure = new Sphere() { Client=clientJoe, Name="figure1Name", Radius=20 },
                Owner = clientJoe,
                Material = new lambertianMaterial() { Client = clientJoe, Name = "material1Name", Color = new int[] { 1, 2, 3 } },
            };
        
        }
        
        [TestMethod]
        public void modelCreationCorrectly()
        {
            Assert.IsNotNull(model1);
            Assert.IsTrue(model1.Owner == clientJoe);
            Assert.IsTrue(model1.Material.Name == "material1Name");
            Assert.IsTrue(model1.Name == "model1Name");
            Assert.IsTrue(model1.Figure.Name == "figure1Name");
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void nameIsNotEmpty()
        {
            model1.Name = "";  
        }
    }
}

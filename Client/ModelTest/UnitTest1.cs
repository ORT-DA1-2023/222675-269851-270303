using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ModelTest
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void modelCreationCorrectly()
        {
            var model = new Model();
            Client client= new Client();
            client.Name = "ownersN4me";
            

            model.Name = "nameModel";
            model.Figure= new Sphere();
            ((Sphere)(model.Figure)).Name = "nameSphere";
            ((Sphere)(model.Figure)).Radius = 10;
            model.Owner= client;
            
            Assert.IsNotNull(model);
            Assert.IsTrue(client.Name== "ownersN4me");
            Assert.IsTrue(model.Name == "nameModel");
            Assert.IsTrue(((Sphere)(model.Figure)).Radius == 10);
            Assert.IsTrue(((Sphere)(model.Figure)).Name == "nameSphere");
            
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void nameIsEmpty()
        {
            var model = new Model();
            model.Name = "";
        }
    }
}

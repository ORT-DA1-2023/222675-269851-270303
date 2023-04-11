using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Remoting;

namespace ModelTest
{
    [TestClass]
    public class ModelTests
    {
        public Client clientSample;
        public Model model1;
        public Model model2;

        public string validName = "A valid Model Name";

        [TestInitialize]
        public void initialize()
        {
            clientSample = new Client()
            {
                Name = "clientSampleName",
            };
            model1 = new Model();

        }
        
        [TestMethod]
        public void givenAClientItAssignsItAsTheModelOwner()
        {
           model1.Client= clientSample;
            Assert.AreEqual(model1.Client, clientSample);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void givenAnEmptyNameItThrowsABackEndException()
        {
            model1.Name = "";  
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not start or end with spaces")]
        public void givenANameWithSpacesAtTheBeginningItThrowsABackEndException()
        {
            model1.Name = " "+validName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not start or end with spaces")]
        public void givenANameWithSpacesAtTheEndItThrowsABackEndException()
        {
            model1.Name = validName+" ";
        }
    }
}

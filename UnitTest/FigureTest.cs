using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using System;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class FigureTest
    {
        private Client client1;
        private Figure figure1;
        private string figure1Name = "A valid name";
        private Vector3D positionSample = new Vector3D(0, 0, 0);


        [TestInitialize]
        public void Initialize()
        {
            client1 = new Client() { Name = "client1Name" };
            figure1 = new Sphere() { Client = client1, Name = figure1Name };
        }

        [TestMethod]
        public void givenAValidVectorItAssignsItToTheFigure()
        {
            figure1.Position = positionSample;
            Assert.AreEqual(positionSample, figure1.Position);

        }



        [TestMethod]
        public void givenAValidNameItAssignsItToTheFigure()
        {
            figure1.Name = figure1Name;
            Assert.AreEqual(figure1Name, figure1.Name);

        }

        [TestMethod]
        public void givenAFigureItAssignsAClientAsItsOwner()
        {
            figure1.Client = client1;
            Assert.AreEqual(figure1.Client, client1);
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void givenANameThatStartsWithSpacesItThrowsABackEndException()
        {
            figure1.Name = " " + figure1Name;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not start or end with spaces")]
        public void givenANameThatEndsWithSpacesItThrowsABackEndException()
        {
            figure1.Name = figure1Name + " ";
        }

        [TestMethod]
        public void givenAFigureItReturnsItsOwner() { 
        Assert.AreEqual(figure1.Client, client1);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The name must not be empty")]
        public void givenAnEmptyFigureNameItShouldThrowABackEndException()
        {
           figure1.Name="";
        }

        [TestMethod]
        public void givenAFigureReturnsAString()
        {
            Assert.AreEqual(figure1.ToString(), figure1Name);
        }

        /*   [TestMethod]
           public void givenAFigureAndAClientItAssignsTheFigureToTheClient()
           {
               Client client2 = new Client() { Name="client2Name"};
               figure1.Client = client2;
               Assert.AreEqual(figure1.Client, client2);
           }*/
    }
}

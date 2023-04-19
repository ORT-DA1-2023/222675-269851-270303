using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Runtime.Remoting.Channels;

namespace Render3D.UnitTest
{
    [TestClass]
    public class SceneTest
    {
        private Scene sceneSample;
        private Client clientSample = new Client() { Name = "Joe", Password = "S4fePassword" };
        private String sceneSampleName = "SceneTest";
        private ArrayList positionedModels = new ArrayList();
        private decimal[] randomCameraPosition = new decimal[3] { 1, 1, 0 };
        private decimal[] DifferentRandomCameraPosition = new decimal[3] { 2, 3, 0 };
        private decimal[] randomObjectPosition = new decimal[3] { 1, 1, 0 };
        private decimal[] DifferentRandomObjectPosition = new decimal[3] { 5, 1, 3 };
        private int randomFoV = 30;
        private Scene defaultSceneSample = new Scene();
        private decimal[] defaultCamaraPosition = new decimal[3] { 0, 2, 0 };
        private decimal[] defaultObjectPosition = new decimal[3] { 0, 2, 5 };


        [TestInitialize]

        public void initialize()
        {
            sceneSample = new Scene(){ Name = sceneSampleName };
        }

        [TestMethod]
        public void givenAValidFieldOfViewItAssignsItToTheScene()
        {
            sceneSample.FieldOfView = randomFoV;
            Assert.AreEqual(sceneSample.FieldOfView, randomFoV);
        }

        [TestMethod]
        public void givenAValidClientItAssignsItToTheScene()
        {
            sceneSample.Client = clientSample;
            Assert.IsTrue(sceneSample.Client.Equals(clientSample));
        }


        [TestMethod]
        public void givenAValidNameItAssignsItToTheScene()
        {
            sceneSample.Name = sceneSampleName;
            Assert.AreEqual(sceneSample.Name, sceneSampleName);
        }

        [TestMethod]
        public void givenAValidPositionedModelsItAssignsItToTheScene()
        {
            sceneSample.PositionedModels = positionedModels;
            Assert.AreEqual(sceneSample.PositionedModels, positionedModels);
        }

        [TestMethod]
        public void givenAValidCameraPositionItAssignsItToTheScene()
        {
            sceneSample.CameraPosition = randomCameraPosition;
            Assert.AreEqual(sceneSample.CameraPosition, randomCameraPosition);
        }

        [TestMethod]
        public void givenAValidObjectPositionItAssignsItToTheScene()
        {
            sceneSample.ObjectPosition = randomObjectPosition;
            Assert.AreEqual(sceneSample.ObjectPosition, randomObjectPosition);
        }


        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void givenAnEmptyNameItThrowsABackEndException()
        {
            sceneSample.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void givenANameThatStartsWithSpacesItThrowsABackEndException()
        {
            sceneSample.Name = " " + sceneSampleName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void givenANameThatEndsWithSpacesItThrowsABackEndException()
        {
            sceneSample.Name = sceneSampleName + " ";
        }

        [TestMethod]
        public void givenAdefaultSceneItComparesTheDefaultFoV()
        {
            Assert.AreEqual(defaultSceneSample.FieldOfView, 30);
        }

        [TestMethod]
        public void givenADefaultSceneItComparesTheDefaultCameraPosition()
        {
            Assert.IsTrue(defaultSceneSample.equalsCameraPosition(defaultCamaraPosition));
        }

        [TestMethod]
        public void givenADefaultSceneItComparesADifferentCameraPosition()
        {
            Assert.IsFalse(defaultSceneSample.equalsCameraPosition(DifferentRandomCameraPosition));
        }

        [TestMethod]
        public void givenADefaultSceneItComparesTheDefaultObjectPosition()
        {
            Assert.IsTrue(defaultSceneSample.equalsObjectPosition(defaultObjectPosition));
        }

        [TestMethod]
        public void givenADefaultSceneItComparesADifferentObjectPosition()
        {
            Assert.IsFalse(defaultSceneSample.equalsObjectPosition(DifferentRandomObjectPosition));
        }





    }
}

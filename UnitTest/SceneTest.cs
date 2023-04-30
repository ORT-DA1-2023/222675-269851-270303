using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Figures;

namespace Render3D.UnitTest
{
    [TestClass]
    public class SceneTest
    {
        private Scene sceneSample;
        private Client clientSample = new Client() { Name = "Joe", Password = "S4fePassword" };
        private String sceneSampleName = "SceneTest";
        private ArrayList positionedModels = new ArrayList();
        private Vector3D randomCameraPosition = new Vector3D(1, 1, 0);
        private Vector3D differentRandomCameraPosition = new Vector3D(2, 3, 0);
        private Vector3D randomObjectivePosition = new Vector3D(1, 1, 0);
        private Vector3D differentRandomObjectivePosition = new Vector3D(5, 1, 3);
        private int randomFoV = 30;
        private Scene defaultSceneSample = new Scene();

  


        [TestInitialize]

        public void initialize()
        {
            sceneSample = new Scene(){ Name = sceneSampleName };
        }

       /* [TestMethod]
        public void givenAValidFieldOfViewItAssignsItToTheScene()
        {
            sceneSample.FieldOfView = randomFoV;
            Assert.AreEqual(sceneSample.FieldOfView, randomFoV);
        }*/

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
        public void givenACameraItAssignsItToTheScene()
        {
            Camera camera = new Camera();
            sceneSample.Camera = camera;
            Assert.AreEqual(sceneSample.Camera, camera);
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
        public void givenTwoCamerasWithDifferentFovsItReturnsTheyAreNotEqual()
        {
            Camera camera1 = new Camera();
            camera1.Fov = 20;
            Camera camera2 = new Camera();
            camera2.Fov = 30;
            Assert.IsFalse(camera1.Equals(camera2));
        }

        [TestMethod]
        public void givenTwoCamerasWithOnlyTheSameFovItReturnsTheyAreNotEqual()
        {
            Camera camera1 = new Camera();
            camera1.Fov = 20;
            camera1.LookAt = new Vector3D (1,1,1);
            camera1.LookFrom = new Vector3D(0,0,0);

            Camera camera2 = new Camera();
            camera2.Fov = 20;
            camera2.LookAt = new Vector3D(2, 2, 2);
            camera2.LookFrom = new Vector3D(-2, -2, -2);
            Assert.IsFalse(camera1.Equals(camera2));
        }

        [TestMethod]
        public void givenTwoEqualCamerasItReturnsTrue()
        {
            Camera camera1 = new Camera();
            camera1.Fov = 20;
            camera1.LookAt = new Vector3D(1, 1, 1);
            camera1.LookFrom = new Vector3D(2, 2, 2);

            Camera camera2 = new Camera();
            camera2.Fov = 20;
            camera2.LookAt = new Vector3D(1, 1, 1);
            camera2.LookFrom = new Vector3D(2, 2, 2);
            bool b = camera1.Equals(camera2);
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void givenAnExistingSceneItUpdatesTheLastModifiedDate()
        {
            Scene scene = new Scene();
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTimeProvider.Now = JanuaryFirst2020;
            scene.UpdateLastModificationDate();
            Assert.AreEqual(JanuaryFirst2020, scene.LastModificationDate);
        }
    }
}

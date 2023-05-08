using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Controllers;
using System.Drawing;
using System.Reflection;

namespace Render3D.UnitTest
{
    [TestClass]
    public class SceneTest
    {
        private Scene sceneSample;
        private readonly string sceneSampleName = "sceneSampleName";
        private readonly Client clientSample = new Client() { Name = "Joe", Password = "S4fePassword" };
        private readonly List<Model> positionedModels = new List<Model>();
        private readonly Vector3D randomCameraPosition = new Vector3D(1, 1, 0);
        private readonly Vector3D differentRandomCameraPosition = new Vector3D(2, 3, 0);
        private readonly Vector3D randomObjectivePosition = new Vector3D(1, 1, 0);
        private readonly Vector3D differentRandomObjectivePosition = new Vector3D(5, 1, 3);
        private readonly int randomFoV = 30;
        private Ray ray;
        private Model model;
        private Material material;
        [TestInitialize]

        public void initialize()
        {
            sceneSample = new Scene() { Name = sceneSampleName };

            Vector3D origin = new Vector3D(0, 0, 0);
            Vector3D direction = new Vector3D(1, 1, 1);
            ray = new Ray(origin, direction);
             material = new LambertianMaterial()
            {
                Attenuation = new Colour(1, 0, 0),
                Ray = ray,
            };
            Figure figure = new Sphere()
            {
                Position = new Vector3D(5, 5, 5),
                Radius = 2,
            };
             model = new Model()
            {
                Figure = figure,
                Material = material,
            };

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
        public void givenASceneItReturnsItsRegisteredDate()
        {
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTimeProvider.Now = JanuaryFirst2020;

            Scene scene = new Scene();
            DateTimeProvider.Reset();

            Assert.AreEqual(JanuaryFirst2020, scene.RegisterDate);
        }

        [TestMethod]
        public void givenASceneItReturnsNullInRenderizationDateIfItWasNeverRendered()
        {
            Scene scene = new Scene();
            Assert.IsNull(scene.LastRenderizationDate);
        }

        [TestMethod]
        public void givenASceneItReturnsItsLastRenderizationDate()
        {
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTime FebruaryFirst2020 = new DateTime(2020, 2, 1);

            DateTimeProvider.Now = JanuaryFirst2020;
            Scene scene = new Scene();

            DateTimeProvider.Now = FebruaryFirst2020;
            scene.UpdateLastRenderizationDate();
            Assert.AreEqual(FebruaryFirst2020, scene.LastRenderizationDate);
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
            camera1.LookAt = new Vector3D(1, 1, 1);
            camera1.LookFrom = new Vector3D(0, 0, 0);

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

        [TestMethod]
        public void givenARayItWithHitAssignsTheHitValues()
        {
            Colour ret = sceneSample.ShootRay(ray, 10, new Random());
            Assert.AreEqual(154, ret.Red());
            Assert.AreEqual(194, ret.Green());
            Assert.AreEqual(255, ret.Blue());

        }

        [TestMethod]
       public void givenASceneItSetsThePreview()
        {
            Scene scene = new Scene();
            Bitmap bitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            scene.Preview=bitmap;
            Assert.AreEqual(bitmap, scene.Preview);
        }
        [TestMethod]
        public void givenASceneItReturnsThePreview()
        {
            Scene scene = new Scene();
            Assert.IsNull(scene.Preview);
            Bitmap bitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            scene.Preview = bitmap;
            Assert.AreEqual(bitmap, scene.Preview);
           
        }

        [TestMethod]
        public void ShootRayWithoutHitDoesNotReturnTheMaterialColour()
        {
            Colour result = sceneSample.ShootRay(ray, 10, new Random());
            sceneSample.PositionedModels.Add(model);

            Colour materialColour = sceneSample.PositionedModels[0].Material.Attenuation;
            Assert.AreNotEqual(materialColour, result);
        }


    }
}

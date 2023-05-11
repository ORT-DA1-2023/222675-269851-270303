using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D.UnitTest
{
    [TestClass]
    public class SceneTest
    {
        private Scene sceneSample;
        private readonly string sceneSampleName = "sceneSampleName";
        private readonly Client clientSample = new Client() { Name = "Joe", Password = "S4fePassword" };
        private readonly List<Model> positionedModels = new List<Model>();
        private Ray raySample;
        private Model modelSample;
        private Material materialSample;

        [TestInitialize]
        public void Initialize()
        {
            sceneSample = new Scene() { Name = sceneSampleName };

            Vector3D origin = new Vector3D(0, 0, 0);
            Vector3D direction = new Vector3D(1, 1, 1);
            raySample = new Ray(origin, direction);
            materialSample = new LambertianMaterial()
            {
                Attenuation = new Colour(1, 0, 0),
                Ray = raySample,
            };
            Figure figure = new Sphere()
            {
                Position = new Vector3D(5, 5, 5),
                Radius = 2,
            };
            modelSample = new Model()
            {
                Figure = figure,
                Material = materialSample,
            };

        }

        [TestMethod]
        public void GivenValidClientAssignsItToScene()
        {
            sceneSample.Client = clientSample;
            Assert.IsTrue(sceneSample.Client.Equals(clientSample));
        }

        [TestMethod]
        public void GivenValidNameAssignsItToScene()
        {
            sceneSample.Name = sceneSampleName;
            Assert.AreEqual(sceneSample.Name, sceneSampleName);
        }

        [TestMethod]
        public void GivenValidPositionedModelsAssignsItToScene()
        {
            sceneSample.PositionedModels = positionedModels;
            Assert.AreEqual(sceneSample.PositionedModels, positionedModels);
        }

        [TestMethod]
        public void GivenCameraAssignsToScene()
        {
            Camera camera = new Camera();
            sceneSample.Camera = camera;
            Assert.AreEqual(sceneSample.Camera, camera);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void GivenEmptyNameThrowsBackEndException()
        {
            sceneSample.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void GivenNameStartingWithSpaceThrowsBackEndException()
        {
            sceneSample.Name = " " + sceneSampleName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void GivenNameEndingWithSpaceThrowsBackEndException()
        {
            sceneSample.Name = sceneSampleName + " ";
        }

        [TestMethod]
        public void GivenSceneReturnsRegisteredDate()
        {
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTimeProvider.Now = JanuaryFirst2020;

            Scene scene = new Scene();
            DateTimeProvider.Reset();

            Assert.AreEqual(JanuaryFirst2020, scene.RegisterDate);
        }

        [TestMethod]
        public void GivenSceneReturnsANullRenderizationDateIfItWasNeverRendered()
        {
            Scene scene = new Scene();
            Assert.IsNull(scene.LastRenderizationDate);
        }

        [TestMethod]
        public void GivenSceneReturnsLastRenderizationDate()
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
        public void GivenTwoCamerasWithDifferentFovsReturnsAreNotEqual()
        {
            Camera camera1 = new Camera();
            camera1.Fov = 20;
            Camera camera2 = new Camera();
            camera2.Fov = 30;

            Assert.IsFalse(camera1.Equals(camera2));
        }

        [TestMethod]
        public void GivenTwoCamerasWithOnlySameFovReturnsAreNotEqual()
        {
            Camera camera1 = new Camera
            {
                Fov = 20,
                LookAt = new Vector3D(1, 1, 1),
                LookFrom = new Vector3D(0, 0, 0)
            };

            Camera camera2 = new Camera
            {
                Fov = 20,
                LookAt = new Vector3D(2, 2, 2),
                LookFrom = new Vector3D(-2, -2, -2)
            };

            Assert.IsFalse(camera1.Equals(camera2));
        }

        [TestMethod]
        public void GivenTwoEqualCamerasReturnsTrue()
        {
            Camera camera1 = new Camera
            {
                Fov = 20,
                LookAt = new Vector3D(1, 1, 1),
                LookFrom = new Vector3D(2, 2, 2)
            };

            Camera camera2 = new Camera
            {
                Fov = 20,
                LookAt = new Vector3D(1, 1, 1),
                LookFrom = new Vector3D(2, 2, 2)
            };

            Assert.IsTrue(camera1.Equals(camera2));
        }

        [TestMethod]
        public void GivenExistingSceneUpdatesLastModificationDate()
        {
            Scene scene = new Scene();
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTimeProvider.Now = JanuaryFirst2020;
            scene.UpdateLastModificationDate();

            Assert.AreEqual(JanuaryFirst2020, scene.LastModificationDate);
        }

        [TestMethod]
        public void GivenRayWithHitAssignsHitValues()
        {
            Colour ret = sceneSample.ShootRay(raySample, 10, new Random());
            Assert.AreEqual(154, ret.Red());
            Assert.AreEqual(194, ret.Green());
            Assert.AreEqual(255, ret.Blue());
        }

        [TestMethod]
        public void GivenBitmapAssignsItToScene()
        {
            Scene scene = new Scene();
            Bitmap bitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            scene.Preview = bitmap;
            Assert.AreEqual(bitmap, scene.Preview);
        }
        [TestMethod]
        public void GivenSceneReturnsItsPreview()
        {
            Scene scene = new Scene();
            Assert.IsNull(scene.Preview);
            Bitmap bitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            scene.Preview = bitmap;
            Assert.AreEqual(bitmap, scene.Preview);

        }

        [TestMethod]
        public void GivenShootRayWithoutHitDoesNotReturnMaterialColour()
        {
            Colour result = sceneSample.ShootRay(raySample, 10, new Random());
            sceneSample.PositionedModels.Add(modelSample);

            Colour materialColour = sceneSample.PositionedModels[0].Material.Attenuation;
            Assert.AreNotEqual(materialColour, result);
        }


    }
}

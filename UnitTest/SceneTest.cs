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
        private Scene _sceneSample;
        private readonly string _sceneSampleName = "sceneSampleName";
        private const string _clientSampleName = "clientSampleName";
        private const string _clientSamplePassword = "S4fePassword";
        private const string _emptyString = "";
        private const int _fovSample30 = 30;
        private const int _fovSample20 = 20;
        private const int _depthSample = 10;
        private const int _widthSample = 1;
        private const int _heightSample = 1;
        private readonly Client _clientSample = new Client() { Name = _clientSampleName, Password = _clientSamplePassword };
        private readonly List<Model> _positionedModels = new List<Model>();
        private Ray _raySample;
        private Model _modelSample;
        private Material _materialSample;

        [TestInitialize]
        public void Initialize()
        {
            _sceneSample = new Scene() { Name = _sceneSampleName };

            Vector3D origin = new Vector3D(0, 0, 0);
            Vector3D direction = new Vector3D(1, 1, 1);
            _raySample = new Ray(origin, direction);
            _materialSample = new LambertianMaterial()
            {
                Attenuation = new Colour(1, 0, 0),
                Ray = _raySample,
            };
            Figure figure = new Sphere()
            {
                Position = new Vector3D(5, 5, 5),
                Radius = 2,
            };
            _modelSample = new Model()
            {
                Figure = figure,
                Material = _materialSample,
            };

        }

        [TestMethod]
        public void GivenValidClientAssignsItToScene()
        {
            _sceneSample.Client = _clientSample;
            Assert.IsTrue(_sceneSample.Client.Equals(_clientSample));
        }

        [TestMethod]
        public void GivenValidNameAssignsItToScene()
        {
            _sceneSample.Name = _sceneSampleName;
            Assert.AreEqual(_sceneSample.Name, _sceneSampleName);
        }

        [TestMethod]
        public void GivenValidPositionedModelsAssignsItToScene()
        {
            _sceneSample.PositionedModels = _positionedModels;
            Assert.AreEqual(_sceneSample.PositionedModels, _positionedModels);
        }

        [TestMethod]
        public void GivenCameraAssignsToScene()
        {
            Camera camera = new Camera();
            _sceneSample.Camera = camera;
            Assert.AreEqual(_sceneSample.Camera, camera);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void GivenEmptyNameThrowsBackEndException()
        {
            _sceneSample.Name = _emptyString;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void GivenNameStartingWithSpaceThrowsBackEndException()
        {
            _sceneSample.Name = " " + _sceneSampleName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void GivenNameEndingWithSpaceThrowsBackEndException()
        {
            _sceneSample.Name = _sceneSampleName + " ";
        }

        [TestMethod]
        public void GivenSceneReturnsRegisteredDate()
        {
            DateTime JanuaryFirst2020 = new DateTime(2020, 1, 1);
            DateTimeProvider.Now = JanuaryFirst2020;

            Scene scene = new Scene();
            DateTimeProvider.Reset();

            Assert.AreEqual(JanuaryFirst2020, scene.CreationDate);
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
            camera1.Fov = _fovSample20;
            Camera camera2 = new Camera();
            camera2.Fov = _fovSample30;

            Assert.IsFalse(camera1.Equals(camera2));
        }

        [TestMethod]
        public void GivenTwoCamerasWithOnlySameFovReturnsAreNotEqual()
        {
            Camera camera1 = new Camera
            {
                Fov = _fovSample20,
                LookAt = new Vector3D(1, 1, 1),
                LookFrom = new Vector3D(0, 0, 0)
            };

            Camera camera2 = new Camera
            {
                Fov = _fovSample20,
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
                Fov = _fovSample20,
                LookAt = new Vector3D(1, 1, 1),
                LookFrom = new Vector3D(2, 2, 2)
            };

            Camera camera2 = new Camera
            {
                Fov = _fovSample20,
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
            Colour ret = _sceneSample.ShootRay(_raySample, _depthSample);
            Assert.AreEqual(154, ret.Red());
            Assert.AreEqual(194, ret.Green());
            Assert.AreEqual(255, ret.Blue());
        }

        [TestMethod]
        public void GivenBitmapAssignsItToScene()
        {
            Scene scene = new Scene();
            Bitmap bitmap = new Bitmap(_widthSample, _heightSample, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            scene.Preview = bitmap;
            Assert.AreEqual(bitmap, scene.Preview);
        }
        [TestMethod]
        public void GivenSceneReturnsItsPreview()
        {
            Scene scene = new Scene();
            Assert.IsNull(scene.Preview);
            Bitmap bitmap = new Bitmap(_widthSample, _heightSample, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            scene.Preview = bitmap;
            Assert.AreEqual(bitmap, scene.Preview);

        }

        [TestMethod]
        public void GivenShootRayWithoutHitDoesNotReturnMaterialColour()
        {
            Colour result = _sceneSample.ShootRay(_raySample, _depthSample);
            _sceneSample.PositionedModels.Add(_modelSample);

            Colour materialColour = _sceneSample.PositionedModels[0].Material.Attenuation;
            Assert.AreNotEqual(materialColour, result);
        }


    }
}

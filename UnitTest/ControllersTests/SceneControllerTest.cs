using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.DataTransferObjects;
using System.Collections.Generic;
using System;
using RepositoryFactory;

namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class SceneControllerTest
    {
        ModelController modelController;
        MaterialController materialController;
        FigureController figureController;
        SceneController sceneController;
        LogController logController;
        RepoFactory repo = new RepoFactory();
        

        [TestInitialize]
        public void Initialize()
        {
            logController = LogController.GetInstance();
            modelController = ModelController.GetInstance();
            materialController = MaterialController.GetInstance();
            figureController = FigureController.GetInstance();           
            sceneController = SceneController.GetInstance();
            repo.Initialize();
            try
            {
                logController.ClientController.Login("ClientTest", "4Testing");
                List<LogDto> logDtos = logController.GetLogs();
                foreach (LogDto log in logDtos)
                {
                    logController.Delete(log);
                }
            }
            catch { }
            try
            {
                sceneController.ClientController.Login("ClientTest", "4Testing");
                List<SceneDto> sceneDtos = sceneController.GetScenes();
                foreach(SceneDto sceneDto in sceneDtos)
                {
                    sceneController.Delete(sceneDto);
                }
            }
            catch { }
            try
            {
                modelController.ClientController.Login("ClientTest", "4Testing");
                List<ModelDto> modelDtos = modelController.GetModels();
                foreach (ModelDto modelDto in modelDtos)
                {
                    modelController.Delete(modelDto);
                }
            }
            catch { }
            try
            {
                figureController.ClientController.Login("ClientTest", "4Testing");
                List<FigureDto> figureDtos = figureController.GetFigures();
                foreach (FigureDto figureDto in figureDtos)
                {
                    figureController.Delete(figureDto);
                }
            }
            catch { }
            try
            {
                materialController.ClientController.Login("ClientTest", "4Testing");
                List<MaterialDto> materialDtos = materialController.GetMaterials();
                foreach (MaterialDto materialDto in materialDtos)
                {
                    materialController.Delete(materialDto);
                }
            }
            catch { }
            try
            {
                materialController.ClientController.RemoveClient("ClientTest");
            }
            catch { }
        }

        [TestMethod]
        public void GivenNewSceneSavesIt()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            Assert.AreEqual(sceneController.GetScenes()[0].Name, "SceneTest");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "scene already exists")]
        public void GivenRepeatedSceneThrowsException()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            sceneController.AddScene("SceneTest");
        }
        [TestMethod]
        public void GivenNewSceneNameItChanges()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            sceneController.ChangeSceneName(sceneController.GetScenes()[0], "SceneTest2");
            Assert.AreEqual(sceneController.GetScenes()[0].Name, "SceneTest2");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "There is already a scene with that name")]
        public void GivenRepeatedSceneNameItDoesNotChange()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            sceneController.AddScene("SceneTest2");
            sceneController.ChangeSceneName(sceneController.GetScenes()[0], "SceneTest2");
        }
        [TestMethod]
        public void GivenNameDeletesScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            sceneController.Delete(sceneController.GetScenes()[0]);
        }

        [TestMethod]
        public void GivenNewCameraWithDifferentLookAtAssignsItToScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            SceneDto sceneDto = sceneController.GetScene("SceneTest");
            string allOnes = "(1;1;1)";
            DateTime beforeChange = sceneDto.LastModificationDate;
            sceneController.EditCamera(sceneDto, allOnes, allOnes, 40,"0");
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            Assert.IsTrue(beforeChange <=sceneDtoV1.LastModificationDate);
            Assert.AreEqual(sceneDtoV1.LookAt[0], 1);
            Assert.AreEqual(sceneDtoV1.Fov, 40);
            double aperture = 0;
            Assert.AreEqual(sceneDtoV1.Aperture, aperture);
        }
        [TestMethod]
        public void GivenNewCameraWithDifferentLookFromAssignsItToScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            SceneDto sceneDto = sceneController.GetScene("SceneTest");
            string allOnes = "(1;1;1)";
            string lookAt = "(0;2;5)";
            DateTime beforeChange = sceneDto.LastModificationDate;
            sceneController.EditCamera(sceneDto, lookAt, allOnes, 40, "4");
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            Assert.IsTrue(beforeChange <= sceneDtoV1.LastModificationDate);
            Assert.AreEqual(sceneDtoV1.LookAt[0], 0);
            Assert.AreEqual(sceneDtoV1.Fov, 40);
            double aperture = 4;
            Assert.AreEqual(sceneDtoV1.Aperture, aperture);
        }
        [TestMethod]
        public void GivenNewCameraWithDifferentApertureAssignsItToScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            SceneDto sceneDto = sceneController.GetScene("SceneTest");
            string lookAt = "(0;2;5)";
            string lookFrom = "(0;2;0)";
            DateTime beforeChange = sceneDto.LastModificationDate;
            sceneController.EditCamera(sceneDto, lookAt, lookFrom, 40, "4");
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            Assert.IsTrue(beforeChange <= sceneDtoV1.LastModificationDate);
            Assert.AreEqual(sceneDtoV1.LookFrom[0], 0);
            Assert.AreEqual(sceneDtoV1.Fov, 40);
            double aperture = 4;
            Assert.AreEqual(sceneDtoV1.Aperture, aperture);
        }
        [TestMethod]
        public void GivenNewCameraWithDifferentFovAssignsItToScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            string lookAt = "(0;2;5)";
            string lookFrom = "(0;2;0)";
            sceneController.EditCamera(sceneDtoV1, lookAt, lookFrom, 40, "4");
            SceneDto sceneDtoV2 = sceneController.GetScene("SceneTest");
            DateTime beforeChange = sceneDtoV2.LastModificationDate;
            sceneController.EditCamera(sceneDtoV2, lookAt, lookFrom, 50, "4");
            SceneDto sceneDtoV3 = sceneController.GetScene("SceneTest");
            Assert.IsTrue(beforeChange <= sceneDtoV1.LastModificationDate);
            Assert.AreEqual(sceneDtoV3.Fov, 50);
            double aperture = 4;
            Assert.AreEqual(sceneDtoV3.Aperture, aperture);
        }
        [TestMethod]
        public void GiventheSameCameraDoesNotAssignsItToScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            string lookAt = "(0;2;5)";
            string lookFrom = "(0;2;0)";
            sceneController.EditCamera(sceneDtoV1, lookAt, lookFrom, 40, "4");
            SceneDto sceneDtoV2 = sceneController.GetScene("SceneTest");
            DateTime beforeChange = sceneDtoV2.LastModificationDate;
            sceneController.EditCamera(sceneDtoV2, lookAt, lookFrom, 40, "4");
            SceneDto sceneDtoV3 = sceneController.GetScene("SceneTest");
            Assert.AreEqual(beforeChange, sceneDtoV3.LastModificationDate);
            Assert.AreEqual(sceneDtoV3.Fov, 40);
            double aperture = 4;
            Assert.AreEqual(sceneDtoV3.Aperture, aperture);
        }

        [TestMethod]
        public void GivenNewModelAddsItToListOfPositionedModels()
        {
            modelController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 0,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            sceneController.AddScene("SceneTest");
            ModelDto model = modelController.GetModels()[0];
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            DateTime beforeChange = sceneDtoV1.LastModificationDate;
            sceneController.AddModel(sceneController.GetScene("SceneTest"), model, "(1;1;1)");
            SceneDto sceneDtoV2 = sceneController.GetScene("SceneTest");
            Assert.IsTrue(beforeChange <= sceneDtoV2.LastModificationDate);
            SceneDto scene = sceneController.GetScene("SceneTest");
            Assert.AreEqual(scene.Models[0].Name, "ModelTest");
        }

        [TestMethod]
        public void GivenModelRemovesItFromListOfPositionedModels()
        {
            modelController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 0,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            sceneController.AddScene("SceneTest");
            ModelDto model = modelController.GetModels()[0];
            sceneController.AddModel(sceneController.GetScene("SceneTest"), model, "(1;1;1)");
            SceneDto sceneDtoV1 = sceneController.GetScene("SceneTest");
            DateTime beforeChange = sceneDtoV1.LastModificationDate;
            sceneController.RemoveModel(sceneDtoV1, sceneController.GetPositionedModels(sceneDtoV1)[0]);
            SceneDto sceneDtoV2 = sceneController.GetScene("SceneTest");
            Assert.IsTrue(beforeChange <= sceneDtoV2.LastModificationDate);
        }
        [TestMethod]
        public void GivenNewModelsGetList()
        {
            modelController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 0,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            Assert.AreEqual(sceneController.GetAvailableModels()[0].Name,"ModelTest");
        }
        [TestMethod]
        public void GivenModelReturnsTrueIfIsInAScene()
        {
            modelController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 0,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            sceneController.AddScene("SceneTest");
            ModelDto model = modelController.GetModels()[0];
            sceneController.AddModel(sceneController.GetScene("SceneTest"), model, "(1;1;1)");
            Assert.IsTrue(sceneController.CheckIfModelIsInAScene(model));
        }
        [TestMethod]
        public void GivenModelReturnsFalseIfIsInAScene()
        {
            modelController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 0,
            });
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest",
                Radius = 10,
            });
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            ModelDto model = modelController.GetModels()[0];
            Assert.IsFalse(sceneController.CheckIfModelIsInAScene(model));
        }
        [TestMethod]
        public void GivenSceneSavesBitmapAfterRender()
        {
            modelController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            sceneController.RenderScene(sceneController.GetScenes()[0], false);
            Assert.IsTrue(sceneController.GetScenes()[0].Preview!=null);
        }


        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                modelController.ClientController.Login("ClientTest", "4Testing");
                List<SceneDto> sceneDtos = sceneController.GetScenes();
                foreach(SceneDto sceneDto in sceneDtos)
                {
                    sceneController.Delete(sceneDto);
                }
            }
            catch { }
            try
            {
                modelController.ClientController.Login("ClientTest", "4Testing");
                List<ModelDto> modelDtos = modelController.GetModels();
                foreach (ModelDto modelDto in modelDtos)
                {
                    modelController.Delete(modelDto);
                }
            }
            catch { }
            try
            {
                figureController.ClientController.Login("ClientTest", "4Testing");
                List<FigureDto> figureDtos = figureController.GetFigures();
                foreach (FigureDto figureDto in figureDtos)
                {
                    figureController.Delete(figureDto);
                }
            }
            catch { }
            try
            {
                materialController.ClientController.Login("ClientTest", "4Testing");
                List<MaterialDto> materialDtos = materialController.GetMaterials();
                foreach (MaterialDto materialDto in materialDtos)
                {
                    materialController.Delete(materialDto);
                }
            }
            catch { }
            try
            {
                materialController.ClientController.RemoveClient("ClientTest");
            }
            catch { }
        }
    }
}

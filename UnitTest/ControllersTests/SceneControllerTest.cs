using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using Render3D.RenderLogic.DataTransferObjects;
using Render3D.RenderLogic.RepoInterface;
using Render3D.RenderLogic.Services;
using renderRepository.RepoImplementation;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class SceneControllerTest
    {
        ModelController modelController;
        ModelService modelService;
        IModelRepo modelRepo;
        MaterialController materialController;
        MaterialService materialService;
        ClientService clientService;
        IMaterialRepo materialRepo;
        IClientRepo clientRepo;
        FigureController figureController;
        FigureService figureService;
        IFigureRepo figureRepo;
        SceneController sceneController;
        SceneService sceneService;
        ISceneRepo sceneRepo;


        [TestInitialize]
        public void Initialize()
        {
            modelController = ModelController.GetInstance();
            modelRepo = new ModelRepo();
            modelService = new ModelService(modelRepo);
            modelController.ModelService = modelService;
            materialController = MaterialController.GetInstance();
            materialRepo = new MaterialRepo();
            clientRepo = new ClientRepo();
            materialService = new MaterialService(materialRepo);
            clientService = new ClientService(clientRepo);
            materialController.ClientController.ClientService = clientService;
            materialController.MaterialService = materialService;
            figureController = FigureController.GetInstance();
            figureRepo = new FigureRepo();
            figureService = new FigureService(figureRepo);
            figureController.ClientController.ClientService = clientService;
            figureController.FigureService = figureService;
            sceneController = SceneController.GetInstance();
            sceneRepo = new SceneRepo();
            sceneService = new SceneService(sceneRepo);
            sceneController.SceneService = sceneService;
            sceneController.ModelService = modelService;
            sceneController.MaterialService = materialService;
            sceneController.FigureService = figureService;
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
        public void GivenNewCameraAssignsItToScene()
        {
            sceneController.ClientController.SignIn("ClientTest", "4Testing");
            sceneController.AddScene("SceneTest");
            SceneDto sceneDto = sceneController.GetScene("SceneTest");
            string allOnes = "(1;1;1)";
            sceneController.EditCamera(sceneDto, allOnes, allOnes, 40,"4");
            SceneDto scene = sceneController.GetScene("SceneTest");
            Assert.AreEqual(scene.LookAt[0], 1);
            Assert.AreEqual(scene.Fov, 40);
            double aperture = 4;
            Assert.AreEqual(scene.Aperture, aperture);
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
            sceneController.AddModel(sceneController.GetScene("SceneTest"), model, "(1;1;1)");
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
            sceneController.RemoveModel(sceneController.GetPositionedModels(sceneController.GetScene("SceneTest"))[0]);
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

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.Services;
using Render3D.RenderLogic.RepoInterface;
using renderRepository.RepoImplementation;
using Render3D.RenderLogic.DataTransferObjects;
using System.Collections.Generic;
using System;

namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class ModelControllerTest
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
        public void GivenNewModelSavesIt()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            Assert.AreEqual(modelController.GetModels()[0].Name, "ModelTest");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "model already exists")]
        public void GivenRepeatedModelThrowsException()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
        }
        [TestMethod]
        public void GivenNewModelNameItChanges()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            modelController.ChangeName(modelController.GetModels()[0], "modelTest2");
            Assert.AreEqual(modelController.GetModels()[0].Name, "modelTest2");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "There is already a model with that name")]
        public void GivenNewModelNameItDoesNotChange()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            modelController.AddAModelWithPreview("ModelTest2", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            modelController.ChangeName(modelController.GetModels()[0], "modelTest2");
        }
        [TestMethod]
        public void GivenNameDeletesTheModel()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            modelController.Delete(modelController.GetModels()[0]);
        }
        [TestMethod]
        public void GivenMaterialCheckIfIsInModel()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            Assert.IsTrue(modelController.CheckIfMaterialIsInAModel(materialController.GetMaterials()[0]));
        }
        [TestMethod]
        public void GivenMaterialCheckIfIsNotInModel()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");    
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 0,
            });
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest2",
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
            List<MaterialDto> materialDtos = materialController.GetMaterials();
            if (materialDtos[0].Name == "materialTest")
            {
                Assert.IsFalse(modelController.CheckIfMaterialIsInAModel(materialDtos[1]));
            }
            else
            {
                Assert.IsFalse(modelController.CheckIfMaterialIsInAModel(materialDtos[0]));
            }
        }
        [TestMethod]
        public void GivenFigureCheckIfIsInModel()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            Assert.IsTrue(modelController.CheckIfFigureIsInAModel(figureController.GetFigures()[0]));
        }
        [TestMethod]
        public void GivenFigureCheckIfIsNotInModel()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
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
            figureController.AddFigure(new FigureDto()
            {
                Name = "figureTest2",
                Radius = 10,
            });
            modelController.AddAModelWithPreview("ModelTest", figureController.GetFigures()[0], materialController.GetMaterials()[0]);
            List<FigureDto> figureDtos = figureController.GetFigures();
            if (figureDtos[0].Name == "figureTest")
            {
                Assert.IsFalse(modelController.CheckIfFigureIsInAModel(figureDtos[1]));
            }
            else
            {
                Assert.IsFalse(modelController.CheckIfFigureIsInAModel(figureDtos[0]));
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                modelController.ClientController.Login("ClientTest", "4Testing");
                List<ModelDto> modelDtos = new List<ModelDto>();
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


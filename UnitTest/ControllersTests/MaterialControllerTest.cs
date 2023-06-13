using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.Services;
using renderRepository.RepoImplementation;
using Render3D.RenderLogic.RepoInterface;
using Render3D.RenderLogic.DataTransferObjects;
using System.Collections.Generic;
using System;

namespace Render3D.UnitTest.ControllersTests
{

    [TestClass]
    public class MaterialControllerTest
    {
        MaterialController materialController;
        MaterialService materialService;
        ClientService clientService;
        IMaterialRepo materialRepo;
        IClientRepo clientRepo;

        [TestInitialize]
        public void Initialize()
        {
            materialController = MaterialController.GetInstance();
            materialRepo = new MaterialRepo();
            clientRepo = new ClientRepo();
            materialService = new MaterialService(materialRepo);
            clientService = new ClientService(clientRepo);
            materialController.ClientController.ClientService = clientService;
            materialController.MaterialService = materialService;
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
        public void GivenNewLambertianMaterialSavesIt()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur =-1, 
            });
            Assert.AreEqual(materialController.GetMaterials()[0].Name, "materialTest");
        }

        [TestMethod]
        public void GivenNewMetallicMaterialSavesIt()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
            Assert.AreEqual(materialController.GetMaterials()[0].Name, "materialTest");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Material already exists")]
        public void GivenNewMaterialItIsAlreadySaved()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
        }
        [TestMethod]
        public void GivenNewMaterialNameItChanges()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
            materialController.ChangeName(materialController.GetMaterials()[0], "materialTest2");
            Assert.AreEqual(materialController.GetMaterials()[0].Name, "materialTest2");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "There is already a material with that name")]
        public void GivenRepeatedMaterialFailsAddingItToTheList()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest2",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
            materialController.ChangeName(materialController.GetMaterials()[0], "materialTest2");
        }
        [TestMethod]
        public void GivenMaterialDeletesIt()
        {
            materialController.ClientController.SignIn("ClientTest", "4Testing");
            materialController.AddMaterial(new MaterialDto()
            {
                Name = "materialTest",
                Red = 255,
                Blue = 255,
                Green = 255,
                Blur = 1,
            });
            List<MaterialDto> listDto = materialController.GetMaterials();
            Assert.AreEqual(listDto.Count, 1);
            materialController.Delete(listDto[0]);
            List<MaterialDto> listDto2 = materialController.GetMaterials();
            Assert.AreEqual(listDto2.Count, 0);

        }
        [TestCleanup]
        public void CleanUp()
        {
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

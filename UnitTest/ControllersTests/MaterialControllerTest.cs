using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.Services;
using renderRepository.RepoImplementation;
using Render3D.RenderLogic.RepoInterface;
using Render3D.RenderLogic.DataTransferObjects;
using System.Collections.Generic;

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
        public void GivenNewLambertianMaterialAddsItToTheList()
        {
        }

        [TestMethod]
        public void GivenNewMetallicMaterialAddsItToTheList()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongLambertianMaterialFailsAddingItToTheList()
        {
           
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "materialSample already exists")]
        public void GivenRepeatedMaterialFailsAddingItToTheList()
        {
          
        }
        [TestMethod]
        public void GivenNewMaterialNameItChanges()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenNewWrongMetallicMaterialFailsAddingItToTheList()
        {
           
        }
        [TestMethod]
        public void GivenNameDeletesTheMaterial()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "lambertialMaterialSample1 already exists")]
        public void GivenRepeatedLambertianMaterialFailsAddingItToTheList()
        {
        }

    }
}

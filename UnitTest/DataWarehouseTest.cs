using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class DataWarehouseTest
    {
        private DataWarehouse dataSample;
        private Client clientSample;
        private Figure figureSample;
        private Material materialSample;
        private Model modelSample;

        [TestInitialize]
        public void Initialize()
        {
            dataSample = new DataWarehouse();
            clientSample = new Client() { Name = "clientSampleName" };
            figureSample = new Sphere() { Client = clientSample, Name = "Ring", Radius = 10 };
            materialSample = new LambertianMaterial() { Client = clientSample, Name = "Red", Attenuation = new Colour(1, 0, 0) };
            modelSample = new Model() { Client = clientSample, Name = "TestModel", Figure = figureSample, Material = materialSample };
        }

        [TestMethod]
        public void GivenFigureAddsItToExistingFigures()
        {
            Assert.IsTrue(dataSample.Figures.Count == 0);
            dataSample.Figures.Add(figureSample);
            Assert.AreEqual(dataSample.Figures[0], figureSample);
            Assert.IsTrue(dataSample.Figures.Count == 1);
        }

        [TestMethod]
        public void GivenFigureRemovesItFromExistingFigures()
        {
            dataSample.Figures.Add(figureSample);
            Assert.IsTrue(dataSample.Figures.Count == 1);
            dataSample.Figures.Remove(figureSample);
            Assert.IsTrue(dataSample.Figures.Count == 0);
        }

        [TestMethod]
        public void GivenMaterialAddsItToExistingMaterials()
        {
            Assert.IsTrue(dataSample.Materials.Count == 0);
            dataSample.Materials.Add(materialSample);
            Assert.IsTrue(dataSample.Materials.Count == 1);
            Assert.IsTrue(dataSample.Materials.Contains(materialSample));
        }

        [TestMethod]
        public void GivenMaterialRemovesItFromExistingMaterials()
        {
            dataSample.Materials.Add(materialSample);
            dataSample.Materials.Remove(materialSample);
            Assert.IsTrue(!dataSample.Materials.Contains(materialSample));
        }

        [TestMethod]
        public void GivenModelAddsItToExistingModels()
        {
            Assert.IsTrue(dataSample.Models.Count == 0);
            dataSample.Models.Add(modelSample);
            Assert.IsTrue(dataSample.Models.Count == 1);
            Assert.IsTrue(dataSample.Models.Contains(modelSample));
        }

        [TestMethod]
        public void GivenModelRemovesItFromExistingModels()
        {
            dataSample.Models.Add(modelSample);
            Assert.IsTrue(dataSample.Models.Count == 1);
            dataSample.Models.Remove(modelSample);
            Assert.IsTrue(dataSample.Models.Count == 0);
        }


        [TestMethod]
        public void GivenClientAddsItToExistingClients()
        {
            Assert.IsTrue(dataSample.Clients.Count == 0);
            dataSample.Clients.Add(clientSample);
            Assert.IsTrue(dataSample.Clients.Count == 1);
            Assert.IsTrue(dataSample.Clients.Contains(clientSample));
        }


        [TestMethod]
        public void GivenClientRemovesItFromExistingClients()
        {
            dataSample.Clients.Add(clientSample);
            dataSample.Clients.Remove(clientSample);
            Assert.IsTrue(dataSample.Clients.Count == 0);
        }

    }
}


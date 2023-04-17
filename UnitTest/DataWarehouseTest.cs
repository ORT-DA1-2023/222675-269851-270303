using Render3D.BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class DataWarehouseTest
    {
        private DataWarehouse data;
        private Client clientSample;
        private Client clientSample2;
        private Figure figureSample;
       private Material materialSample;
        private Model modelSample;

        [TestInitialize]
        public void initialize()
        {
          data= new DataWarehouse();
          clientSample = new Client() { Name="clientSampleName"};
          clientSample2 = new Client() { Name = "clientSample2Name" };
          figureSample = new Sphere() { Client = clientSample, Name = "Ring", Radius = 10 };
          materialSample = new LambertianMaterial() { Client = clientSample, Name = "Red", Color = new int[] { 255, 0, 0 } };
          modelSample = new Model() { Client = clientSample, Name = "TestModel", Figure = figureSample, Material = materialSample };
        }

        [TestMethod]
        public void givenAFigureItAddsItToTheExistingFigures()
        {
            Assert.IsTrue(data.Figures.Count == 0);
            data.Figures.Add(figureSample);
            Assert.AreEqual(data.Figures[0], figureSample);
            Assert.IsTrue(data.Figures.Count == 1);
        }

        [TestMethod]
        public void givenAFigureItRemovesItFromExistingFigures()
        {
            data.Figures.Add(figureSample);
            Assert.IsTrue(data.Figures.Count == 1);
            data.Figures.Remove(figureSample);
            Assert.IsTrue(data.Figures.Count == 0);
        }

        [TestMethod]
        public void givenAMaterialItAddsItToExistingMaterials()
        { 
            Assert.IsTrue(data.Materials.Count == 0);
            data.Materials.Add(materialSample);
            Assert.IsTrue(data.Materials.Count == 1);
            Assert.IsTrue(data.Materials.Contains(materialSample));
        }

        [TestMethod]
        public void givenAMaterialItRemovesItFromExistingMaterials()
        {
            data.Materials.Add(materialSample);
            data.Materials.Remove(materialSample); 
            Assert.IsTrue(!data.Materials.Contains(materialSample));
        }

        [TestMethod]
        public void givenAModelItAddsItToExistingModels()
        {
            Assert.IsTrue(data.Models.Count == 0);
            data.Models.Add(modelSample);
            Assert.IsTrue(data.Models.Count == 1);
            Assert.IsTrue(data.Models.Contains(modelSample));
        }

        [TestMethod]
        public void givenAModelItRemovesItFromExistingModels()
        {
            data.Models.Add(modelSample);
            Assert.IsTrue(data.Models.Count == 1);
            data.Models.Remove(modelSample);
            Assert.IsTrue(data.Models.Count == 0);
        }

    }
}


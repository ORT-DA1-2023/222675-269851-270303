using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{

    [TestClass]
    public class DataTransferObjectTest
    {
        public DataTransferObject dto;
        Client clientSample;
        Figure figureSample;
        Material materialSample;
        Model modelSample;
        Vector3D colorVec= new Vector3D(0,0,0);
        int[] colors = {0,0,0};
        int[] invalidColors = { -1, 0, 0 };

        [TestInitialize]
        public void initialize()
        {
            dto = new DataTransferObject();
            clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            figureSample = new Sphere() { Client = clientSample, Name = "figureSample1", Radius = 5 };
            materialSample = new LambertianMaterial() { Client = clientSample, Name = "materialSample1", Color=colorVec };
            modelSample = new Model() { Client=clientSample, Name ="modelSample1", Figure=figureSample, Material=materialSample }; 
        }


        [TestMethod]
        public void givenANewModelTrysToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWarehouse).Models.Count == 0);
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample,materialSample);
            Assert.AreEqual(modelSample.Name, dto.DataWarehouse.Models[0].Name);
            Assert.IsTrue((dto.DataWarehouse).Models.Count == 1);
        }
        [TestMethod]
        public void givenANewWrongModelDoesNotAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWarehouse).Models.Count == 0);
            dto.tryToAddAModelWithoutPreview("clientSample1", "", figureSample, materialSample);
            Assert.IsTrue((dto.DataWarehouse).Models.Count == 0);
        }
        [TestMethod]
        public void givenANameReturnsTrueIfalreadyExistsThisModel()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample,materialSample);
            Assert.IsTrue(dto.alreadyExistsThisModel("clientSample1", "modelSample1"));
        }
        [TestMethod]
        public void givenANameReturnsFalseIfDoesntExistsThisModel()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample,materialSample);
            Assert.IsFalse(dto.alreadyExistsThisModel("clientSample1", "modelSample2"));
        }

        [TestMethod]
        public void givenANewModelNameItChanges()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample,materialSample);
            Assert.IsTrue(dto.ifPosibleChangeModelName("clientSample1", "modelSample1", "modelSample2"));
            Assert.IsTrue(dto.alreadyExistsThisModel("clientSample1", "modelSample2"));
            Assert.IsFalse(dto.alreadyExistsThisModel("clientSample1", "modelSample1"));
        }
        [TestMethod]
        public void givenANewModelNameItDoesNotChanges()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample, materialSample);
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample2", figureSample, materialSample);
            Assert.IsFalse(dto.ifPosibleChangeModelName("clientSample1", "modelSample1", "modelSample2"));
            Assert.IsTrue(dto.alreadyExistsThisModel("clientSample1", "modelSample2"));
            Assert.IsTrue(dto.alreadyExistsThisModel("clientSample1", "modelSample1"));
        }

        [TestMethod]
        public void givenANameDeletesTheModel()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample, materialSample);
            dto.deleteModelInList("clientSample1", "modelSample1");
            Assert.IsFalse(dto.alreadyExistsThisModel("clientSample1", "modelSample1"));
        }
        [TestMethod]
        public void givenANameDoesNotDeleteTheModel()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAModelWithoutPreview("clientSample1", "modelSample1", figureSample,materialSample);
            dto.deleteModelInList("clientSample1", "modelSample3");
            Assert.IsTrue(dto.alreadyExistsThisModel("clientSample1", "modelSample1"));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{

    [TestClass]
    public class DataTransferObjectTest
    {
        public DataTransferObject dto;
        Client clientSample;
        Figure figureSample;
        Material materialSample;
        int[] colors = {0,0,0};
        int[] invalidColors = { -1, 0, 0 };

        [TestInitialize]
        public void initialize()
        {
            dto = new DataTransferObject();
            clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            figureSample = new Sphere() { Client = clientSample, Name = "figureSample1", Radius = 5 };
            materialSample = new LambertianMaterial() { Client = clientSample, Name = "materialSample1", Color=colors };
        }
        [TestMethod]
        public void givenANewClientReturnsTrueAfterAddingItToTheList()
        {
            Assert.IsTrue((dto.DataWarehouse).Clients.Count == 0);
            Assert.IsTrue(dto.ifPosibleSignIn("clientSample1", "PasswordExample1"));
            Assert.IsTrue(clientSample.Equals((dto.DataWarehouse).Clients[0]));
            Assert.IsTrue((dto.DataWarehouse).Clients.Count == 1);
        }
        [TestMethod]
        public void givenANewWrongClientReturnsFalseAfterTryingToAddItToTheList()
        {
            Assert.IsTrue((dto.DataWarehouse).Clients.Count == 0);
            Assert.IsFalse(dto.ifPosibleSignIn("", ""));
            Assert.IsTrue((dto.DataWarehouse).Clients.Count == 0);
        }

        [TestMethod]
        public void givenAClientReturnsTrueIfitAlreadyExists()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(dto.alreadyExistsThisClient("clientSample1", "PasswordExample1"));
        }
        [TestMethod]
        public void givenAClientReturnsFalseIfitAlreadyExists()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsFalse(dto.alreadyExistsThisClient("clientSample2", "PasswordExample1"));
        }

        [TestMethod]
        public void givenANewFigureTrysToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWarehouse).Figures.Count == 0);
            Assert.IsTrue(dto.tryToAddAFigure("clientSample1", "figureSample1", 5));
            Assert.AreEqual(figureSample.Name, dto.DataWarehouse.Figures[0].Name);
            Assert.AreEqual(((Sphere)figureSample).Radius, ((Sphere)dto.DataWarehouse.Figures[0]).Radius);
            Assert.IsTrue((figureSample.Client).Equals(dto.DataWarehouse.Figures[0].Client));
            Assert.IsTrue((dto.DataWarehouse).Figures.Count == 1);
        }

        [TestMethod]
        public void givenANewWrongFigureFailsTryingToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWarehouse).Figures.Count == 0);
            Assert.IsFalse(dto.tryToAddAFigure("clientSample1", "figureSample1", -5));
            Assert.IsTrue((dto.DataWarehouse).Figures.Count == 0);
        }
        [TestMethod]
        public void givenANameChecksIfIsValid()
        {
            Assert.IsTrue(dto.checkName("clientSample1"));
        }
        [TestMethod]
        public void givenANameChecksIfIsNotValid()
        {
            Assert.IsFalse(dto.checkName(""));
        }

        [TestMethod]
        public void givenAPasswordChecksIfIsValid()
        {
            Assert.IsTrue(dto.checkPassword("clientSample1"));
        }
        [TestMethod]
        public void givenAPasswordChecksIfIsNotValid()
        {
            Assert.IsFalse(dto.checkPassword(""));
        }
        [TestMethod]
        public void givenANameReturnsTrueIfalreadyExistsThisFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAFigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameReturnsFalseIfDoesntExistsThisFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAFigure("clientSample1", "figureSample1", 1);
            Assert.IsFalse(dto.alreadyExistsThisFigure("clientSample1", "figureSample2"));
        }
        [TestMethod]
        public void givenANewFigureNameItChanges()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAFigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(dto.ifPosibleChangeFigureName("clientSample1", "figureSample1", "figureSample2"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample2"));
            Assert.IsFalse(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANewFigureNameItDoesNotChange()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAFigure("clientSample1", "figureSample1", 1);
            dto.tryToAddAFigure("clientSample1", "figureSample2", 1);
            Assert.IsFalse(dto.ifPosibleChangeFigureName("clientSample1", "clientSample1", "figureSample2"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample2"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameDeletesTheFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAFigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(dto.ifPosibleDeleteFigure("clientSample1", "figureSample1"));
            Assert.IsFalse(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameDoesNotDeleteTheFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAFigure("clientSample1", "figureSample1", 1);
            Assert.IsFalse(dto.ifPosibleDeleteFigure("clientSample1", "figureSample3"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }

        [TestMethod]
        public void givenANameReturnsTrueIfalreadyExistsThisMaterial()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAMaterial("clientSample1", "materialSample1", colors);
            Assert.IsTrue(dto.alreadyExistsThisMaterial("clientSample1", "materialSample1"));
        }
        [TestMethod]
        public void givenANameReturnsFalseIfDoesntExistsThisMatrial()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(dto.tryToAddAMaterial("clientSample1", "materialSample1", colors));
            Assert.IsFalse(dto.alreadyExistsThisMaterial("clientSample1", "materialSample2"));
        }

        [TestMethod]
        public void givenANewMaterialTrysToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWarehouse).Materials.Count == 0);
            Assert.IsTrue(dto.tryToAddAMaterial("clientSample1", "materialSample1", colors));
            Assert.AreEqual(materialSample.Name, dto.DataWarehouse.Materials[0].Name);
            Assert.AreEqual(((LambertianMaterial)materialSample).Color, ((LambertianMaterial)dto.DataWarehouse.Materials[0]).Color);
            Assert.IsTrue((materialSample.Client).Equals(dto.DataWarehouse.Materials[0].Client));
            Assert.IsTrue((dto.DataWarehouse).Materials.Count == 1);
        }

        [TestMethod]
        public void givenANewWrongMaterialFailsTryingToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWarehouse).Materials.Count == 0);
            Assert.IsFalse(dto.tryToAddAMaterial("clientSample1", "materialSample1", invalidColors));
            Assert.IsTrue((dto.DataWarehouse).Materials.Count == 0);
        }
        [TestMethod]
        public void givenANewMaterialNameItChanges()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAMaterial("clientSample1", "materialSample1", colors);
            Assert.IsTrue(dto.ifPosibleChangeMaterialName("clientSample1", "materialSample1", "materialSample2"));
            Assert.IsTrue(dto.alreadyExistsThisMaterial("clientSample1", "materialSample2"));
            Assert.IsFalse(dto.alreadyExistsThisMaterial("clientSample1", "materialSample1"));
        }
        [TestMethod]
        public void givenANewMaterialNameItDoesNotChange()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAMaterial("clientSample1", "materialSample1", colors);
            dto.tryToAddAMaterial("clientSample1", "materialSample2", colors);
            Assert.IsFalse(dto.ifPosibleChangeMaterialName("clientSample1", "materialSample1", "materialSample2"));
            Assert.IsTrue(dto.alreadyExistsThisMaterial("clientSample1", "materialSample2"));
            Assert.IsTrue(dto.alreadyExistsThisMaterial("clientSample1", "materialSample1"));
        }

        [TestMethod]
        public void givenANameDeletesTheMaterial()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAMaterial("clientSample1", "materialSample1", colors);
            Assert.IsTrue(dto.ifPosibleDeleteMaterial("clientSample1", "materialSample1"));
            Assert.IsFalse(dto.alreadyExistsThisMaterial("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameDoesNotDeleteTheMaterial()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAMaterial("clientSample1", "materialSample1", colors);
            Assert.IsFalse(dto.ifPosibleDeleteMaterial("clientSample1", "materialSample3"));
            Assert.IsTrue(dto.alreadyExistsThisMaterial("clientSample1", "materialSample1"));
        }
    }
}

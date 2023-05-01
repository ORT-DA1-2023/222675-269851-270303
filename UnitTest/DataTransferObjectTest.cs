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
        int[] colors = {0,0,0};

        [TestInitialize]
        public void initialize()
        {
            dto = new DataTransferObject();
            clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            figureSample = new Sphere() { Client = clientSample, Name = "figureSample1", Radius = 5 };
        }
        [TestMethod]
        public void givenANewClientReturnsTrueAfterAddingItToTheList()
        {
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 0);
            Assert.IsTrue(dto.ifPosibleSignIn("clientSample1", "PasswordExample1"));
            Assert.IsTrue(clientSample.Equals((dto.DataWareHouse).Clients[0]));
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 1);
        }
        [TestMethod]
        public void givenANewWrongClientReturnsFalseAfterTryingToAddItToTheList()
        {
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 0);
            Assert.IsFalse(dto.ifPosibleSignIn("", ""));
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 0);
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
            Assert.IsTrue((dto.DataWareHouse).Figures.Count == 0);
            Assert.IsTrue(dto.tryToAddAfigure("clientSample1", "figureSample1", 5));
            Assert.AreEqual(figureSample.Name, dto.DataWareHouse.Figures[0].Name);
            Assert.AreEqual(((Sphere)figureSample).Radius, ((Sphere)dto.DataWareHouse.Figures[0]).Radius);
            Assert.IsTrue((figureSample.Client).Equals(dto.DataWareHouse.Figures[0].Client));
            Assert.IsTrue((dto.DataWareHouse).Figures.Count == 1);
        }

        [TestMethod]
        public void givenANewWrongFigureFailsTryingToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue((dto.DataWareHouse).Figures.Count == 0);
            Assert.IsFalse(dto.tryToAddAfigure("clientSample1", "figureSample1", -5));
            Assert.IsTrue((dto.DataWareHouse).Figures.Count == 0);
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
            dto.tryToAddAfigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameReturnsFalseIfDoesntExistsThisFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAfigure("clientSample1", "figureSample1", 1);
            Assert.IsFalse(dto.alreadyExistsThisFigure("clientSample1", "figureSample2"));
        }
        [TestMethod]
        public void givenANewNameItChanges()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAfigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(dto.ifPosibleChangeFigureName("clientSample1", "figureSample1", "figureSample2"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample2"));
            Assert.IsFalse(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANewNameItDoesNotChangeIt()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAfigure("clientSample1", "figureSample1", 1);
            dto.tryToAddAfigure("clientSample1", "figureSample2", 1);
            Assert.IsFalse(dto.ifPosibleChangeFigureName("clientSample1", "clientSample1", "figureSample2"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample2"));
            Assert.IsTrue(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameDeletesTheFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAfigure("clientSample1", "figureSample1", 1);
            Assert.IsTrue(dto.ifPosibleDeleteFigure("clientSample1", "figureSample1"));
            Assert.IsFalse(dto.alreadyExistsThisFigure("clientSample1", "figureSample1"));
        }
        [TestMethod]
        public void givenANameDoesNotDeleteTheFigure()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample1");
            dto.tryToAddAfigure("clientSample1", "figureSample1", 1);
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
    }
}

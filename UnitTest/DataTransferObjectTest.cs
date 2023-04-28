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

        [TestInitialize]
        public void initialize()
        {
            dto = new DataTransferObject();
            clientSample = new Client() {Name= "clientSample1", Password="PasswordSample1" };
            figureSample = new Sphere() { Client= clientSample,Name = "figureSample1", Radius = 5 };
        }
        [TestMethod]
        public void givenANewClientitAddsItToTheExistingClients()
        {
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 0);
            dto.transferClientForCreation("clientSample1", "PasswordExample");
            Assert.IsTrue(clientSample.Equals((dto.DataWareHouse).Clients[0]));
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 1);
        }
        [TestMethod]
        public void givenANewClientReturnsTrueAfterAddingItToTheList()
        {
            Assert.IsTrue((dto.DataWareHouse).Clients.Count == 0);
            Assert.IsTrue(dto.ifPosibleSignIn("clientSample1", "PasswordExample"));
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
            dto.ifPosibleSignIn("clientSample1", "PasswordExample");
            Assert.IsTrue(dto.AlreadyExistsThisClient("clientSample1", "PasswordExample"));
        }
        [TestMethod]
        public void givenAClientReturnsFalseIfitAlreadyExists()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample");
            Assert.IsFalse(dto.AlreadyExistsThisClient("clientSample2", "PasswordExample"));
        }
        [TestMethod]
        public void givenAFigureTrysToAddItToTheList()
        {
            dto.ifPosibleSignIn("clientSample1", "PasswordExample");
            Assert.IsTrue((dto.DataWareHouse).Figures.Count == 0);
            dto.transferFigureForCreation(clientSample, "figureSample1", 5);
            Assert.AreEqual(figureSample.Name, dto.DataWareHouse.Figures[0].Name);
            Assert.AreEqual(((Sphere)figureSample).Radius, ((Sphere)dto.DataWareHouse.Figures[0]).Radius);
            Assert.IsTrue((figureSample.Client).Equals(dto.DataWareHouse.Figures[0].Client));
            Assert.IsTrue((dto.DataWareHouse).Figures.Count == 1);

        }
    }
}

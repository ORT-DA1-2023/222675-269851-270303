using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Controllers;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest.ControllersTests
{
   
    [TestClass]
    public class MaterialControllerTest
    {
        private DataWarehouse _dataWarehouse;
        private MaterialController _materialController;
        private ClientController _clientController;
        private Client _clientSample;
        private Material _materialSample;
        private Colour _color= new Colour(0,0,0);
        private int[] _colorArray = new int[] { 0, 0, 0 };

        [TestInitialize]
        public void initialize()
        {
            _dataWarehouse = new DataWarehouse();
            _clientController = new ClientController() { DataWarehouse = _dataWarehouse };
            _materialController = new MaterialController() { DataWarehouse = _dataWarehouse, ClientController = _clientController };
            _clientSample = new Client() { Name = "clientSample1", Password = "PasswordSample1" };
            _materialSample = new LambertianMaterial() { Client = _clientSample, Name = "materialSample1",Attenuation =_color};
        }
        [TestMethod]
        public void GivenANewMaterialAddsItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenANewWrongMaterialFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddMaterial("clientSample1", "", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "material already exists")]
        public void GivenARepeatedMaterialFailsAddingItToTheList()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }
        [TestMethod]
        public void givenANewMaterialNameItChanges()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            _materialController.ChangeMaterialName("clientSample1", "materialSample1", "materialSample2");
            Assert.IsTrue(_materialController.DataWarehouse.Materials[0].Name == "materialSample2");

        }
        [TestMethod]
        public void givenANewMaterialNameItDoesNotChange()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            _materialController.AddMaterial("clientSample1", "materialSample2", _colorArray);
            _materialController.ChangeMaterialName("clientSample1", "materialSample1", "materialSample2");
            Assert.IsTrue(_materialController.DataWarehouse.Materials[0].Name == "materialSample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials[1].Name == "materialSample2");
        }
        [TestMethod]
        public void GivenANameDeletesTheMaterial()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
            _materialController.DeleteMaterialInList("clientSample1", "materialSample1");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 0);
        }
        [TestMethod]
        public void GivenANameDoesNotDeleteTheMaterial()
        {
            _clientController.SignIn("clientSample1", "PasswordExample1");
            _materialController.AddMaterial("clientSample1", "materialSample1", _colorArray);
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
            _materialController.DeleteMaterialInList("clientSample1", "materialSample2");
            Assert.IsTrue(_materialController.DataWarehouse.Materials.Count == 1);
        }

    }
}

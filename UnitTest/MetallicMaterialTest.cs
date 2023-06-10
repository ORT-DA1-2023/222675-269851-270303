﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class MetallicMaterialTest
    {
        private MetallicMaterial materialSample;
        private readonly string validMaterialName = "MetallicMaterialName";

        private Client clientSample;
        private readonly string clientSampleName = "clientSampleName";
        private readonly double blurSample = 0.5;
        private HitRecord3D hitSample;

        [TestInitialize]
        public void Initialize()
        {
            clientSample = new Client()
            {
                Name = clientSampleName
            };
            materialSample = new MetallicMaterial
            {
                Client = clientSample
            };

            hitSample = new HitRecord3D()
            {
                Intersection = new Vector3D(1, 1, 1),
                Normal = new Vector3D(0, 0, 2),
                Attenuation = new Colour(0, 0, 0),
                Module = 2.3,
            };
        }

        [TestMethod]
        public void GivenValidNameAssignsToMetallicMaterial()
        {
            Assert.IsNotNull(materialSample);
            materialSample.Name = validMaterialName;
            Assert.AreEqual(validMaterialName, materialSample.Name);

        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name must not be empty")]
        public void GivenEmptyNameThrowsBackEndException()
        {
            materialSample.Name = "";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void GivenNameStartingWithSpaceThrowsBackEndException()
        {
            materialSample.Name = " " + validMaterialName;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with space")]
        public void GivenNameEndingWithSpaceThrowsBackEndException()
        {
            materialSample.Name = validMaterialName + " ";
        }

        [TestMethod]
        public void GivenMaterialReturnsItsClient()
        {
            Assert.AreEqual(materialSample.Client, clientSample);
        }

        [TestMethod]
        public void GivenMaterialReturnsItsToString()
        {
            materialSample.Name = validMaterialName;
            materialSample.Attenuation = new Colour(1, 1, 0);
            Assert.AreEqual(materialSample.ToString(), $"{validMaterialName} (255,255,0)");
        }

        [TestMethod]
        public void GivenARaySetsItToMaterial()
        {
            Vector3D origin = new Vector3D(0, 0, 1);
            Vector3D direction = new Vector3D(0, 0, 1);
            Ray ray = new Ray(origin, direction);
            materialSample.Ray = ray;
            Assert.AreEqual(ray, materialSample.Ray);
        }

        
        [TestMethod]
        public void GivenABlurSetsItToMetallicMaterial()
        {
            materialSample.Blur = blurSample;
            Assert.AreEqual(blurSample, materialSample.Blur);
        }
    }
}
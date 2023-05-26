using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class MetallicMaterialTest
    {
        private LambertianMaterial materialSample;
        private readonly string validMaterialName = "LambertianMaterialName";

        private Client clientSample;
        private readonly string clientSampleName = "clientSampleName";
        private HitRecord3D hitSample;

        [TestInitialize]
        public void Initialize()
        {
            clientSample = new Client()
            {
                Name = clientSampleName
            };
            materialSample = new LambertianMaterial
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
        public void TestMethod1()
        {
        }
    }
}

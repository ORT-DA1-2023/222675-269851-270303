using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class HitRecordTest
    {
        private HitRecord3D hitRecordSample;
        private double moduleSample;
        private Vector3D intersectionSample;
        private Vector3D normalSample;

        [TestInitialize]
        public void initialize()
        {
            hitRecordSample = new HitRecord3D();
        }

        [TestMethod]
        public void givenValidAtributesItAssingsToTheHitRecord()
        {
            moduleSample = 1;
            intersectionSample = new Vector3D(0, 0, 0);
            normalSample = new Vector3D(0, 0, 0);
            hitRecordSample = new HitRecord3D(moduleSample, intersectionSample, normalSample);
            Assert.AreEqual(moduleSample, hitRecordSample.Module);
            Assert.AreEqual(intersectionSample, hitRecordSample.Intersection);
            Assert.AreEqual(normalSample, hitRecordSample.Normal);
        }

        [TestMethod]
        public void givenAValidModuleItAssingsToTheHitRecord()
        {
            moduleSample = 1;
            hitRecordSample.Module = moduleSample;
            Assert.AreEqual(moduleSample, hitRecordSample.Module);
        }

        [TestMethod]
        public void givenAValidIntersectionItAssingsToTheHitRecord()
        {
            intersectionSample = new Vector3D(0, 0, 0);
            hitRecordSample.Intersection = intersectionSample;
            Assert.AreEqual(intersectionSample, hitRecordSample.Intersection);
        }

        [TestMethod]
        public void givenAValidNormalItAssingsToTheHitRecord()
        {
            normalSample = new Vector3D(0, 0, 0);
            hitRecordSample.Normal = normalSample;
            Assert.AreEqual(normalSample, hitRecordSample.Normal);
        }
    }
}

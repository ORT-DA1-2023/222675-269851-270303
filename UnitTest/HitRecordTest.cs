using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class HitRecordTest
    {
        private HitRecord3D hitRecordSample;
        private double moduleSample;
        private Vector3D intersectionSample;
        private Vector3D normalSample;
        private Colour attenuationSample;

        [TestInitialize]
        public void Initialize()
        {
            hitRecordSample = new HitRecord3D();
        }

        [TestMethod]
        public void GivenValidAtributesAssingsToHitRecord()
        {
            moduleSample = 1;
            intersectionSample = new Vector3D(0, 0, 0);
            normalSample = new Vector3D(0, 0, 0);
            hitRecordSample = new HitRecord3D(moduleSample, intersectionSample, normalSample, attenuationSample);
            Assert.AreEqual(moduleSample, hitRecordSample.Module);
            Assert.AreEqual(intersectionSample, hitRecordSample.Intersection);
            Assert.AreEqual(normalSample, hitRecordSample.Normal);
            Assert.AreEqual(attenuationSample, hitRecordSample.Attenuation);
        }

        [TestMethod]
        public void GivenValidAttenuationAssingsToHitRecord()
        {
            attenuationSample = new Colour(7 / 255, 234 / 255, 34 / 255);
            hitRecordSample.Attenuation = attenuationSample;
            Assert.AreEqual(attenuationSample, hitRecordSample.Attenuation);
        }

        [TestMethod]
        public void GivenValidModuleAssingsToHitRecord()
        {
            moduleSample = 1;
            hitRecordSample.Module = moduleSample;
            Assert.AreEqual(moduleSample, hitRecordSample.Module);
        }

        [TestMethod]
        public void GivenValidIntersectionAssingsToTheHitRecord()
        {
            intersectionSample = new Vector3D(0, 0, 0);
            hitRecordSample.Intersection = intersectionSample;
            Assert.AreEqual(intersectionSample, hitRecordSample.Intersection);
        }

        [TestMethod]
        public void GivenAValidNormalItAssingsToTheHitRecord()
        {
            normalSample = new Vector3D(0, 0, 0);
            hitRecordSample.Normal = normalSample;
            Assert.AreEqual(normalSample, hitRecordSample.Normal);
        }
    }
}

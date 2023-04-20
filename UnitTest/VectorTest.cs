using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;

namespace Render3D.UnitTest
{
    
    [TestClass]
    public class VectorTest
    {
        private const float one = 1;
        private const float twoFiveFive = 255;
        private Vector3D allOnes;
        [TestInitialize]
        public void initialize()
        {
            allOnes = new Vector3D(1, 1, 1);
        }
       

        [TestMethod]
        public void givenAVectorItAssignsTheCoordinates()
        {
          Assert.AreEqual(allOnes.X, one);
          Assert.AreEqual(allOnes.Y, one);
          Assert.AreEqual(allOnes.Z, one);
        }
        [TestMethod]
        public void givenAVectorGetTheAssignColors()
        {
            Assert.AreEqual(allOnes.Red, twoFiveFive);
            Assert.AreEqual(allOnes.Green, twoFiveFive);
            Assert.AreEqual(allOnes.Blue, twoFiveFive);
        }
    }
}

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
        private const int one = 1;
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
    }
}

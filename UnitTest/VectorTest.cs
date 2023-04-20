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
        private const float two = 2;
        private Vector3D allOnes;
        private Vector3D allTwos = new Vector3D(2, 2, 2);
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
        [TestMethod]
        public void givenTwoVectorsReturnsTheSum()
        {
            Assert.AreEqual(allOnes.Add(allOnes).X, allTwos.X);
            Assert.AreEqual(allOnes.Add(allOnes).Y, allTwos.Y);
            Assert.AreEqual(allOnes.Add(allOnes).Z, allTwos.Z);
        }
        [TestMethod]
        public void givenTwoVectorsReturnsTheSubstraction()
        {
            Assert.AreEqual(allTwos.Substract(allOnes).X, allOnes.X);
            Assert.AreEqual(allTwos.Substract(allOnes).Y, allOnes.Y);
            Assert.AreEqual(allTwos.Substract(allOnes).Z, allOnes.Z);
        }
        [TestMethod]
        public void givenAVectorAndAFloatMultiplyForEachCoord()
        {
            Assert.AreEqual(allOnes.Multiply(two).X, allTwos.X);
            Assert.AreEqual(allOnes.Multiply(two).Y, allTwos.Y);
            Assert.AreEqual(allOnes.Multiply(two).Z, allTwos.Z);
        }

        [TestMethod]
        public void givenAVectorAndAFloatDivideForEachCoord()
        {
            Assert.AreEqual(allTwos.Divide(two).X, allOnes.X);
            Assert.AreEqual(allTwos.Divide(two).Y, allOnes.Y);
            Assert.AreEqual(allTwos.Divide(two).Z, allOnes.Z);
        }
        [TestMethod]
        public void givenTwoVectorsAddToTheFirstOne()
        {
            allOnes.AddTo(allOnes);
            Assert.AreEqual(allOnes.X,allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
    }
}

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;
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
        private Vector3D allTree = new Vector3D(3, 3, 3);
        private Vector3D squareRootIsInt = new Vector3D(1, 2, 2);

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
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }

        [TestMethod]
        public void givenTwoVectorsSubstractsToTheFirstOne()
        {
            allTwos.SubstractFrom(allOnes);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
        [TestMethod]
        public void givenAVectorAndANumberMultiplyEachCoord()
        {
            allOnes.ScaleUpBy(2);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
        [TestMethod]
        public void givenAVectorAndANumberDivideEachCoord()
        {
            allTwos.ScaleDownBy(2);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
        [TestMethod]
        public void givenAVectorReturnTheSquaredLength()
        {
            Assert.AreEqual(allOnes.SquaredLength(), 3);
        }
        [TestMethod]
        public void givenAVectorReturnTheLength()
        {
            Assert.AreEqual(squareRootIsInt.Length(), 3);
        }
        [TestMethod]
        public void givenAVectorGetUnit()
        {
            Assert.AreEqual(squareRootIsInt.GetUnit().X, squareRootIsInt.Divide(3).X);
            Assert.AreEqual(squareRootIsInt.GetUnit().Y, squareRootIsInt.Divide(3).Y);
            Assert.AreEqual(squareRootIsInt.GetUnit().Z, squareRootIsInt.Divide(3).Z);
        }
        [TestMethod]
        public void givenTwoVectorsReturnFloat()
        {
            Assert.AreEqual(allOnes.Dot(allOnes), 3);
        }

        [TestMethod]
        public void givenTwoVectorsReturnANewOneInThe()
        {
            Assert.AreEqual(allOnes.Cross(allOnes).X, 0);
            Assert.AreEqual(allOnes.Cross(allOnes).Y, 0);
            Assert.AreEqual(allOnes.Cross(allOnes).Y, 0);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;


namespace Render3D.UnitTest
{

    [TestClass]
    public class VectorTest
    {
        private const double one = 1;
        private const double two = 2;
        private Vector3D allOnes;
        private readonly Vector3D allTwos = new Vector3D(2, 2, 2);
        private readonly Vector3D squareRootIsInt = new Vector3D(1, 2, 2);

        [TestInitialize]
        public void Initialize()
        {
            allOnes = new Vector3D(1, 1, 1);
        }


        [TestMethod]
        public void GivenVectorReturnsItsCoordinates()
        {
            Assert.AreEqual(allOnes.X, one);
            Assert.AreEqual(allOnes.Y, one);
            Assert.AreEqual(allOnes.Z, one);
        }


        [TestMethod]
        public void GivenVectorAssignsCoordinates()
        {
            Vector3D all2 = new Vector3D(1, 1, 1);
            all2.X = 2;
            all2.Y = 2;
            all2.Z = 2;
            Assert.IsTrue(all2.X == 2);
            Assert.IsTrue(all2.Y == 2);
            Assert.IsTrue(all2.Z == 2);
        }

        [TestMethod]
        public void GivenTwoVectorsReturnsSum()
        {
            Assert.AreEqual(allOnes.Add(allOnes).X, allTwos.X);
            Assert.AreEqual(allOnes.Add(allOnes).Y, allTwos.Y);
            Assert.AreEqual(allOnes.Add(allOnes).Z, allTwos.Z);
        }
        [TestMethod]
        public void GivenTwoVectorsReturnsDifference()
        {
            Assert.AreEqual(allTwos.Substract(allOnes).X, allOnes.X);
            Assert.AreEqual(allTwos.Substract(allOnes).Y, allOnes.Y);
            Assert.AreEqual(allTwos.Substract(allOnes).Z, allOnes.Z);
        }
        [TestMethod]
        public void GivenVectorAndDoubleMultiplyEachCoordenateByNumber()
        {
            Assert.AreEqual(allOnes.Multiply(two).X, allTwos.X);
            Assert.AreEqual(allOnes.Multiply(two).Y, allTwos.Y);
            Assert.AreEqual(allOnes.Multiply(two).Z, allTwos.Z);
        }

        [TestMethod]
        public void GivenVectorAndAdoubleDivideEachCoordenateByNumber()
        {
            Assert.AreEqual(allTwos.Divide(two).X, allOnes.X);
            Assert.AreEqual(allTwos.Divide(two).Y, allOnes.Y);
            Assert.AreEqual(allTwos.Divide(two).Z, allOnes.Z);
        }

        [TestMethod]
        public void GivenTwoVectorsAddsTheSecondToFirstOne()
        {
            allOnes.AddTo(allOnes);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }

        [TestMethod]
        public void GivenTwoVectorsSubstractsTheSecondToFirstOne()
        {
            allTwos.SubstractFrom(allOnes);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
        [TestMethod]
        public void GivenVectorAndNumberMultiplyEachCoordenateByNumber()
        {
            allOnes.ScaleUpBy(2);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
        [TestMethod]
        public void GivenVectorAndANumberDivideEachCoordenateByNumber()
        {
            allTwos.ScaleDownBy(2);
            Assert.AreEqual(allOnes.X, allTwos.X);
            Assert.AreEqual(allOnes.Y, allTwos.Y);
            Assert.AreEqual(allOnes.Z, allTwos.Z);
        }
        [TestMethod]
        public void GivenVectorReturnsSquaredLength()
        {
            Assert.AreEqual(allOnes.SquaredLength(), 3);
        }
        [TestMethod]
        public void GivenVectorReturnsLength()
        {
            Assert.AreEqual(squareRootIsInt.Length(), 3);
        }
        [TestMethod]
        public void GivenVectorReturnsUnitVector()
        {
            Assert.AreEqual(squareRootIsInt.GetUnit().X, squareRootIsInt.Divide(3).X);
            Assert.AreEqual(squareRootIsInt.GetUnit().Y, squareRootIsInt.Divide(3).Y);
            Assert.AreEqual(squareRootIsInt.GetUnit().Z, squareRootIsInt.Divide(3).Z);
        }
        [TestMethod]
        public void GivenTwoVectorsReturnsDotProduct()
        {
            Assert.AreEqual(allOnes.DotProduct(allOnes), 3);
        }

        [TestMethod]
        public void GivenTwoVectorsReturnsCrossProduct()
        {
            Assert.AreEqual(allOnes.CrossProduct(allOnes).X, 0);
            Assert.AreEqual(allOnes.CrossProduct(allOnes).Y, 0);
            Assert.AreEqual(allOnes.CrossProduct(allOnes).Y, 0);
        }

        [TestMethod]
        public void GivenTwoVectorsWithSameComponentsReturnsAreEqual()
        {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(1, 2, 3);
            Assert.IsTrue(vector1.Equals(vector2));
        }

        [TestMethod]
        public void GivenTwoVectorsWithTwoComponentsInCommonReturnsAreNotEqual()
        {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(1, 2, 1);
            Assert.IsFalse(vector1.Equals(vector2));
        }
        [TestMethod]
        public void GivenTwoVectorsWithOneComponentInCommonReturnsFalse()
        {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(1, 1, 1);
            Assert.IsFalse(vector1.Equals(vector2));
        }

        [TestMethod]
        public void GivenTwoVectorsWithNoComponentsInCommonReturnsAreNotEqual()
        {
            Vector3D vector1 = new Vector3D(0, 0, 0);
            Vector3D vector2 = new Vector3D(1, 1, 1);
            Assert.IsFalse(vector1.Equals(vector2));
        }
    }
}

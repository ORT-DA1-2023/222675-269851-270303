using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.GraphicMotorUtility;


namespace Render3D.UnitTest
{

    [TestClass]
    public class VectorTest
    {
        private const double _one = 1;
        private const double _two = 2;
        private const double _three = 3;
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
            Assert.AreEqual(allOnes.X, _one);
            Assert.AreEqual(allOnes.Y, _one);
            Assert.AreEqual(allOnes.Z, _one);
        }


        [TestMethod]
        public void GivenVectorAssignsCoordinates()
        {
            Vector3D all2 = new Vector3D(1, 1, 1);
            all2.X = _two;
            all2.Y = _two;
            all2.Z = _two;
            Assert.IsTrue(all2.X == _two);
            Assert.IsTrue(all2.Y == _two);
            Assert.IsTrue(all2.Z == _two);
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
            Assert.AreEqual(allOnes.Multiply(_two).X, allTwos.X);
            Assert.AreEqual(allOnes.Multiply(_two).Y, allTwos.Y);
            Assert.AreEqual(allOnes.Multiply(_two).Z, allTwos.Z);
        }

        [TestMethod]
        public void GivenVectorAndAdoubleDivideEachCoordenateByNumber()
        {
            Assert.AreEqual(allTwos.Divide(_two).X, allOnes.X);
            Assert.AreEqual(allTwos.Divide(_two).Y, allOnes.Y);
            Assert.AreEqual(allTwos.Divide(_two).Z, allOnes.Z);
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
            Assert.AreEqual(allOnes.SquaredLength(), _three);
        }
        [TestMethod]
        public void GivenVectorReturnsLength()
        {
            Assert.AreEqual(squareRootIsInt.Length(), _three);
        }
        [TestMethod]
        public void GivenVectorReturnsUnitVector()
        {
            Assert.AreEqual(squareRootIsInt.GetUnit().X, squareRootIsInt.Divide(_three).X);
            Assert.AreEqual(squareRootIsInt.GetUnit().Y, squareRootIsInt.Divide(_three).Y);
            Assert.AreEqual(squareRootIsInt.GetUnit().Z, squareRootIsInt.Divide(_three).Z);
        }
        [TestMethod]
        public void GivenTwoVectorsReturnsDotProduct()
        {
            Assert.AreEqual(allOnes.DotProduct(allOnes), _three);
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

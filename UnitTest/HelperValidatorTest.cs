using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;

namespace Render3D.UnitTest
{
    [TestClass]
    public class HelperValidatorTest
    {

        private const int minLength = 3;
        private const int maxLength = 10;
        private const string twoCharName = "Ab";
        private const string tenCharName = "Abcdefghij";
        private const string elevenCharName = "Abcdefghijk";
        private const string nonAlphanumericalName = "_*";
        private readonly int minNumber = 1;
        private readonly int maxNumber = 10;
        private readonly double minDouble = 1;
        private readonly double maxDouble = 10;

        [TestMethod]
        public void givenANameShorterThanTheMinimumItReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(twoCharName, minLength, maxLength);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void givenANameLargerThanTheMinimumItReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(elevenCharName, minLength, maxLength);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void givenAValidNameItReturnsTrue()
        {
            bool result = HelperValidator.IsLengthBetween(tenCharName, minLength, maxLength);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void givenANameStartingWithSpacesReturnTrue()
        {
            bool result = HelperValidator.IsTrimmable(" " + tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void givenANameEndingWithSpacesReturnTrue()
        {
            bool result = HelperValidator.IsTrimmable(tenCharName + " ");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void givenANameWithoutSpacesReturnFalse()
        {
            bool result = HelperValidator.IsTrimmable(tenCharName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void givenANonAlphanumericalNameItReturnsFalse()
        {
            bool result = HelperValidator.IsAlphanumerical(nonAlphanumericalName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void givenAnAlphanumericalNameItReturnsTrue()
        {
            bool result = HelperValidator.IsAlphanumerical(tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void givenANameWithoutANumberItReturnsFalse()
        {
            bool result = HelperValidator.ContainsANumber("noNumber");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void givenANameWithANumberItReturnsTrue()
        {
            bool result = HelperValidator.ContainsANumber("1Number");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void givenANameWithoutCapitalsItReturnsFalse()
        {
            bool result = HelperValidator.ContainsACapital("nocapitals");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void givenANameWitCapitalsItReturnsTrue()
        {
            bool result = HelperValidator.ContainsACapital("containsCapitals");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void givenAnEmptyStringItReturnsTrue()
        {
            bool result = HelperValidator.IsAnEmptyString("");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void givenANonEmptyStringItReturnsFalse()
        {
            bool result = HelperValidator.IsAnEmptyString(tenCharName);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void givenAnIntInTheRangeItReturnsTrue()
        {
            int num = 5;
            Assert.IsTrue(HelperValidator.IsANumberInRange(num, minNumber, maxNumber));
        }

        [TestMethod]
        public void givenAnIntEqualToTheMinimumItReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(minNumber, minNumber, maxNumber));
        }
        [TestMethod]
        public void givenAnIntEqualToTheMaximumItReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(maxNumber, minNumber, maxNumber));
        }
        [TestMethod]
        public void givenAnIntLargestThanTheMaximumItReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(maxNumber+1, minNumber, maxNumber));
        }
        [TestMethod]
        public void givenAnIntSmallestThanTheMinimumItReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(minNumber-1, minNumber, maxNumber));
        }

        [TestMethod]
        public void givenADoubleInTheRangeItReturnsTrue()
        {
            double num = 5;
            Assert.IsTrue(HelperValidator.IsANumberInRange(num, minDouble, maxDouble));
        }

        [TestMethod]
        public void givenADoubleEqualToTheMinimumItReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(minDouble, minDouble, maxDouble));
        }
        [TestMethod]
        public void givenADoubleEqualToTheMaximumItReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(maxDouble, minDouble, maxDouble));
        }
        [TestMethod]
        public void givenADoubleLargestThanTheMaximumItReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(maxDouble+1, minDouble, maxDouble));
        }
        [TestMethod]
        public void givenADoubleSmallestThanTheMinimumItReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(minDouble-1, minDouble, maxDouble));
        }

    }
}

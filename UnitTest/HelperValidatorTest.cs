using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Utilities;


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
        public void GivenNameShorterThanMinimumReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(twoCharName, minLength, maxLength);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNameLargerThanTheMaximumReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(elevenCharName, minLength, maxLength);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenValidNameReturnsTrue()
        {
            bool result = HelperValidator.IsLengthBetween(tenCharName, minLength, maxLength);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameStartingWithSpacesReturnsTrue()
        {
            bool result = HelperValidator.IsTrimmable(" " + tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameEndingWithSpacesReturnsTrue()
        {
            bool result = HelperValidator.IsTrimmable(tenCharName + " ");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenNameWithoutSpacesReturnsFalse()
        {
            bool result = HelperValidator.IsTrimmable(tenCharName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNonAlphanumericalNameReturnsFalse()
        {
            bool result = HelperValidator.IsAlphanumerical(nonAlphanumericalName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAlphanumericalNameReturnsTrue()
        {
            bool result = HelperValidator.IsAlphanumerical(tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameWithoutNumberReturnsFalse()
        {
            bool result = HelperValidator.ContainsANumber("noNumber");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNameWithNumberReturnsTrue()
        {
            bool result = HelperValidator.ContainsANumber("1Number");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameWithoutCapitalsReturnsFalse()
        {
            bool result = HelperValidator.ContainsACapital("nocapitals");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenANameWithCapitalsReturnsTrue()
        {
            bool result = HelperValidator.ContainsACapital("containsCapitals");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenEmptyStringReturnsTrue()
        {
            bool result = HelperValidator.IsAnEmptyString("");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenNonEmptyStringReturnsFalse()
        {
            bool result = HelperValidator.IsAnEmptyString(tenCharName);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenIntInRangeReturnsTrue()
        {
            int num = 5;
            Assert.IsTrue(HelperValidator.IsANumberInRange(num, minNumber, maxNumber));
        }

        [TestMethod]
        public void GivenIntEqualToMinimumReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(minNumber, minNumber, maxNumber));
        }
        [TestMethod]
        public void GivenIntEqualToMaximumItReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(maxNumber, minNumber, maxNumber));
        }
        [TestMethod]
        public void GivenIntLargestThanMaximumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(maxNumber+1, minNumber, maxNumber));
        }
        [TestMethod]
        public void GivenIntSmallestThanMinimumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(minNumber-1, minNumber, maxNumber));
        }

        [TestMethod]
        public void GivenDoubleInRangeReturnsTrue()
        {
            double num = 5;
            Assert.IsTrue(HelperValidator.IsANumberInRange(num, minDouble, maxDouble));
        }

        [TestMethod]
        public void GivenDoubleEqualToMinimumReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(minDouble, minDouble, maxDouble));
        }
        [TestMethod]
        public void GivenDoubleEqualToMaximumReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(maxDouble, minDouble, maxDouble));
        }
        [TestMethod]
        public void GivenDoubleLargestThanMaximumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(maxDouble+1, minDouble, maxDouble));
        }
        [TestMethod]
        public void GivenDoubleSmallestThanMinimumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(minDouble-1, minDouble, maxDouble));
        }

    }
}

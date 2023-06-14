using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Utilities;


namespace Render3D.UnitTest
{
    [TestClass]
    public class HelperValidatorTest
    {

        private const int _minLength = 3;
        private const int _maxLength = 10;
        private const string _twoCharName = "Ab";
        private const string _tenCharName = "Abcdefghij";
        private const string _elevenCharName = "Abcdefghijk";
        private const string _nonAlphanumericalName = "_*";
        private readonly int _minNumber = 1;
        private readonly int _maxNumber = 10;
        private readonly double _minDouble = 1;
        private readonly double _maxDouble = 10;
        private readonly string _notANumber = "noNumber";
        private readonly string _aNumber = "1Number";
        private readonly string _noCapitals = "nocapitals";
        private readonly string _containsCapitals = "containsCapitals";
        private readonly string _emptyString = "";

        [TestMethod]
        public void GivenNameShorterThanMinimumReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(_twoCharName, _minLength, _maxLength);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNameLargerThanMaximumReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(_elevenCharName, _minLength, _maxLength);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenValidNameReturnsTrue()
        {
            bool result = HelperValidator.IsLengthBetween(_tenCharName, _minLength, _maxLength);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameStartingWithSpacesReturnsTrue()
        {
            bool result = HelperValidator.IsTrimmable(" " + _tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameEndingWithSpacesReturnsTrue()
        {
            bool result = HelperValidator.IsTrimmable(_tenCharName + " ");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenNameWithoutSpacesReturnsFalse()
        {
            bool result = HelperValidator.IsTrimmable(_tenCharName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNonAlphanumericalNameReturnsFalse()
        {
            bool result = HelperValidator.IsAlphanumerical(_nonAlphanumericalName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAlphanumericalNameReturnsTrue()
        {
            bool result = HelperValidator.IsAlphanumerical(_tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameWithoutNumberReturnsFalse()
        {
            bool result = HelperValidator.ContainsANumber(_notANumber);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenNameWithNumberReturnsTrue()
        {
            bool result = HelperValidator.ContainsANumber(_aNumber);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNameWithoutCapitalsReturnsFalse()
        {
            bool result = HelperValidator.ContainsACapital(_noCapitals);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenANameWithCapitalsReturnsTrue()
        {
            bool result = HelperValidator.ContainsACapital(_containsCapitals);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenEmptyStringReturnsTrue()
        {
            bool result = HelperValidator.IsAnEmptyString(_emptyString);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenNonEmptyStringReturnsFalse()
        {
            bool result = HelperValidator.IsAnEmptyString(_tenCharName);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenIntInRangeReturnsTrue()
        {
            int num = 5;
            Assert.IsTrue(HelperValidator.IsANumberInRange(num, _minNumber, _maxNumber));
        }

        [TestMethod]
        public void GivenIntEqualToMinimumReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(_minNumber, _minNumber, _maxNumber));
        }
        [TestMethod]
        public void GivenIntEqualToMaximumItReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(_maxNumber, _minNumber, _maxNumber));
        }
        [TestMethod]
        public void GivenIntLargestThanMaximumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(_maxNumber + 1, _minNumber, _maxNumber));
        }
        [TestMethod]
        public void GivenIntSmallestThanMinimumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(_minNumber - 1, _minNumber, _maxNumber));
        }

        [TestMethod]
        public void GivenDoubleInRangeReturnsTrue()
        {
            double num = 5;
            Assert.IsTrue(HelperValidator.IsANumberInRange(num, _minDouble, _maxDouble));
        }

        [TestMethod]
        public void GivenDoubleEqualToMinimumReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(_minDouble, _minDouble, _maxDouble));
        }
        [TestMethod]
        public void GivenDoubleEqualToMaximumReturnsTrue()
        {
            Assert.IsTrue(HelperValidator.IsANumberInRange(_maxDouble, _minDouble, _maxDouble));
        }
        [TestMethod]
        public void GivenDoubleLargestThanMaximumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(_maxDouble + 1, _minDouble, _maxDouble));
        }
        [TestMethod]
        public void GivenDoubleSmallestThanMinimumReturnsFalse()
        {
            Assert.IsFalse(HelperValidator.IsANumberInRange(_minDouble - 1, _minDouble, _maxDouble));
        }

    }
}

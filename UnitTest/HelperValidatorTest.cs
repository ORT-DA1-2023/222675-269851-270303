using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;

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



        [TestMethod]
        public void givenANameShorterThanTheMinimumItReturnsFalse()
        {
            bool result = HelperValidator.IsLengthBetween(twoCharName,minLength,maxLength);
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
            bool result= HelperValidator.IsTrimmable(" "+tenCharName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void givenANameEndingWithSpacesReturnTrue()
        {
            bool result = HelperValidator.IsTrimmable(tenCharName+" ");
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
            bool result = HelperValidator.IsEmpty("");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void givenANonEmptyStringItReturnsFalse()
        {
            bool result = HelperValidator.IsEmpty(tenCharName);
            Assert.IsFalse(result);
        }
    }
}

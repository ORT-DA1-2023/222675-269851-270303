using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ColourTest
    {
 
        [TestMethod]
        public void givenAColourItSetsCorrectlyTheRedPercentage()
        {
            double percentageRed = 0.5;
            double percentageGreen = 0.2;
            double percentageBlue = 0.1;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            int redValue = colour.Red();

            int expectedRedValue = (int)(percentageRed * 255);
            Assert.AreEqual(expectedRedValue, redValue);
        }

        [TestMethod]
        public void givenAColourItSetsCorrectlyTheGreenPercentage()
        {
            double percentageRed = 0.5;
            double percentageGreen = 0.2;
            double percentageBlue = 0.1;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            int greenValue = colour.Green();


            int expectedGreenValue = (int)(percentageGreen * 255);
            Assert.AreEqual(expectedGreenValue, greenValue);
        }

        [TestMethod]
        public void givenAColourItSetsCorrectlyTheBluePercentage()
        {

            double percentageRed = 0.5;
            double percentageGreen = 0.2;
            double percentageBlue = 0.1;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            int blueValue = colour.Blue();

            int expectedBlueValue = (int)(percentageBlue * 255);
            Assert.AreEqual(expectedBlueValue, blueValue);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Colour percentage must be between 0 and 1")]
        public void givenAColourWithANegativeRedPercentageItThrowsABackEndException()
        {
            double percentageRed = -0.2;
            double percentageGreen = 0.5;
            double percentageBlue = 0.8;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            _ = colour.Red();
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Colour percentage must be between 0 and 1")]
        public void givenAColourWithRedPercentageHigherThanOneItThrowsABackEndException()
        {
            double percentageRed = 1.3;
            double percentageGreen = 0.5;
            double percentageBlue = 0.7;

            _ = new Colour(percentageRed, percentageGreen, percentageBlue);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Colour percentage must be between 0 and 1")]
        public void givenAColourWithANegativeGreenPercentageItThrowsABackEndException()
        {
            double percentageRed = 0.2;
            double percentageGreen = -0.5;
            double percentageBlue = 0.8;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            _ = colour.Red();
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Colour percentage must be between 0 and 1")]
        public void givenAColourWithGreenPercentageHigherThanOneItThrowsABackEndException()
        {
            double percentageRed = 0.3;
            double percentageGreen = 1.5;
            double percentageBlue = 0.7;

            _ = new Colour(percentageRed, percentageGreen, percentageBlue);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Colour percentage must be between 0 and 1")]
        public void givenAColourWithANegativeBluePercentageItThrowsABackEndException()
        {
            double percentageRed = 0.2;
            double percentageGreen = 0.5;
            double percentageBlue = -0.8;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            _ = colour.Red();
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Colour percentage must be between 0 and 1")]
        public void givenAColourWithBluePercentageHigherThanOneItThrowsABackEndException()
        {
            double percentageRed = 0.3;
            double percentageGreen = 0.5;
            double percentageBlue = 2.7;

            _ = new Colour(percentageRed, percentageGreen, percentageBlue);
        }

        [TestMethod]
        public void givenTwoDifferentColoursItReturnsFalse() {
            Colour red = new Colour(1, 0, 0);
            Colour white = new Colour(1, 1, 1);
            Assert.IsFalse(red.Equals(white));
        }

        [TestMethod]
        public void givenTheSameColoursItReturnsTrue()
        {
            Colour red1 = new Colour(1, 0, 0);
            Colour red2 = new Colour(1, 0, 0);
            Assert.IsTrue(red1.Equals(red2));
        }
    }


}


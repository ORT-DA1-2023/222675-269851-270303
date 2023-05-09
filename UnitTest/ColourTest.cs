using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd.Materials;

namespace Render3D.UnitTest
{
    [TestClass]
    public class ColourTest
    {
        [TestMethod]
        public void GivenColourSetsRedPercentage()
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
        public void GivenColourSetsGreenPercentage()
        {
            double percentageRed = 0.5;
            double percentageGreen = 0.2;
            double percentageBlue = 0.1;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            int greenValue = colourSample.Green();

            int expectedGreenValue = (int)(percentageGreen * 255);
            Assert.AreEqual(expectedGreenValue, greenValue);
        }

        [TestMethod]
        public void GivenColourSetsBluePercentage()
        {
            double percentageRed = 0.5;
            double percentageGreen = 0.2;
            double percentageBlue = 0.1;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            int blueValue = colourSample.Blue();

            int expectedBlueValue = (int)(percentageBlue * 255);
            Assert.AreEqual(expectedBlueValue, blueValue);
        }

        [TestMethod]
        public void GivenColourWithNegativeRedPercentageAssignsZero()
        {
            double percentageRed = -0.2;
            double percentageGreen = 0.5;
            double percentageBlue = 0.8;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(0, colourSample.Red());
        }

        [TestMethod]
        public void GivenColourWithRedPercentageHigherThanOneAssigns255()
        {
            double percentageRed = 1.3;
            double percentageGreen = 0.5;
            double percentageBlue = 0.7;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(255, colourSample.Red());
        }

        [TestMethod]
        public void GivenColourWithNegativeGreenPercentageAssignsZero()
        {
            double percentageRed = 0.2;
            double percentageGreen = -0.5;
            double percentageBlue = 0.8;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(0, colourSample.Green());
        }

        [TestMethod]
        public void GivenColourWithGreenPercentageHigherThanOneAssigns255()
        {
            double percentageRed = 0.3;
            double percentageGreen = 1.5;
            double percentageBlue = 0.7;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(255, colourSample.Green());
        }

        [TestMethod]
        public void GivenColourWithNegativeBluePercentageAssignsZero()
        {
            double percentageRed = 0.2;
            double percentageGreen = 0.5;
            double percentageBlue = -0.8;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(0, colourSample.Blue());
        }

        [TestMethod]
        public void GivenColourWithBluePercentageHigherThanOneAssigns255()
        {
            double percentageRed = 0.3;
            double percentageGreen = 0.5;
            double percentageBlue = 2.7;

            Colour colourSample = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(255, colourSample.Blue());
        }

        [TestMethod]
        public void GivenTwoDifferentColoursReturnsTheyAreNotEqual()
        {
            Colour red = new Colour(1, 0, 0);
            Colour white = new Colour(1, 1, 1);
            Assert.IsFalse(red.Equals(white));
        }

        [TestMethod]
        public void GivenTheSameColoursReturnsTheyAreEqual()
        {
            Colour red1 = new Colour(1, 0, 0);
            Colour red2 = new Colour(1, 0, 0);
            Assert.IsTrue(red1.Equals(red2));
        }

        [TestMethod]
        public void GivenTwoColoursSubstractRGBPercentages()
        {
            Colour colourSample1 = new Colour(1, 0, 0);
            Colour colourSample2 = new Colour(0, 1, 0);

            Colour diff = colourSample1.Substract(colourSample2);
            Colour expected = new Colour(1, 0, 0);
            Assert.IsTrue(expected.Equals(diff));
        }

        [TestMethod]
        public void GivenTwoColorsMultipliesRGBPercentages()
        {
            Colour colourSample1 = new Colour(1, 0, 0);
            Colour colourSample2 = new Colour(1, 1, 0);

            Colour product = colourSample1.Multiply(colourSample2);
            Colour expected = new Colour(1, 0, 0);
            Assert.IsTrue(expected.Equals(product));
        }

        [TestMethod]
        public void GivenTwoColorsDividesRGBPercentages()
        {
            Colour colour1Sample = new Colour(0.5, 0.25, 1);
            Colour colour2Sample = new Colour(1, 1, 1);

            Colour quotient = colour1Sample.Divide(colour2Sample);
            Colour expected = new Colour(0.5, 0.25, 1);
            Assert.IsTrue(expected.Equals(quotient));
        }

        [TestMethod]
        public void GivenColorAndNumberDividesRGBPercentagesByNumber()
        {
            Colour colour1Sample = new Colour(1, 0.5, 0.25);
            int ratio = 2;
            Colour quotient = colour1Sample.Divide(ratio);
            Colour expected = new Colour(0.5, 0.25, 0.125);
            Assert.IsTrue(expected.Equals(quotient));
        }
    }
}
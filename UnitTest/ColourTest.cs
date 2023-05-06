using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;

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
        public void givenAColourWithANegativeRedPercentageItAssignsZero()
        {
            double percentageRed = -0.2;
            double percentageGreen = 0.5;
            double percentageBlue = 0.8;
            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);

            Assert.AreEqual(0, colour.Red());
        }

        [TestMethod]
        public void givenAColourWithRedPercentageHigherThanOneItAssigns255()
        {
            double percentageRed = 1.3;
            double percentageGreen = 0.5;
            double percentageBlue = 0.7;

            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(255, colour.Red());
        }

        [TestMethod]
        public void givenAColourWithANegativeGreenPercentageItAssigns0()
        {
            double percentageRed = 0.2;
            double percentageGreen = -0.5;
            double percentageBlue = 0.8;

            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(0, colour.Green());
        }

        [TestMethod]
        public void givenAColourWithGreenPercentageHigherThanOneItAssigns255()
        {
            double percentageRed = 0.3;
            double percentageGreen = 1.5;
            double percentageBlue = 0.7;

            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(255, colour.Green());
        }

        [TestMethod]
        public void givenAColourWithANegativeBluePercentageItAssigns0()
        {
            double percentageRed = 0.2;
            double percentageGreen = 0.5;
            double percentageBlue = -0.8;

            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(0, colour.Blue());
        }

        [TestMethod]
        public void givenAColourWithBluePercentageHigherThanOneItAssigns255()
        {
            double percentageRed = 0.3;
            double percentageGreen = 0.5;
            double percentageBlue = 2.7;

            Colour colour = new Colour(percentageRed, percentageGreen, percentageBlue);
            Assert.AreEqual(255, colour.Blue());
        }

        [TestMethod]
        public void givenTwoDifferentColoursItReturnsTheyAreNotEqual()
        {
            Colour red = new Colour(1, 0, 0);
            Colour white = new Colour(1, 1, 1);
            Assert.IsFalse(red.Equals(white));
        }

        [TestMethod]
        public void givenTheSameColoursItReturnsTheyAreEqual()
        {
            Colour red1 = new Colour(1, 0, 0);
            Colour red2 = new Colour(1, 0, 0);
            Assert.IsTrue(red1.Equals(red2));
        }
    }


}


using BackEnd;
using Figure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace FigureTest
{
    [TestClass]
    public class FigureTest
    {

        private const String Joe = "Joe";
        private const String correctPasword = "thisIs4Saf3Passw0rd";
        private Client clientJoe;
        private Figure newFigure;
        private String figureName = "FigureName";


        [TestInitialize]
        public void initialize()
        {
            clientJoe = new Client()
            {
                Name = Joe,
                Password = correctPasword,
            };

            newFigure = new Figure()
            {
                Name = figureName;
            ClientRegistraction = clientJoe;
            }



        }

        [TestMethod]
        public void CreateFigureSuccessTest()
        {

        }
    }
}

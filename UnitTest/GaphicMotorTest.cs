using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.UnitTest
{
    [TestClass]
    public class GraphicMotorTest
    {
        private GraphicMotor graphicMotorSample;
        private int resolutionSample = 300;
        private int NegativeResolutionSample = -1;
        private int ZeroResolutionSample = 0;

        [TestInitialize]
        public void initialize()
        {
            graphicMotorSample = new GraphicMotor() { Resolution = resolutionSample};
        }

        [TestMethod]
        public void givenAValidResolutionItAssignsItToTheGraphicMotor()
        {
            graphicMotorSample.Resolution = resolutionSample;
            Assert.AreEqual(resolutionSample, graphicMotorSample.Resolution);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void givenANegativeResolutionItThrowsABackEndException()
        {
            graphicMotorSample.Resolution = NegativeResolutionSample;
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "The resolution must be greater than 0.")]
        public void givenAZeroResolutionItThrowsABackEndException()
        {
            graphicMotorSample.Resolution = ZeroResolutionSample;
        }

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }
    }
}

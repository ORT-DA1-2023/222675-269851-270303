using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Runtime.Remoting.Channels;

namespace SceneTest
{
    [TestClass]
    public class SceneTest
    {
        private Scene sc;
        private Client cl = new Client() { Name = "Joe", Password = "S4fePassword" };
        private String name = "SceneTest";
        private ArrayList positionedModels = new ArrayList();
        private decimal[] randomCameraPosition = new decimal[3] { 1, 1, 0 };
        private decimal[] randomObjectPosition = new decimal[3] { 1, 1, 0 };
        private int randomFoV = 30;
        private Scene defaultScene = new Scene();
        private decimal[] defaultPosition = new decimal[3] { 0, 2, 0 };
        private decimal[] defaultObjPosition = new decimal[3] { 0, 2, 5 };


        [TestInitialize]

        public void initialize()
        {
            sc = new Scene()
            {
                Client = cl,
                Name = name,
                PositionedModels = positionedModels,
                CameraPosition = randomCameraPosition,
                ObjectPosition = randomObjectPosition,
                FieldOfView = randomFoV,
            };
        }

        [TestMethod]
        public void isNotNull()
        {
            Assert.IsNotNull(sc);
            Assert.IsTrue(sc.Client.Equals(cl));
            Assert.AreEqual(sc.Name, name);
            Assert.AreEqual(sc.PositionedModels, positionedModels);
            Assert.AreEqual(sc.CameraPosition, randomCameraPosition);
            Assert.AreEqual(sc.ObjectPosition, randomObjectPosition);
            Assert.AreEqual(sc.FieldOfView, randomFoV);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void throwNameIsNullException()
        {
            sc.Name = "";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void throwNameStartsWithBlankException()
        {
            sc.Name = " " + name;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void throwNameEndsWithBlankException()
        {
            sc.Name = name + " ";
        }

        [TestMethod]
        public void defaultFoV()
        {
            Assert.AreEqual(defaultScene.FieldOfView, 30);
        }

        [TestMethod]
        public void defaultCameraPosition()
        {
            Assert.IsTrue(defaultScene.equalsCameraPosition(defaultPosition));
        }

        [TestMethod]
        
        public void defaultObjectPosition()
        {
            Assert.IsTrue(defaultScene.equalsObjectPosition(defaultObjPosition));
        }




    }
}

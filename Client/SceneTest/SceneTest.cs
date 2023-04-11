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
        private decimal[] defaultCameraPosition = new decimal[3] { 0, 2, 0 };
        private int defaultFoV = 30;

        [TestInitialize]

        public void initialize()
        {
            sc = new Scene()
            {
                Client = cl,
                Name = name,
                PositionedModels = positionedModels,
                CameraPosition = defaultCameraPosition,
                FieldOfView = defaultFoV,
            };
        }

        [TestMethod]
        public void isNotNull()
        {
            Assert.IsNotNull(sc);
            Assert.IsTrue(sc.Client.Equals(cl));
            Assert.AreEqual(sc.Name,name);
            Assert.AreEqual(sc.PositionedModels, positionedModels);
            Assert.AreEqual(sc.CameraPosition, defaultCameraPosition);
            Assert.AreEqual(sc.FieldOfView, defaultFoV);
        }

        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant be empty")]
        public void throwNameIsNullException()
        {
            sc.Name = "";
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException),"Name cant start or end with blank")]
        public void throwNameStartsWithBlankException()
        {
            sc.Name = " " + name;
        }
        [TestMethod]
        [ExpectedException(typeof(BackEndException), "Name cant start or end with blank")]
        public void throwNameEndsWithBlankException()
        {
            sc.Name =name + " ";
        }






    }
}

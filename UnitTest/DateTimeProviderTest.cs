using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class DateTimeProviderTest
    {
        DateTime januaryFirst2020;

        [TestInitialize]
        public void Initialize()
        {
            januaryFirst2020 = new DateTime(2020, 1, 1);
        }

        [TestMethod]
        public void givenADateTimeItReturnsTrueIfTheDateTimeIsFixed()
        {
            DateTimeProvider.Now = DateTime.Now;
            Client client1 = new Client();
            Assert.AreEqual(DateTimeProvider.Now, client1.RegisterDate);
        }
        [TestMethod]
        public void givenAFixedDateItUpdatesToTheCurrentDate()
        {

            DateTimeProvider.Now = januaryFirst2020;
            Assert.AreEqual(januaryFirst2020, DateTimeProvider.Now);
            DateTimeProvider.Reset();
            Assert.AreNotEqual(januaryFirst2020, DateTimeProvider.Now);

        }
    }
}

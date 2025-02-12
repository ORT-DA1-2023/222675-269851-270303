﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Render3D.BackEnd;
using Render3D.BackEnd.Utilities;
using System;

namespace Render3D.UnitTest
{
    [TestClass]
    public class DateTimeProviderTest
    {
        private DateTime januaryFirst2020;

        [TestInitialize]
        public void Initialize()
        {
            januaryFirst2020 = new DateTime(2020, 1, 1);
        }

        [TestMethod]
        public void GivenDateTimeReturnsTrueIfDateTimeIsFixed()
        {
            DateTimeProvider.Now = DateTime.Now;
            Client client1 = new Client();
            Assert.AreEqual(DateTimeProvider.Now, client1.RegisterDate);
        }

        [TestMethod]
        public void GivenFixedDateUpdatesItToCurrentDate()
        {
            DateTimeProvider.Now = januaryFirst2020;
            Assert.AreEqual(januaryFirst2020, DateTimeProvider.Now);
            DateTimeProvider.Reset();
            Assert.AreNotEqual(januaryFirst2020, DateTimeProvider.Now);
        }
    }
}

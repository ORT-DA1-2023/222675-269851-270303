using BackEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace ClientTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void successfulClientSignUp()
        {
            var cl = new Client()
            {
                name = "Joe",
                password="1234",
            }; 
            Assert.IsNotNull(cl);
        Assert.AreEqual(cl.name,"Joe");
        Assert.AreEqual(cl.password, "1234");
        }
    }
}

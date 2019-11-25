using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("true", Environment.GetEnvironmentVariable("TestMethod1"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("true", Environment.GetEnvironmentVariable("TestMethod2"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("true", Environment.GetEnvironmentVariable("TestMethod3"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("true", Environment.GetEnvironmentVariable("TestMethod4"));
        }

        [TestMethod]
        [Ignore]
        public void TestMethod5()
        {

        }
    }
}

using System;
using dotnet_example.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnet_example.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SimpleHub.ListDocuments();
        }
    }
}

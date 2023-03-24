using HW14_FooBar;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Net.WebSockets;

namespace FooBarTests
{
    [TestClass]
    public class FooBarTests
    {
        [TestMethod]
        [DataRow(0, "")]
        [DataRow(1, "foobar")]
        [DataRow(3, "foobarfoobarfoobar")]
        public void RunTest(int n, string expRes)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            FooBar.Run(n);
            Thread.Sleep(100);
            var res = stringWriter.ToString().Trim();

            Assert.AreEqual(expRes, res);
        }
    }
}
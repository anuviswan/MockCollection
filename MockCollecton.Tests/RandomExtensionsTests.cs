using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockCollection.Tests
{
    [TestClass()]
    public class RandomExtensionsTests
    {
        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest()
        {
            var str = string.Empty;
            str = str.GetRandomValue();
            Assert.IsFalse(string.IsNullOrEmpty(str));
        }
    }
}
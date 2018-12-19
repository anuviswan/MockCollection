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
        public void GetRandomValueTest_String()
        {
            var value = string.Empty;
            value = value.GetRandomValue();
            Assert.IsFalse(string.IsNullOrEmpty(value));
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int32()
        {
            var value = 0;
            value = value.GetRandomValue();
            Assert.AreNotEqual(0,value);
        }
    }
}
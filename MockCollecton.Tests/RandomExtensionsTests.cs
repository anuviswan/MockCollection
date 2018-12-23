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
            var value1 = typeof(string).GetRandomValues();
            var value2 = typeof(string).GetRandomValues();
            Assert.IsFalse(string.IsNullOrEmpty(value1));
            Assert.IsFalse(string.IsNullOrEmpty(value2));
            Assert.AreNotEqual(value1, value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Char()
        {
            var value1 = typeof(char).GetRandomValues();
            var value2 = typeof(char).GetRandomValues();
            Assert.AreNotEqual(value1,value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int32()
        {
            var value1 = typeof(int).GetRandomValues();
            var value2 = typeof(int).GetRandomValues();
            Assert.AreNotEqual(value1,value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int64()
        {
            var value1 = typeof(long).GetRandomValues();
            var value2 = typeof(long).GetRandomValues();
            Assert.AreNotEqual(value1, value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int16()
        {
            var value1 = typeof(short).GetRandomValues();
            var value2 = typeof(short).GetRandomValues();
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Boolean()
        {
            var value1 = typeof(bool).GetRandomValues();
            var value2 = typeof(bool).GetRandomValues();
            Assert.AreNotEqual(value1, value2);
        }
    }
}
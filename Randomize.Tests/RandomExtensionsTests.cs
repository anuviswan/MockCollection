using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomize.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Tests
{
    [TestClass()]
    public class RandomExtensionsTests
    {
        private Random _random = new Random();

        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_String()
        {
            var value1 = _random.GenerateInstance<string>();
            var value2 = _random.GenerateInstance<string>();
            Assert.IsFalse(string.IsNullOrEmpty(value1));
            Assert.IsFalse(string.IsNullOrEmpty(value2));
            Assert.AreNotEqual(value1, value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Char()
        {
            var value1 = _random.GenerateInstance<char>();
            var value2 = _random.GenerateInstance<char>();
            Assert.AreNotEqual(value1,value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int32()
        {
            var value1 = _random.GenerateInstance<int>();
            var value2 = _random.GenerateInstance<int>();
            Assert.AreNotEqual(value1,value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int64()
        {
            var value1 = _random.GenerateInstance<long>();
            var value2 = _random.GenerateInstance<long>();
            Assert.AreNotEqual(value1, value2);
        }


        [TestMethod()]
        [TestCategory("RandomPrimitive")]
        public void GetRandomValueTest_Int16()
        {
            var value1 = _random.GenerateInstance<short>(); ;
            var value2 = _random.GenerateInstance<short>();
            Assert.AreNotEqual(value1, value2);
        }

    }
}
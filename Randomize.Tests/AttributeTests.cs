using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class AttributeTests
    {
        private class TypeWithMaxAndMin
        {
            public string StringProperty { get; set; }
            [NumericConstraint(20,25)]
            public int Int32Property { get; set; }
            public bool BoolProperty { get; set; }
        }

        private class TypeWithMaxOnly
        {
            public string StringProperty { get; set; }
            [NumericConstraint(Int32.MinValue, 15)]
            public int Int32Property { get; set; }
            public bool BoolProperty { get; set; }
        }

        private class TypeWithMinOnly
        {
            public string StringProperty { get; set; }
            [NumericConstraint(15,Int32.MaxValue)]
            public int Int32Property { get; set; }
            public bool BoolProperty { get; set; }
        }

        [TestMethod]
        public void MaxMinLimitTest()
        {
            var list = CollectionExtensions.GenerateCollection<TypeWithMaxAndMin>(100);
            Assert.AreEqual(true, list.All(x => x.Int32Property >= 20 && x.Int32Property <= 25));
        }


        [TestMethod]
        public void OnlyMaxLimitTest()
        {
            var list = CollectionExtensions.GenerateCollection<TypeWithMaxOnly>(1000);
            Assert.AreEqual(true, list.All(x =>  x.Int32Property <= 15));
        }

        [TestMethod]
        public void OnlyMinLimitTest()
        {
            var list = CollectionExtensions.GenerateCollection<TypeWithMinOnly>(1000);
            Assert.AreEqual(true, list.All(x => x.Int32Property >= 15));
        }
    }
    
}

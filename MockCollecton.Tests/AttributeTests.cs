using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockCollecton.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class AttributeTests
    {
        private class TypeWithNoNestedType
        {
            public string StringProperty { get; set; }
            [NumericConstraint(MaxValue = 25, MinValue = 10)]
            public int Int32Property { get; set; }
            public bool BoolProperty { get; set; }
        }

        [TestMethod]
        public void MaxMinLimitTest()
        {
            var list = CollectionExtensions.GenerateCollection<TypeWithNoNestedType>(100);
            var count = list.Where(x => x.Int32Property < 10 || x.Int32Property > 25).Count();
            Assert.AreEqual(0, count);
        }
    }
    
}

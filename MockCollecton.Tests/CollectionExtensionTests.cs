using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockCollection;
using System.Linq;

namespace MockCollecton.Tests
{
    [TestClass]
    public class CollectionExtensionTests
    {
        private class TypeWithNoNestedType
        {
            public string Property1 { get; set; }
            public int Property2 { get; set; }
        }
        [TestMethod]
        public void CreateCollection_NonNested_GenerateCollectionWithCountAsSpecified()
        {
            var expectedCount = 10;
            var instance = CollectionExtensions.GenerateCollection<TypeWithNoNestedType>(expectedCount).ToList();
            Assert.AreEqual(expectedCount, instance.Count);
            foreach (var item in instance)
            {
                Assert.IsNotNull(item.Property1);
                Assert.IsFalse(string.IsNullOrWhiteSpace(item.Property1));
                Assert.AreNotEqual(0,item.Property2);
            }
        }
    }
}


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
            public string StringProperty { get; set; }
            public int Int32Property { get; set; }
            public bool BoolProperty { get; set; }
            public sbyte SByteProperty { get; set; }
            public short ShortProperty { get; set; }
            public long LongProperty { get; set; }
            public byte ByteProperty { get; set; }
            public ushort UShortProperty { get; set; }
            public uint UInt32Property { get; set; }
            public ulong ULongProperty { get; set; }
        }
        [TestMethod]
        public void CreateCollection_NonNested_GenerateCollectionWithCountAsSpecified()
        {
            var expectedCount = 10;
            var instance = CollectionExtensions.GenerateCollection<TypeWithNoNestedType>(expectedCount).ToList();
            Assert.AreEqual(expectedCount, instance.Count);
            foreach (var item in instance)
            {
                Assert.IsNotNull(item.StringProperty);
                Assert.IsFalse(string.IsNullOrWhiteSpace(item.StringProperty));
                Assert.AreNotEqual(0,item.Int32Property);
            }
        }
    }
}



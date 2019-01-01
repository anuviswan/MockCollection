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
            [NumericConstraint(MaxValue = 25, MinValue = 10)]
            public int Int32Property { get; set; }
            public bool BoolProperty { get; set; }
            public sbyte SByteProperty { get; set; }
            public short ShortProperty { get; set; }
            public long LongProperty { get; set; }
            public byte ByteProperty { get; set; }
            public ushort UShortProperty { get; set; }
            public uint UInt32Property { get; set; }
            public ulong ULongProperty { get; set; }
            public float FloatProperty { get; set; }
            public double DoubleProperty { get; set; }
            public char CharProperty { get; set; }
            public decimal DecimalProperty { get; set; }
        }


        private class NestedType
        {
            public string StringProperty { get; set; }
            public TypeWithNoNestedType NestedProperty { get; set; }
        }

        [TestMethod]
        public void CreateCollection_NonNested_GenerateCollectionWithCountAsSpecified()
        {
            var expectedCount = 10;

            var instance1 = CollectionExtensions.GenerateCollection<TypeWithNoNestedType>(expectedCount).ToList();
            var instance2 = CollectionExtensions.GenerateCollection<TypeWithNoNestedType>(expectedCount).ToList();
            Assert.AreEqual(expectedCount, instance1.Count);
            Assert.AreEqual(expectedCount, instance2.Count);

            for (int i = 0; i < expectedCount; i++)
            {
                Assert.AreEqual(false, instance1.All(x => x.StringProperty.Equals(instance1.First().StringProperty)));
                Assert.AreEqual(false, instance1.All(x => x.BoolProperty.Equals(instance1.First().BoolProperty)));
                Assert.AreEqual(false, instance1.All(x => x.ByteProperty.Equals(instance1.First().ByteProperty)));
                Assert.AreEqual(false, instance1.All(x => x.CharProperty.Equals(instance1.First().CharProperty)));
                Assert.AreEqual(false, instance1.All(x => x.DecimalProperty.Equals(instance1.First().DecimalProperty)));
                Assert.AreEqual(false, instance1.All(x => x.DoubleProperty.Equals(instance1.First().DoubleProperty)));
                Assert.AreEqual(false, instance1.All(x => x.FloatProperty.Equals(instance1.First().FloatProperty)));
                Assert.AreEqual(false, instance1.All(x => x.Int32Property.Equals(instance1.First().Int32Property)));
                Assert.AreEqual(false, instance1.All(x => x.LongProperty.Equals(instance1.First().LongProperty)));
                Assert.AreEqual(false, instance1.All(x => x.SByteProperty.Equals(instance1.First().SByteProperty)));
                Assert.AreEqual(false, instance1.All(x => x.ShortProperty.Equals(instance1.First().ShortProperty)));
                Assert.AreEqual(false, instance1.All(x => x.UInt32Property.Equals(instance1.First().UInt32Property)));
                Assert.AreEqual(false, instance1.All(x => x.ULongProperty.Equals(instance1.First().ULongProperty)));
                Assert.AreEqual(false, instance1.All(x => x.UShortProperty.Equals(instance1.First().UShortProperty)));

            }
            
        }


        [TestMethod]
        public void CreateCollection_Nested_GenerateCollectionWithCountAsSpecified()
        {
            var expectedCount = 100;

            var instance1 = CollectionExtensions.GenerateCollection<NestedType>(expectedCount).ToList();
            Assert.AreEqual(expectedCount, instance1.Count);
            
            for (int i = 0; i < expectedCount; i++)
            {
                Assert.AreEqual(false, instance1.All(x=>x.StringProperty.Equals(instance1.First().StringProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.StringProperty.Equals(instance1.First().NestedProperty.StringProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.BoolProperty.Equals(instance1.First().NestedProperty.BoolProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.ByteProperty.Equals(instance1.First().NestedProperty.ByteProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.CharProperty.Equals(instance1.First().NestedProperty.CharProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.DecimalProperty.Equals(instance1.First().NestedProperty.DecimalProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.DoubleProperty.Equals(instance1.First().NestedProperty.DoubleProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.FloatProperty.Equals(instance1.First().NestedProperty.FloatProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.Int32Property.Equals(instance1.First().NestedProperty.Int32Property)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.LongProperty.Equals(instance1.First().NestedProperty.LongProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.SByteProperty.Equals(instance1.First().NestedProperty.SByteProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.ShortProperty.Equals(instance1.First().NestedProperty.ShortProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.UInt32Property.Equals(instance1.First().NestedProperty.UInt32Property)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.ULongProperty.Equals(instance1.First().NestedProperty.ULongProperty)));
                Assert.AreEqual(false, instance1.All(x => x.NestedProperty.UShortProperty.Equals(instance1.First().NestedProperty.UShortProperty)));

            }

        }
    }
}



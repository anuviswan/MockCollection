﻿using System;
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
            public float FloatProperty { get; set; }
            public double DoubleProperty { get; set; }
            public char CharProperty { get; set; }
            public decimal DecimalProperty { get; set; }
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
                Assert.AreNotEqual(instance1[i].StringProperty, instance2[2].StringProperty);
                Assert.AreNotEqual(instance1[i].Int32Property, instance2[2].Int32Property);
                Assert.AreNotEqual(instance1[i].BoolProperty, instance2[2].BoolProperty);
                Assert.AreNotEqual(instance1[i].SByteProperty, instance2[2].SByteProperty);
                Assert.AreNotEqual(instance1[i].ShortProperty, instance2[2].ShortProperty);
                Assert.AreNotEqual(instance1[i].LongProperty, instance2[2].LongProperty);
                Assert.AreNotEqual(instance1[i].ByteProperty, instance2[2].ByteProperty);
                Assert.AreNotEqual(instance1[i].UShortProperty, instance2[2].UShortProperty);
                Assert.AreNotEqual(instance1[i].UInt32Property, instance2[2].UInt32Property);
                Assert.AreNotEqual(instance1[i].ULongProperty, instance2[2].ULongProperty);
                Assert.AreNotEqual(instance1[i].FloatProperty, instance2[2].FloatProperty);
                Assert.AreNotEqual(instance1[i].DoubleProperty, instance2[2].DoubleProperty);
                Assert.AreNotEqual(instance1[i].CharProperty, instance2[2].CharProperty);
                Assert.AreNotEqual(instance1[i].DecimalProperty, instance2[2].DecimalProperty);
            }
            foreach (var item in instance1)
            {
                Assert.IsNotNull(item.StringProperty);
                Assert.IsFalse(string.IsNullOrWhiteSpace(item.StringProperty));
                Assert.AreNotEqual(0,item.Int32Property);
            }
        }
    }
}



using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomize.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockCollecton.Tests.AttributeTests
{
    [TestClass]
    public class ShortAttributeTest
    {
        [TestMethod]
        public void ValidLimit_ValuesRemainsWithinRange()
        {
            var random = new Random();
            var dataList = random.GenerateCollection<Data>(100);
            Assert.IsTrue(dataList.All(x => x.Number >= 10 && x.Number <= 20));
        }

        private class Data
        {
            [Randomize.Net.Attributes.Int16.Limit(Max = 20, Min = 10)]
            public short Number { get; set; }
        }
    }
}

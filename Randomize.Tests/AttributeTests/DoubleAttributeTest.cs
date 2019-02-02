using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomize.Net;
using System;
using System.Linq;

namespace MockCollecton.Tests.AttributeTests
{
    [TestClass]
    public class DoubleAttributeTest
    {
        [TestMethod]
        public void ValidLimit_ValuesRemainsWithinRange()
        {
            var random = new Random();
            var dataList = random.GenerateCollection<Data>(100);
            var list = dataList.Where(x => x.Number < 10 || x.Number > 20).Select(x=>x.Number).ToList();
            Assert.IsTrue(dataList.All(x => x.Number >= 10 && x.Number <= 20));
        }

        private class Data
        {
            [Randomize.Net.Attributes.Double.Limit(Max =20, Min =10)]
            public double Number { get; set; }
        }
    }
}

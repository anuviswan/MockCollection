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
    public class LongAttributeTest
    {
        [TestMethod]
        public void ValidLimit_ValuesRemainsWithinRange()
        {
            var random = new Random();
            var dataList = random.GenerateCollection<Data>(100);
            var list = dataList.Where(x => x.Number < 10 || x.Number > 20).Select(x => x.Number).ToList();
            Assert.IsTrue(dataList.All(x => x.Number >= 10 && x.Number <= 20));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void ValidLimit_ThrowInvalidArguementException()
        {
            var random = new Random();
            var dataList = random.GenerateCollection<IncorrectAttributeData>(100);
            Assert.IsTrue(dataList.All(x => x.Number >= 10 && x.Number <= 20));
        }


        private class IncorrectAttributeData
        {
            [Randomize.Net.Attributes.Double.Limit(MaximumValue = 20, MinimumValue = 10)]
            public long Number { get; set; }
        }

        private class Data
        {
            [Randomize.Net.Attributes.Int64.Limit(MaximumValue = 20, MinimumValue = 10)]
            public long Number { get; set; }
        }
    }
}

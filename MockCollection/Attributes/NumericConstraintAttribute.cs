using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockCollection
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class NumericConstraintAttribute: Attribute
    {
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
    }
}

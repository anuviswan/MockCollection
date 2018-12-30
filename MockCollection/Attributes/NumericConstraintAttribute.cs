using System;

namespace MockCollection
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class NumericConstraintAttribute: Attribute
    {
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
    }
}

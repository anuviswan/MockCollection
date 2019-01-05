using System;

namespace Randomize
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class NumericConstraintAttribute: Attribute
    {
        public double MaxValue { get;  }
        public double MinValue { get; }

        public NumericConstraintAttribute(double minValue,double maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

    }

}

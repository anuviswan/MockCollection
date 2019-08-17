using System;

namespace Randomize.Net.Attributes.Double
{

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LimitAttribute : BaseLimitAttribute, ILimit<double>
    {
        public double MaximumValue { get; set; }
        public double MinimumValue { get; set; }
    }
}

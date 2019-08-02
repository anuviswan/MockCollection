using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes.Int16
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LimitAttribute : BaseLimitAttribute, ILimit<short>
    {
        public short MaximumValue { get; set; }
        public short MinimumValue { get; set; }
    }
}

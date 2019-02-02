using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes.Int64
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LimitAttribute : BaseLimitAttribute, ILimit<long>
    {
        public long Max { get; set; }
        public long Min { get; set; }
    }
}

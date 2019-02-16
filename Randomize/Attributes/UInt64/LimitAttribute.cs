using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes.UInt64
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LimitAttribute : BaseLimitAttribute, ILimit<ulong>
    {
        public ulong Max { get; set; }
        public ulong Min { get; set; }
    }
}

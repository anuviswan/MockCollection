using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes.UInt32
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LimitAttribute : BaseLimitAttribute, ILimit<uint>
    {
        public uint Max { get; set; }
        public uint Min { get; set; }
    }
}

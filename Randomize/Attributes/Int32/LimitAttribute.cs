using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes.Int32
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LimitAttribute : Attribute, ILimit<int>
    {
        public int Max { get; set; }
        public int Min { get; set; }
    }
}

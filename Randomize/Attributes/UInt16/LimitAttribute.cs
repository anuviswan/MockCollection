using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes.UInt16
{
    public class LimitAttribute : BaseLimitAttribute, ILimit<ushort>
    {
        public ushort Max { get; set; }
        public ushort Min { get; set; }
    }
}

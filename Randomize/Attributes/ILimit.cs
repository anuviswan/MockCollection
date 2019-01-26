using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Attributes
{
    public interface ILimit<T>
    {
        T Max { get; set; }
        T Min { get; set; }
    }
}

using Randomize.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net.Exceptions
{
    public class InvalidAttributeException:ArgumentException
    {
        private const string _exceptionMessage = "Invalid attribute for given type";
        public InvalidAttributeException(Type expectedAttribute,string message=null): base($"{(message ?? _exceptionMessage)},Expected Attribute {expectedAttribute}")
        {
            
        }

    }
}

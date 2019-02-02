using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Randomize.Net
{
    public static partial class RandomExtensions
    {
        private static Random _random;
        private static dynamic GetRandomValues(this Type source, Attributes.BaseLimitAttribute limitAttribute=null)
        {
            IDictionary<Type, Func<dynamic>> _actionDictionary = new Dictionary<Type, Func<dynamic>>()
            {
                [typeof(string)] = () => RandomString(),
                [typeof(sbyte)] = () => RandomSByte(),
                [typeof(short)] = () => RandomInt16(),
                [typeof(int)] = () => RandomInt32(limitAttribute),
                [typeof(long)]   = () => RandomInt64(),
                [typeof(bool)]   = () => RandomBoolean(),
                [typeof(double)] = () => RandomDouble(limitAttribute),
                [typeof(byte)]   = () => RandomByte(),
                [typeof(char)]   = () => RandomChar(),
                [typeof(ushort)] = () => RandomUInt16(),
                [typeof(uint)]   = () => RandomUInt32(),
                [typeof(ulong)]  = () => RandomUInt64(),
                [typeof(decimal)] = () => RandomDecimal(),
                [typeof(float)] = () => RandomFloat(),
            };
            return _actionDictionary.ContainsKey(source)? _actionDictionary[source]():GetDefault(source);
        }


        private static object GetDefault(Type type)
        {
            // If no Type was supplied, if the Type was a reference type, or if the Type was a System.Void, return null
            if (type == typeof(string))
            {
                return string.Empty;
            }
            if (type == null || !type.IsValueType || type == typeof(void))
                return null;

            // If the supplied Type has generic parameters, its default value cannot be determined
            if (type.ContainsGenericParameters)
                throw new ArgumentException(
                    "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
                    "> contains generic parameters, so the default value cannot be retrieved");

            // If the Type is a primitive type, or if it is another publicly-visible value type (i.e. struct), return a 
            //  default instance of the value type
            if (type.IsPrimitive || !type.IsNotPublic)
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(
                        "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nThe Activator.CreateInstance method could not " +
                        "create a default instance of the supplied value type <" + type +
                        "> (Inner Exception message: \"" + e.Message + "\")", e);
                }
            }

            // Fail with exception
            throw new ArgumentException("{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
                "> is not a publicly-visible type, so the default value cannot be retrieved");
        }
    }

    
}


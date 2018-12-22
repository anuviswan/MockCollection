using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MockCollection
{
    public class CollectionExtensions
    {
        public static IEnumerable<T> GenerateCollection<T>(int count = 1)
        {
            for(int i = 0; i < count; i++)
            {
                var instance = GenerateInstance<T>();
                AssignProperties(instance);
                yield return instance;
            }
        }
        public static T GenerateInstance<T>()
        {
            
            return Activator.CreateInstance<T>();
        }
        private static void AssignProperties(object obj)
        {
            if (obj == null) return;
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var randomValue = property.PropertyType.GetRandomValues();
                property.SetValue(obj, randomValue);
                //object propValue = property.GetValue(obj, null);
                //property.SetValue(obj, null, null);
                //var elems = propValue as IList;
                //if (elems != null)
                //{
                //    foreach (var item in elems)
                //    {
                //        AssignProperties(item);
                //    }
                //}
                //else
                //{
                //    // This will not cut-off System.Collections because of the first check
                //    if (property.PropertyType.Assembly == objType.Assembly)
                //    {
                //        //Console.WriteLine("{0}{1}:", indentString, property.Name);

                //        AssignProperties(propValue);
                //    }
                //    else
                //    {
                //        //Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                //    }
                //}
            }
        }

        public static object GetDefault(Type type)
        {
            // If no Type was supplied, if the Type was a reference type, or if the Type was a System.Void, return null
            if(type == typeof(string))
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

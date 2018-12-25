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
                object propValue = property.GetValue(obj, null);
                property.SetValue(obj, null, null);

                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        AssignProperties(item);
                    }
                }
                else
                {
                    // This will not cut-off System.Collections because of the first check
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        //Console.WriteLine("{0}{1}:", indentString, property.Name);
                        AssignProperties(propValue);
                    }
                    else
                    {
                        var randomValue = property.PropertyType.GetRandomValues();
                        property.SetValue(obj, randomValue);
                    }
                }
            }
        }

        

    }
}

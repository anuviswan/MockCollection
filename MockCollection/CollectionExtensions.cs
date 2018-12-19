using System;
using System.Collections.Generic;
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
                yield return GenerateInstance<T>();
            }
        }
        public static T GenerateInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }
        private static void PrintProperties(object obj, int indent)
        {

            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                if (property.PropertyType.Assembly == objType.Assembly)
                {
                    Console.WriteLine("{0}{1}:", indentString, property.Name);

                    PrintProperties(propValue, indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                }
            }
        }

    }
}

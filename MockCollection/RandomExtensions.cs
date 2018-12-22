using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockCollection
{
    public static class RandomExtensions
    {
        private static Random random = new Random();
        public static dynamic GetRandomValues(this Type source)
        {
            IDictionary<Type, Func<dynamic>> _actionDictionary = new Dictionary<Type, Func<dynamic>>()
            {
                [typeof(string)] = ()=> RandomString(),
                [typeof(int)] = () => RandomInt32(),
            };
            return _actionDictionary[source].Invoke();
        }
        private static int RandomInt32(int minValue = 0,int maxValue= Int32.MaxValue)
        {
            return random.Next(minValue, maxValue);
        }
        private static string RandomString(int length=10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}


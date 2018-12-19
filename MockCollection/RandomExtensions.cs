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

        public static dynamic GetRandomValue<TSource>(this TSource source)
        {
            switch (source)
            {
                case string s:
                    return RandomString();
                case int i32:
                    return RandomInt32();
                default:
                    break;
            }
            return default;
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

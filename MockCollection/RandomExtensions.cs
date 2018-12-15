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
                default:
                    break;
            }
            return default;
        }

        
        public static string RandomString(int length=10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

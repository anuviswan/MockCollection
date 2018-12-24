using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockCollection
{
    public static partial class RandomExtensions
    {
        private static bool RandomBoolean()
        {
            return Convert.ToBoolean(random.Next(0, 2)); // Max value is exclusive
        }
        private static double RandomDouble(Int32 minValue=Int32.MinValue,Int32 maxValue= Int32.MaxValue)
        {
            return random.NextDouble() * (double)random.Next(minValue,maxValue);
        }

        private static char RandomChar(bool isLowerCase = true)
        {
            if (isLowerCase)
                return  (char)random.Next((int)'a', (int)'z');
             else
                return (char)random.Next((int)'A', (int)'A');
        }
        private static byte RandomByte()
        {
            var byteArray = new byte[1];
            random.NextBytes(byteArray);
            return byteArray[0];
        }

        private static short RandomInt16(int minValue = Int16.MinValue, int maxValue = Int16.MaxValue)
        {
            return (short)random.Next(minValue, maxValue);
        }

        private static int RandomInt32(int minValue = int.MinValue, int maxValue = Int32.MaxValue)
        {
            return random.Next(minValue, maxValue);
        }

        private static long RandomInt64(long minValue = Int32.MinValue, long maxValue = Int32.MaxValue)
        {
            long result = random.Next((Int32)(minValue >> 32), (Int32)(maxValue >> 32));
            result = (result << 32);
            result = result | (long)random.Next((Int32)minValue, (Int32)maxValue);
            return result;
        }

        private static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

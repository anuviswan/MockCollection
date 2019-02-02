using System;
using System.Linq;

namespace Randomize.Net
{
    public static partial class RandomExtensions
    {
        private static bool RandomBoolean()
        {
            return Convert.ToBoolean(_random.Next(0, 2)); 
        }
        private static double RandomDouble(Attributes.BaseLimitAttribute baseLimitAttribute=null)
        {
            if (baseLimitAttribute is Attributes.Double.LimitAttribute limit)
                return limit.Min + _random.NextDouble() * (limit.Max - limit.Min);

            return _random.NextDouble() * (double)_random.Next(Int32.MinValue,Int32.MaxValue);
        }

        private static char RandomChar(bool isLowerCase = true)
        {
            if (isLowerCase)
                return  (char)_random.Next((int)'a', ((int)'z')+1);
             else
                return (char)_random.Next((int)'A', ((int)'A')+1);
        }
        private static byte RandomByte()
        {
            var byteArray = new byte[1];
            _random.NextBytes(byteArray);
            return byteArray[0];
        }

        private static sbyte RandomSByte(int minValue=sbyte.MinValue, int maxValue = sbyte.MaxValue)
        {
            return (sbyte)_random.Next(minValue, maxValue);
        }

        private static float RandomFloat()
        {
            double mantissa = (_random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, _random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        private static int NextInt32(this Random rng)
        {
            int firstBits = rng.Next(0, 1 << 4) << 28;
            int lastBits = rng.Next(0, 1 << 28);
            return firstBits | lastBits;
        }

        private static decimal RandomDecimal()
        {
            byte scale = (byte)_random.Next(29);
            bool sign = _random.Next(2) == 1;
            return new decimal(_random.NextInt32(),
                               _random.NextInt32(),
                               _random.NextInt32(),
                               sign,
                               scale);
        }

        private static short RandomInt16(Attributes.BaseLimitAttribute baseLimitAttribute = null)
        {
            if (baseLimitAttribute is Attributes.Int16.LimitAttribute attribute)
                return (short)_random.Next(attribute.Min,attribute.Max);
            return (short)_random.Next((int)short.MinValue, short.MaxValue);
        }

        private static int RandomInt32(Attributes.BaseLimitAttribute baseLimitAttribute = null)
        {
            if(baseLimitAttribute is Attributes.Int32.LimitAttribute attribute)
                return _random.Next(attribute.Min, attribute.Max);

            return _random.Next(Int32.MinValue,Int32.MaxValue); 
        }

        private static long RandomInt64(Attributes.BaseLimitAttribute baseLimitAttribute = null)
        {
            var minValue = long.MinValue;
            var maxValue = long.MaxValue;

            if (baseLimitAttribute is Attributes.Int64.LimitAttribute attribute)
            {
                minValue = attribute.Min;
                maxValue = attribute.Max;
            }

            long result = _random.Next((Int32)(minValue >> 32), (Int32)(maxValue >> 32));
            result = (result << 32);
            result = result | (long)_random.Next((Int32)minValue, (Int32)maxValue);
            return result;
        }

        
        private static UInt16 RandomUInt16()
        {
            var byteArray = new byte[2];
            _random.NextBytes(byteArray);
            return BitConverter.ToUInt16(byteArray, 0);
        }

        private static UInt32 RandomUInt32()
        {
            var byteArray = new byte[4];
            _random.NextBytes(byteArray);
            return BitConverter.ToUInt32(byteArray,0);
        }

        private static UInt64 RandomUInt64()
        {
            var byteArray = new byte[8];
            _random.NextBytes(byteArray);
            return BitConverter.ToUInt64(byteArray, 0);
        }

        private static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}

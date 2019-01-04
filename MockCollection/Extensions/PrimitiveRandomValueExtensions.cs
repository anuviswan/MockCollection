using System;
using System.Linq;

namespace MockCollection
{
    public static partial class RandomExtensions
    {
        private static bool RandomBoolean()
        {
            return Convert.ToBoolean(random.Next(0, 2)); 
        }
        private static double RandomDouble(Int32 minValue=Int32.MinValue,Int32 maxValue= Int32.MaxValue)
        {
            return random.NextDouble() * (double)random.Next(minValue,maxValue);
        }

        private static char RandomChar(bool isLowerCase = true)
        {
            if (isLowerCase)
                return  (char)random.Next((int)'a', ((int)'z')+1);
             else
                return (char)random.Next((int)'A', ((int)'A')+1);
        }
        private static byte RandomByte()
        {
            var byteArray = new byte[1];
            random.NextBytes(byteArray);
            return byteArray[0];
        }

        private static sbyte RandomSByte(int minValue=sbyte.MinValue, int maxValue = sbyte.MaxValue)
        {
            return (sbyte)random.Next(minValue, maxValue);
        }

        private static float RandomFloat()
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        public static int NextInt32(this Random rng)
        {
            int firstBits = rng.Next(0, 1 << 4) << 28;
            int lastBits = rng.Next(0, 1 << 28);
            return firstBits | lastBits;
        }

        public static decimal RandomDecimal()
        {
            byte scale = (byte)random.Next(29);
            bool sign = random.Next(2) == 1;
            return new decimal(random.NextInt32(),
                               random.NextInt32(),
                               random.NextInt32(),
                               sign,
                               scale);
        }

        private static short RandomInt16(int minValue = Int16.MinValue, int maxValue = Int16.MaxValue)
        {
            return (short)random.Next(minValue, maxValue);
        }

        private static int RandomInt32(int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
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

        
        private static UInt16 RandomUInt16()
        {
            var byteArray = new byte[2];
            random.NextBytes(byteArray);
            return BitConverter.ToUInt16(byteArray, 0);
        }

        private static UInt32 RandomUInt32()
        {
            var byteArray = new byte[4];
            random.NextBytes(byteArray);
            return BitConverter.ToUInt32(byteArray,0);
        }

        private static UInt64 RandomUInt64()
        {
            var byteArray = new byte[8];
            random.NextBytes(byteArray);
            return BitConverter.ToUInt64(byteArray, 0);
        }

        private static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public abstract class Decoder : IDecoder
    {
        public abstract List<KeyValuePair<long, long>> Decode(MemoryLine m, List<KeyValuePair<int, int>> currentMask);

        protected long GetFromBits(int[] values)
        {
            long result = 0;

            for (var i = 35; i >= 0; --i)
            {
                if (values[35 - i] == 1)
                {
                    result += Pow2(i);
                }
            }

            //Console.WriteLine($"{ToString(values)} ({result})");

            return result;
        }

        private static long Pow2(int pow)
        {
            if(pow == 0)
            {
                return 1;
            }
            var result = 2L;

            for (var i = 2; i <= pow; ++i)
            {
                result *= 2;
            }

            return result;
        }

        protected int[] LongToBits(long value)
        {
            var s = Convert.ToString(value, 2);
            var newValue = s.PadLeft(36, '0')
             .Select(c => int.Parse(c.ToString()))
             .ToArray();
            return newValue;
        }

        private string ToString(int[] values)
        {
            var builder = new StringBuilder();
            var k = 0;
            while (k < 9) {
                for (var i = 0; i < 4; ++i)
                {
                    builder.Append(values[k * 4 + i]);
                }
                k++;
                builder.Append(' ');
            }

            return builder.ToString();
        }
    }
}

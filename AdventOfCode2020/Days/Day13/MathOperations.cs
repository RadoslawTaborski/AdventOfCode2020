using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    public class MathOperations
    {
        public static long LeastCommonMultiple(long a, long b)
        {
            return LeastCommonMultipleWithOffset(a, b, 0);
        }
        public static long LeastCommonMultipleWithOffset(long a, long b, long offset)
        {
            if (a < b)
                return LeastCommonMultipleWithOffset(b, a, -offset);
            long k = a;
            while ((k + offset) % b != 0)
                k += a;
            return offset > 0 ? k : k + offset;
        }
    }
}

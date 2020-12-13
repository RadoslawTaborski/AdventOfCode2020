using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    [Puzzle(13,2)]
    public class Task2 : Day13
    {
        protected override string FindValue(int start, List<Bus> buses)
        {
            var lcm = (long)buses[0].Span;
            var offset = 0L;
            foreach(var bus in buses.Skip(1))
            {
                offset += MathOperations.LeastCommonMultipleWithOffset(lcm, bus.Span, bus.Offset + offset);
                lcm = MathOperations.LeastCommonMultiple(lcm, bus.Span);
            }

            return $"{offset}";
        }
    }
}

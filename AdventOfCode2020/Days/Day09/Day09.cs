using AdventOfCode2020.Helpers;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day09
{
    public abstract class Day09 : Task
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt").Select(x=>long.Parse(x));

            result = $"{FindValue(input)}";
        }

        internal abstract long FindValue(IEnumerable<long> input);
    }
}

using AdventOfCode2020.Days.Day05.Calculator;
using AdventOfCode2020.Days.Day05.Decoders;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day05
{
    [Task(5, 2)]
    public class Task2 : Day05
    {
        protected override int SelectValue(List<int> values)
        {
            values.Sort();

            for (var idx = 1; idx + 1 < values.Count; ++idx)
            {
                var previous = values[idx - 1];
                var next = values[idx + 1];
                if (next - previous > 2)
                {
                    return next - 1;
                }
            }

            return -1;
        }
    }
}

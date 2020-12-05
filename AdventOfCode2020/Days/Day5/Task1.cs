
using AdventOfCode2020.Days.Day5.Calculator;
using AdventOfCode2020.Days.Day5.Decoders;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day5
{
    [Task(5)]
    public class Task1 : Day5
    {
        protected override int SelectValue(List<int> values)
        {
            return values.Max();
        }
    }
}

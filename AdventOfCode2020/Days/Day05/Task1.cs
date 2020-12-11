
using AdventOfCode2020.Days.Day05.Calculator;
using AdventOfCode2020.Days.Day05.Decoders;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day05
{
    [Puzzle(5)]
    public class Task1 : Day05
    {
        protected override int SelectValue(List<int> values)
        {
            return values.Max();
        }
    }
}

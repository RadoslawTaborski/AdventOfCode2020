using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day12
{
    public abstract class Day12 : Puzzle
    {
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("Input1.txt");
        }
    }
}

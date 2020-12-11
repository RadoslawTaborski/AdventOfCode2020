using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day10
{
    public abstract class Day10 : Puzzle
    {
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("Input1.txt").Select(x => int.Parse(x)).ToList();

            result = FindValue(input);
        }

        protected abstract string FindValue(List<int> input);
    }
}

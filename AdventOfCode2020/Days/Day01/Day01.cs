using AdventOfCode2020.Helpers;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day01
{
    public abstract class Day01: Puzzle
    {
        protected void Result(int noOfItems, int sum, out string result)
        {
            var input = ReadRows($"Input.txt").Select(x => long.Parse(x)).ToList();

            var output = SumFinder.Find(input, noOfItems, sum);

            if (output.Count > 0)
            {
                result = ValuesMultiplicator.GetMathOperation(output);
                return;
            }

            result = "not found";
        }
    }
}

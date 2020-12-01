using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day1
{
    public abstract class Day1: Task
    {
        protected void Result(int noOfItems, int sum, out string result)
        {
            var input = ReadRows($"Input.txt").Select(x => int.Parse(x)).ToList();

            var output = ValuesFinder.Find(input, noOfItems, sum);

            if (output != null)
            {
                result = ValuesMultiplicator.GetMathOperation(output);
                return;
            }

            result = "not found";
        }
    }
}

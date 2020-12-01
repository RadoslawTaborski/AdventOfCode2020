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
            var input = ReadRows($"Task1.txt").Select(x => int.Parse(x)).ToList();

            var output = ValueFinder.Find(input, noOfItems, sum);

            if (output != null)
            {
                result = ValuesMultiplicator.MathOperation(output);
                return;
            }

            result = "not found";
        }
    }
}

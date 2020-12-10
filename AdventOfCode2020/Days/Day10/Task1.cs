using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day10
{
    [Task(10)]
    public class Task1: Day10
    {
        protected override string FindValue(List<int> input)
        {
            input.Add(0);
            input.Add(input.Max() + 3);

            input.Sort();

            var differences = GetDifferences(input);

            var countedDifference1 = differences[1];
            var countedDifference3 = differences[3];

            return $"{countedDifference1} * {countedDifference3} = {countedDifference1 * countedDifference3}";
        }

        private Dictionary<int, int> GetDifferences(List<int> input)
        {
            var result = new Dictionary<int, int>();
            for (int i = 1; i < input.Count; i++)
            {
                int difference = input[i] - input[i - 1];
                if (result.ContainsKey(difference))
                {
                    result[difference] = result[difference] + 1;
                }
                else
                {
                    result.Add(difference, 1);
                }
            }

            return result;
        }
    }
}

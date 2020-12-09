using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day09
{
    [Task(9, 2)]
    public class Task2 : Day09
    {
        internal override long FindValue(IEnumerable<long> input)
        {
            var task1Result = new Task1().FindValue(input);

            var (start, count) = FindIndexes(input, task1Result);

            var collection = input.Skip(start).Take(count);
            var min = collection.Min();
            var max = collection.Max();

            return min+max;
        }

        private (int start, int count) FindIndexes(IEnumerable<long> input, long searchedValue)
        {
            for (var i = 0; i < input.Count(); ++i)
            {
                long sum = 0;
                var j = 0;
                while (sum < searchedValue)
                {
                    sum += input.ElementAt(i + j);

                    if (sum == searchedValue)
                    {
                        return (i, j);
                    }

                    j++;
                }
            }

            return (-1, -1);
        }
    }
}

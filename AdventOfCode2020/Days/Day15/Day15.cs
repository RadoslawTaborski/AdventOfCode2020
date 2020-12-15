using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day15
{
    public abstract partial class Day15 : Puzzle
    {
        private readonly Dictionary<long, Number> collection = new Dictionary<long, Number>();
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("Input1.txt")[0].Split(",").Select(x => long.Parse(x)).ToList();

            var (counter, lastValue) = Init(input);

            while (counter < GetLastTurn())
            {
                counter++;
                if (lastValue.PreviousIndex == 0)
                {
                    lastValue = PutValue(0, counter);
                }
                else
                {
                    lastValue = PutValue(lastValue.LastIndex - lastValue.PreviousIndex, counter);
                }
            }

            result = $"{lastValue.Value}";
        }

        protected abstract long GetLastTurn();

        private (long counter, Number lastValue) Init(List<long> input)
        {
            var counter = 0L;
            Number lastValue = null;
            foreach(var inp in input)
            {
                counter++;
                lastValue = PutValue(inp, counter);
            }

            return (counter, lastValue);
        }

        private Number PutValue(long inp, long k)
        {
            if (collection.ContainsKey(inp))
            {
                collection[inp] = collection[inp].Update(k);
            } else
            {
                collection[inp] = new Number(inp, k);
            }

            //Console.WriteLine($"{k}- {collection[inp].Value}; {collection[inp].Counter}; {collection[inp].LastIndex}");

            return collection[inp];
        }
    }
}

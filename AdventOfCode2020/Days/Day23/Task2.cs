using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day23
{
    [Puzzle(23, 2)]
    public class Task2 : Day23
    {
        protected override Cup Extends(Cup cup, int max)
        {
            var tmpCup = cup;
            for(var i = max +1; i<= 1000000; ++i)
            {
                var newCup = new Cup(i);
                tmpCup.SetNext(newCup);
                tmpCup = newCup;
            }
            return tmpCup;
        }

        protected override string FindValue(Circle circle)
        {
            string result;
            var start = circle.GetCup(1);

            result = $"{(long)start.Next.Id * start.Next.Next.Id}";
            return result;
        }

        protected override int GetNoOfTurns()
        {
            return 10000000;
        }
    }
}

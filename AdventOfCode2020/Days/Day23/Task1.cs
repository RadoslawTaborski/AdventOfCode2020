using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day23
{
    [Puzzle(23)]
    public class Task1 : Day23
    {
        protected override Cup Extends(Cup cup, int max)
        {
            return cup;
        }

        protected override string FindValue(Circle circle)
        {
            string result;
            var collectionStartingAt1 = circle.GetAll(circle.GetCup(1)).Select(x => x.Id);
            result = $"{string.Join("", collectionStartingAt1.Skip(1))}";
            return result;
        }

        protected override int GetNoOfTurns()
        {
            return 100;
        }
    }
}

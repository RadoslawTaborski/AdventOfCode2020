using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    [Puzzle(11, 2)]
    public class Task2 : Day11
    {
        protected override TurnMaker GetTurnMaker()
        {
            return new TurnMaker(5, new Task2NeighborhoodChecker());
        }
    }
}

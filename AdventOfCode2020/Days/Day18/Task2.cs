using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    [Puzzle(18, 2)]
    public class Task2 : Day18
    {
        protected override ICreator GetCreator()
        {
            return new Task2Creator();
        }
    }
}

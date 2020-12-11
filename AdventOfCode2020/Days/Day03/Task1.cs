using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day03
{
    [Puzzle(3)]
    public class Task1 : Day03
    {
        protected override void Result(out string result)
        {
            int countedChars = StartTravel(0, 0, 3, 1, 0, 0, '#');

            result = $"{countedChars}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public class Position
    {
        public int X { get; init; }
        public int Y { get; init; }
        public Turn Turn { get; init; }

        public override string ToString()
        {
            return $"X:{X}; Y:{Y}; Turn:{Turn}";
        }
    }
}

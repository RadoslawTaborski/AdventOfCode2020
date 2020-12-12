using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public class Move : IStep
    {
        public Direction Direction { get; init; }
        public int Value { get; init; }
    }

    public enum Direction
    {
        N, S, E, W
    }
}

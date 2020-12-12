using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public class Rotation : IStep
    {
        public int Value { get; init; }
        public Turn Turn { get; init; }
    }
}

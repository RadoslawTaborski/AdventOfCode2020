using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public class MemoryLine : IProgramLine
    {
        public long Position { get; init; }
        public long InputValue { get; init; }
    }
}

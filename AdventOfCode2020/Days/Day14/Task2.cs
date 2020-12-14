using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    [Puzzle(14,2)]
    public class Task2 : Day14
    {
        private readonly Processor processor = new Processor(new List<IDecoder> { new Task2Decoder() });
        protected override Processor GetProcessor()
        {
            return processor;
        }
    }
}

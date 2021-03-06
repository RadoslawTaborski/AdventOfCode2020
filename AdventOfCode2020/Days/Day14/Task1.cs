﻿using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    [Puzzle(14)]
    public class Task1 : Day14
    {
        private readonly Processor processor = new Processor(new List<IDecoder> { new Task1Decoder() });
        protected override Processor GetProcessor()
        {
            return processor;
        }
    }
}

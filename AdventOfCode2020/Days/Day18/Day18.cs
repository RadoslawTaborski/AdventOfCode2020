﻿using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    public abstract class Day18 : Puzzle
    {
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("input1.txt");
        }
    }
}

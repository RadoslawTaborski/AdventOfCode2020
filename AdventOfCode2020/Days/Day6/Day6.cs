﻿using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day6
{
    public abstract class Day6 : Task
    {
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows($"Input1.txt");
        }
    }
}

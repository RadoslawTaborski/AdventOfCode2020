﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day8.Operations
{
    public class NoOperation : IOperation
    {
        public int Value { get; init; }

        public int Action(int currentValue)
        {
            return currentValue;
        }

        public int Jump(int idx)
        {
            return idx + 1;
        }
    }
}

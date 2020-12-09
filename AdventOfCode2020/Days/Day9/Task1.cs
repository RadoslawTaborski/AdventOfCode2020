﻿using AdventOfCode2020.Helpers;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day9
{
    [Task(9)]
    public class Task1 : Day9
    {
        internal override long FindValue(IEnumerable<long> input)
        {
            for (var i = 0; i < input.Count() - 25; ++i)
            {
                var res = SumFinder.Find(input.Skip(i).Take(25).ToList(), 2, input.ElementAt(i + 25));
                if (res.Count == 0)
                {
                    return input.ElementAt(i + 25);
                }
            }
            return -1;
        }
    }
}

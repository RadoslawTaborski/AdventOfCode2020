﻿using AdventOfCode2020.Days.Day02.Rules;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day02
{
    [Puzzle(2, 2)]
    public class Task2 : Day02
    {
        protected override List<IRule> CreateRules((int v1, int v2, string v3, string v4) data)
        {
            var result = new List<IRule>
            {
                new Rule2
                {
                    Idx1 = data.v1,
                    Idx2 = data.v2,
                    Value = data.v3
                }
            };

            return result;
        }
    }
}

﻿using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    [Task(11)]
    public class Task1 : Day11
    {
        protected override TurnMaker GetTurnMaker()
        {
            return new TurnMaker(4, new Task1NeighborhoodChecker());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day08.Operations
{
    public class AccumulationOperation : IOperation
    {
        public int Value { get; init; }

        public int Action(int currentValue)
        {
            return currentValue+Value;
        }

        public int Jump(int idx)
        {
            return idx + 1;
        }
    }
}

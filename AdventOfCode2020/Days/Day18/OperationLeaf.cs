using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    public class OperationLeaf : IOperation
    {
        public long Value { get; init; }
        public long GetResult()
        {
            return Value;
        }
    }
}

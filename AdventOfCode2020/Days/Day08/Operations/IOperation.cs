using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day08.Operations
{
    public interface IOperation
    {
        public int Value { get; }
        public int Jump(int idx);
        public int Action(int currentValue);
    }
}

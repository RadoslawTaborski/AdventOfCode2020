using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    public class Operation : IOperation
    {
        public Operator Operator { get; init; }
        public List<IOperation> Values { get; init; } = new List<IOperation>();

        public long GetResult()
        {
            long v = Operator switch
            {
                Operator.Addition => Values[0].GetResult() + Values[1].GetResult(),
                Operator.Multiplication => Values[0].GetResult() * Values[1].GetResult(),
                _ => throw new Exception("illegal operation"),
            };
            //Console.WriteLine(v);
            return v;
        }
    }
}

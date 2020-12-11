using AdventOfCode2020.Days.Day08.Operations;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day08
{
    public abstract class Day08 : Puzzle
    {
        private IOperationFactory factory = new OperationFactory();

        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");

            List<IOperation> operations = new List<IOperation>();

            foreach (var inp in input)
            {
                operations.Add(factory.Create(inp));
            }

            int output = GetResult(operations);

            result = $"{output}";
        }

        protected abstract int GetResult(List<IOperation> operations);
    }
}

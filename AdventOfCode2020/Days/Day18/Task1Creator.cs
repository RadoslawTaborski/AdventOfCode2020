using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    public class Task1Creator : Creator
    {
        protected override IOperation CreateOperation(List<string> newInputs, List<Operator> operators)
        {
            var operations = new List<IOperation>();
            foreach (var inp in newInputs)
            {
                operations.Add(CreateChild(inp));
            }

            var first = operations.First();
            var idx = 0;
            foreach (var op in operations.Skip(1))
            {
                first = MergeOperations(first, op, operators[idx]);
                idx++;
            }

            return first;
        }
    }
}

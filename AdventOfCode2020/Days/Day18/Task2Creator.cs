using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    public class Task2Creator : Creator
    {
        protected override IOperation CreateOperation(List<string> newInputs, List<Operator> operators)
        {
            var operations = new List<IOperation>();
            foreach (var inp in newInputs)
            {
                operations.Add(CreateChild(inp));
            }

            var indexes = new List<int>();
            for(var i=0; i < operators.Count; ++i)
            {
                if(operators[i]==Operator.Addition)
                    indexes.Add(i);
            }

            var opToRemove = new List<int>();
            for (var i = 0; i< indexes.Count; ++i)
            {
                var op1 = operations[indexes[i]];
                var op2 = operations[indexes[i] + 1];
                var merged = MergeOperations(op1, op2, operators[indexes[i]]);

                operations[indexes[i]+1] = merged;
                opToRemove.Add(indexes[i]);
            }

            opToRemove.Reverse();
            foreach (var i in opToRemove)
            {
                operators.RemoveAt(i);
                operations.RemoveAt(i);
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

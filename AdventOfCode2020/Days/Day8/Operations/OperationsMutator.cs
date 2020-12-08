using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day8.Operations
{
    public class OperationsMutator
    {
        public List<List<IOperation>> Mutate(List<IOperation> operations)
        {
            var result = new List<List<IOperation>>();

            for(var i = 0; i< operations.Count; ++i)
            {
                if(operations[i] is JumpOperation)
                {
                    var newOperations = new List<IOperation>(operations);
                    newOperations[i] = new NoOperation { Value = operations[i].Value };
                    result.Add(newOperations);
                }
                if (operations[i] is NoOperation)
                {
                    var newOperations = new List<IOperation>(operations);
                    newOperations[i] = new JumpOperation { Value = operations[i].Value };
                    result.Add(newOperations);
                }
            }

            return result;
        }
    }
}

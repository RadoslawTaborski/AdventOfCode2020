using AdventOfCode2020.Days.Day08.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day08
{
    public class Processor
    {
        private List<KeyValuePair<IOperation, int>> operations;

        public Processor(List<IOperation> operations)
        {
            this.operations = operations.Select(x => new KeyValuePair<IOperation, int>(x, 0)).ToList(); ;
        }

        public int Process(int loops, out bool lastLineAchivement)
        {
            lastLineAchivement = false;
            var accumulator = 0;

            int idx = 0;
            KeyValuePair<IOperation, int> currentOperation = operations[idx];
            while (currentOperation.Value < loops)
            {
                if(idx == operations.Count - 1)
                {
                    lastLineAchivement = true;
                }
                operations[idx] = new KeyValuePair<IOperation, int>(currentOperation.Key, currentOperation.Value + 1);

                accumulator = currentOperation.Key.Action(accumulator);
                idx = currentOperation.Key.Jump(idx);
                if (idx < 0)
                {
                    idx = 0;
                }
                if (idx >= operations.Count)
                {
                    idx = operations.Count - 1;
                }
                currentOperation = operations[idx];
            }

            return accumulator;
        }
    }
}

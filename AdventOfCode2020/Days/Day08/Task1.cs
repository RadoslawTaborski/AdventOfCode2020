using AdventOfCode2020.Days.Day08.Operations;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day08
{
    [Task(8)]
    public class Task1 : Day08
    {
        protected override int GetResult(List<IOperation> operations)
        {
            var processor = new Processor(operations);
            var output = processor.Process(1, out var success);
            return output;
        }
    }
}

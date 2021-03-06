﻿using AdventOfCode2020.Days.Day08.Operations;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day08
{
    [Puzzle(8, 2)]
    public class Task2 : Day08
    {
        private OperationsMutator mutator = new OperationsMutator();

        protected override int GetResult(List<IOperation> operations)
        {
            var lists = mutator.Mutate(operations);

            foreach(var list in lists)
            {
                var processor = new Processor(list);
                var output = processor.Process(1, out var success);

                if (success)
                {
                    return output;
                }
            }

            return 0;
        }
    }
}

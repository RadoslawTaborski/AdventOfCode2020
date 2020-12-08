using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day8.Operations
{
    public class OperationFactory : IOperationFactory
    {
        public IOperation Create(string line)
        {
            var parts = line.Split(" ");
            var value = int.Parse(parts[1].Replace("+", ""));
            switch (parts[0])
            {
                case "nop":
                    return new NoOperation { Value = value };
                case "jmp":
                    return new JumpOperation { Value = value };
                case "acc":
                    return  new AccumulationOperation { Value = value };
                default:
                    throw new InvalidOperationException($"Operation {parts[0]} not exists");
            }
        }
    }
}

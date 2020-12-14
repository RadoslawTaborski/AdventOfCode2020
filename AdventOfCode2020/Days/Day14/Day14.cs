using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public abstract class Day14 : Puzzle
    {
        protected abstract Processor GetProcessor();
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");
            
            List<IProgramLine> lines = ProgramReader.Read(input);

            var output = GetProcessor().GetOutput(lines);

            var sum = output.Values.Sum();

            result = $"{sum}";
        }
    }
}

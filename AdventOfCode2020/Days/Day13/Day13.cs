using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    public abstract class Day13 : Puzzle
    {
        private IBusCreator creator = new BusCreator();
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");
            var start = int.Parse(input[0]);
            var buses = creator.Create(input[1]);

            result = FindValue(start, buses);
        }

        protected abstract string FindValue(int start, List<Bus> buses);
    }
}

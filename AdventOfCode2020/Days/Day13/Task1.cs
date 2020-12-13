using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    [Puzzle(13)]
    public class Task1 : Day13
    {
        private IBusSearcher searcher = new Task1BusSearcher();

        protected override string FindValue(int start, List<Bus> buses)
        {
            var (bus, end) = searcher.GetBus(buses, start);

            var difference = end - start;

            return $"{int.Parse(bus.Id) * difference}";
        }
    }
}

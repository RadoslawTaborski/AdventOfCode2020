using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day17
{
    public class Rule
    {
        public CellState From { get; init; }
        public CellState To { get; init; }
        public CellState Default { get; init; }
        public List<int> Values { get; init; }
    }
}
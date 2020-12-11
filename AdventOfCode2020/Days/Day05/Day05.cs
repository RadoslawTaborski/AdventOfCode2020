using AdventOfCode2020.Days.Day05.Calculator;
using AdventOfCode2020.Days.Day05.Decoders;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day05
{
    public abstract class Day05 : Puzzle
    {
        protected abstract int SelectValue(List<int> values);

        protected override void Result(out string result)
        {
            var input = ReadRows($"Input1.txt");

            var val = new List<int>();
            foreach(var inp in input)
            {
                var place = GetDecoder().Decode(inp);
                var id = GetIdCalculator().Calculate(place.row, place.column);
                val.Add(id);
            }

            result = $"{SelectValue(val)}";
        }

        private IDecoder GetDecoder()
        {
            return new PlaceDecoder
            {
                NoOfColumn = 8,
                NoOfRow = 128
            };
        }

        private IPlaceIdCalculator GetIdCalculator()
        {
            return new PlaceIdCalculator
            {
                MultiplyRow = 8
            };
        }
    }
}

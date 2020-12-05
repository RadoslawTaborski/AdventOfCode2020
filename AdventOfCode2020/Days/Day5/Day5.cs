using AdventOfCode2020.Days.Day5.Calculator;
using AdventOfCode2020.Days.Day5.Decoders;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day5
{
    public abstract class Day5 : Task
    {
        protected abstract int SelectValue(List<int> values);

        protected override void Result(out string result)
        {
            var input = ReadRows($"Input1.txt");

            var values = new List<int>();
            foreach(var inp in input)
            {
                var place = GetDecoder().Decode(inp);
                var id = GetIdCalculator().Calculate(place.row, place.column);
                values.Add(id);
            }

            result = $"{SelectValue(values)}";
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

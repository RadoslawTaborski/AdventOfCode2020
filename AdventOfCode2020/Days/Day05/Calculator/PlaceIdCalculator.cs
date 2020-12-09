using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day05.Calculator
{
    public class PlaceIdCalculator : IPlaceIdCalculator
    {
        public int MultiplyRow { get; init; }

        public int Calculate(int row, int column)
        {
            return row * MultiplyRow + column;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class NeighborhoodChecker
    {
        public long Check(Cube input, CubeKey dims)
        {
            var result = 0;

            var keysToCheck = CubeAnalyzer.GenerateKeysToCheck(input, dims);

            foreach (var key in keysToCheck)
            {
                var value = input.GetValue(key);
                if (value == CellState.Active)
                {
                    result++;
                }
            }

            return result;
        }
    }
}

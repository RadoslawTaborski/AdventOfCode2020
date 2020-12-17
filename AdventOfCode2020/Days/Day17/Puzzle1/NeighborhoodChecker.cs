using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17.Puzzle1
{
    public class NeighborhoodChecker : INeighborhoodChecker
    {
        public int Check(ref ICube input, params long[] dim)
        {
            var result = 0;
            for(var i = -1; i <= 1; ++i)
            {
                for(var j=-1; j <= 1; ++j)
                {
                    for (var k = -1; k <= 1; ++k)
                    {
                        if (i == 0 && j == 0 && k==0)
                        {
                            continue;
                        }
                        var value = input.GetValue(dim[0] + i, dim[1] + j, dim[2] + k);
                        if (value == CellState.Active)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }
    }
}

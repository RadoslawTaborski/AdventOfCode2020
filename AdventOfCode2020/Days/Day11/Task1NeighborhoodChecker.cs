using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    public class Task1NeighborhoodChecker : INeighborhoodChecker
    {
        public int Check(ref Area input, int y, int x)
        {
            var result = 0;
            for(var i = -1; i <= 1; ++i)
            {
                for(var j=-1; j <= 1; ++j)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    var value = input.GetValue(y + i, x + j);
                    if ( value == Place.Occupied)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    public class AreaCreator
    {
        public static Area Create(List<List<char>> input)
        {
            var y = input.Count;
            var x = input[0].Count;
            var result = new Area(y, x);

            for(var i = 0; i<y; ++i)
            {
                for(var j = 0; j<x; ++j)
                {
                    switch (input[i][j])
                    {
                        case 'L':
                            result.SetPlace(i, j, Place.Free);
                            break;
                        case '#':
                            result.SetPlace(i, j, Place.Occupied);
                            break;
                        case '.':
                            result.SetPlace(i, j, Place.Floor);
                            break;
                        default:
                            throw new Exception($"Value {input[i][j]} is not supported.");
                    }

                }
            }

            return result;
        }
    }
}

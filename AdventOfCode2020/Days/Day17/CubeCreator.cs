using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class CubeCreator
    {
        public Cube Create(List<List<char>> input, int dim)
        {
            var y = -input.Count/2;
            var x = -input[0].Count/2;
            var result = new Cube(dim);

            for (var i = y; i < y + input.Count; ++i)
            {
                for (var j = x; j < x + input[0].Count; ++j)
                {
                    var dims = new List<long> { i, j };
                    for (var k = 0; k < dim - 2; ++k)
                    {
                        dims.Add(0);
                    }

                    switch (input[i-y][j-x])
                    {
                        case '.':
                            result.SetCell(CellState.Inactive, dims.ToArray());
                            break;
                        case '#':
                            result.SetCell(CellState.Active, dims.ToArray());
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

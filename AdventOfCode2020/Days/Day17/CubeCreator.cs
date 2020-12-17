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
            var y = input.Count;
            var x = input[0].Count;
            var result = new Cube(dim);

            for (var i = 0; i < y; ++i)
            {
                for (var j = 0; j < x; ++j)
                {
                    var dims = new List<long> { i, j };
                    for (var k = 0; k < dim - 2; ++k)
                    {
                        dims.Add(0);
                    }

                    switch (input[i][j])
                    {
                        case '.':
                            result.SetPlace(CellState.Inactive, dims.ToArray());
                            break;
                        case '#':
                            result.SetPlace(CellState.Active, dims.ToArray());
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

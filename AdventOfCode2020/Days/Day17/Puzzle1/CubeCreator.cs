using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17.Puzzle1
{
    public class CubeCreator : ICubeCreator
    {
        public ICube Create(List<List<char>> input)
        {
            var y = input.Count;
            var x = input[0].Count;
            var result = new Cube();

            for (var i = 0; i < y; ++i)
            {
                for (var j = 0; j < x; ++j)
                {
                    switch (input[i][j])
                    {
                        case '.':
                            result.SetPlace(CellState.Inactive, i, j, 0);
                            break;
                        case '#':
                            result.SetPlace(CellState.Active, i, j, 0);
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

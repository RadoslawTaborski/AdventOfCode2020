using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day24
{
    public abstract class Day24 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");

            var start = new Tile(new Coordinates(0, 0, 0));

            var grid = CreateGrid(input, start);
            grid = ModifyGrid(grid);
            result = $"{grid.Memory.Where(x => x.Value.TopColor == Color.Black).Count()}";
        }

        protected abstract HexGrid ModifyGrid(HexGrid grid);

        private HexGrid CreateGrid(List<string> input, Tile start)
        {
            var memory = new Dictionary<Coordinates, Tile> { [start.Coords] = start };

            foreach (var inp in input)
            {
                var steps = PrepareSteps(inp);
                Tile cell = start;
                for (int i = 0; i < steps.Count; i++)
                {
                    var step = steps[i];
                    Coordinates coordinates = Directions.Coordinates[step] + cell.Coords;
                    if (!memory.ContainsKey(coordinates))
                    {
                        memory.Add(coordinates, new Tile(coordinates));
                    }
                    var newCell = memory[coordinates];
                    cell.SetNeighbor(step, newCell);
                    cell = newCell;
                }
                cell.Flipe();
            }
            return new HexGrid(start, memory);
        }

        private List<string> PrepareSteps(string inp)
        {
            var result = new List<string>();
            for (int i = 0; i < inp.Length; i++)
            {
                char c = inp[i];
                if (c == 's' || c == 'n')
                {
                    result.Add(new StringBuilder().Append(c).Append(inp[i + 1]).ToString());
                    ++i;
                }
                else
                {
                    result.Add(c.ToString());
                }
            }
            return result;
        }
    }
}

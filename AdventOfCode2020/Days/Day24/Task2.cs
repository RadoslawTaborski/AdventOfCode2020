using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day24
{
    [Puzzle(24, 2)]
    public class Task2 : Day24
    {
        protected override HexGrid ModifyGrid(HexGrid grid)
        {
            return ModifyGrid(grid, 100);
        }

        private HexGrid ModifyGrid(HexGrid grid, int noOfIter)
        {
            var counter = 0;
            while (counter < noOfIter)
            {
                grid = FillGrid(grid);
                List<Tile> toChange = GetTilesToChange(grid);
                toChange.ForEach(x => x.Flipe());
                //Console.WriteLine(grid.Memory.Where(x => x.Value.TopColor == Color.Black).Count());
                counter++;
            }
            return grid;
        }

        private HexGrid FillGrid(HexGrid grid)
        {
            var blacks = grid.Memory.Where(x => x.Value.TopColor == Color.Black).ToList();
            foreach(var b in blacks)
            {
                if(b.Value.Neighbors.Count == 6)
                {
                    continue;
                }
                foreach(var dir in Directions.All)
                {
                    if (!b.Value.Neighbors.ContainsKey(dir))
                    {
                        var coords = b.Value.Coords + Directions.Coordinates[dir];

                        if (!grid.Memory.ContainsKey(coords))
                        {
                            grid.Memory.Add(coords, new Tile(coords));
                        }
                        var newTile = grid.Memory[coords];
                        foreach(var dir2 in Directions.All)
                        {
                            var coords2 = newTile.Coords + Directions.Coordinates[dir2];
                            if (grid.Memory.ContainsKey(coords2))
                            {
                                newTile.SetNeighbor(dir2, grid.Memory[coords2]);
                            }
                        }
                    }

                }
            }
            return grid;
        }

        private List<Tile> GetTilesToChange(HexGrid grid)
        {
            var result = new List<Tile>();
            foreach(var tile in grid.Memory.Values)
            {
                var counter = 0;
                foreach(var neighbor in tile.Neighbors.Values)
                {
                    if(neighbor.TopColor == Color.Black)
                    {
                        counter++;
                    }
                }
                if ((tile.TopColor == Color.Black && (counter == 0 || counter > 2)) || (tile.TopColor == Color.White && counter == 2))
                {
                    result.Add(tile);
                }
            }
            return result;
        }
    }
}

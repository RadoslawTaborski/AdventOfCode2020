using AdventOfCode2020.Puzzles;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public abstract class Day20 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");

            var tiles = TilesReader.Read(input);

            Dictionary<int, List<TileOrientation>> posibilities = GetAllPosibilities(tiles);

            var image = ImageCreator.Create(posibilities, tiles);

            result = Find(image);
        }

        protected abstract string Find(Image image);

        private Dictionary<int, List<TileOrientation>> GetAllPosibilities(Dictionary<int, Tile> tiles)
        {
            var posibilities = new Dictionary<int, List<TileOrientation>>();
            foreach (var tile in tiles)
            {
                var tmp = new List<TileOrientation>();
                foreach (var tile2 in tiles)
                {
                    if (tile.Key != tile2.Key)
                    {
                        tmp.AddRange(tile.Value.TileMatch(tile2.Value));
                    }
                }
                posibilities.Add(tile.Key, tmp);
            }

            return posibilities;
        }
    }
}

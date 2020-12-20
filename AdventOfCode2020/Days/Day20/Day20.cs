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
            base.Result(out result);

            var input = ReadRows("Input1.txt");

            var tiles = ReadTiles(input);

            var posibilities = new Dictionary<int, List<KeyValuePair<Directions, TileIdentifier>>>();
            foreach (var tile in tiles)
            {
                var tmp = new List<KeyValuePair<Directions, TileIdentifier>>();
                foreach (var tile2 in tiles)
                {
                    if (tile.Key != tile2.Key)
                    {
                        tmp.AddRange(tile.Value.TileMatch(tile2.Value));
                    }
                }
                posibilities.Add(tile.Key, tmp);
            }

            var corners = new List<long>();
            foreach(var inp in posibilities)
            {
                var set = new HashSet<Directions>();
                foreach(var inp2 in inp.Value)
                {
                    switch (inp2.Key)
                    {
                        case Directions.Up:
                            set.Add(Directions.Up);
                            break;
                        case Directions.Right:
                            set.Add(Directions.Right);
                            break;
                        case Directions.Down:
                            set.Add(Directions.Down);
                            break;
                        case Directions.Left:
                            set.Add(Directions.Left);
                            break;
                    }
                }
                if (set.Count == 2)
                {
                    corners.Add(inp.Key);
                }
            }

            result = $"{corners.Aggregate((a,b)=>a*b)}";
        }

        private Dictionary<int, Tile> ReadTiles(List<string> input)
        {
            var inp2 = input.Split("");

            var result = new Dictionary<int, Tile>();
            
            foreach(var inp in inp2)
            {
                var pixels = new List<List<char>>();
                var id = 0;
                foreach (var line in inp)
                {
                    if (line.StartsWith("Tile "))
                    {
                        var splitted = line.Replace(":", "").Split(" ");
                        id = int.Parse(splitted[1]);
                        continue;
                    }
                    pixels.Add(new List<char>(line));
                }
                var tile = new Tile (id, pixels);
                result.Add(id, tile);
            }

            return result;
        }
    }
}

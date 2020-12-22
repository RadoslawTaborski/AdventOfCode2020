using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class TilesReader
    {
        public static Dictionary<int, Tile> Read(List<string> input)
        {
            var inp2 = input.Split("");

            var result = new Dictionary<int, Tile>();

            foreach (var inp in inp2)
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
                var tile = new Tile(id, pixels);
                result.Add(id, tile);
            }

            return result;
        }
    }
}

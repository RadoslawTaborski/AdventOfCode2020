using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class TilesRow
    {
        public List<Tile> Columns { get; private set; } = new List<Tile>();

        public List<List<char>> GetWithoutBorder()
        {
            var list = new List<List<List<char>>>();
            foreach(var item in Columns)
            {
                list.Add(item.GetWithoutBorder());
            }

            var result = new List<List<char>>();
            for (var i = 0; i < list[0].Count; ++i)
            {
                var line = new List<char>();
                foreach (var tile in list)
                {
                    line.AddRange(tile[i]);
                }
                result.Add(line);
            }
            return result;
        }

        public void Add(Tile tile)
        {
            Columns.Add(tile);
        }

        public TilesRow Rotate()
        {
            Columns.Reverse();
            foreach (var item in Columns)
            {
                item.Rotate();
            }

            return this;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            for (var i = 0; i < Columns[0].Pixels.Count; ++i)
            {
                foreach (var tile in Columns)
                {
                    strBuilder.Append(new string(tile.Pixels[i].ToArray()));
                    strBuilder.Append(' ');
                }
                strBuilder.Append("\r\n");
            }

            return strBuilder.ToString();
        }
    }
}

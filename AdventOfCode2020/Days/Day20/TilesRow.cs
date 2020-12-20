using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class TilesRow
    {
        List<Tile> row = new List<Tile>();

        public void Add(Tile tile)
        {
            row.Add(tile);
        }

        public TilesRow Rotate()
        {
            row.Reverse();
            foreach(var item in row)
            {
                item.Rotate();
            }

            return this;
        }
    }
}

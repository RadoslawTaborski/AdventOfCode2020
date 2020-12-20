using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class Image
    {
        List<TilesRow> tiles = new List<TilesRow>();

        public void Add(TilesRow row)
        {
            tiles.Add(row);
        }
    }
}

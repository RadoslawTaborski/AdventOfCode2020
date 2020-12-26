using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day24
{
    public class HexGrid
    {
        public Dictionary<Coordinates, Tile> Memory { get; private set; }
        public Tile Start { get; private set; }

        public HexGrid(Tile start, Dictionary<Coordinates, Tile> memory)
        {
            Start = start;
            Memory = memory;
        }
    }
}

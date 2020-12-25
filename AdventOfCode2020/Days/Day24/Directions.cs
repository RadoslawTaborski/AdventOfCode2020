using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day24
{
    public static class Directions
    {
        public static string E { get { return "e"; } }
        public static string SE { get { return "se"; } }
        public static string SW { get { return "sw"; } }
        public static string W { get { return "w"; } }
        public static string NW { get { return "nw"; } }
        public static string NE { get { return "ne"; } }

        public static Dictionary<string, string> Oposition { get; } = new Dictionary<string, string>
        {
            [E] = W,
            [SE] = NW,
            [SW] = NE,
            [W] = E,
            [NW] = SE,
            [NE] = SW
        };

        public static Dictionary<string, Coordinates> Coordinates { get; } = new Dictionary<string, Coordinates>
        {
            [E] = new Coordinates(1,-1,0),
            [SE] = new Coordinates(1, 0, -1),
            [SW] = new Coordinates(0, 1, -1),
            [W] = new Coordinates(-1, 1, 0),
            [NW] = new Coordinates(-1, 0, 1),
            [NE] = new Coordinates(0, -1, 1)
        };

        public static string[] All { get; } = new[] { E, NE, NW, SE, SW, W };
    }
}

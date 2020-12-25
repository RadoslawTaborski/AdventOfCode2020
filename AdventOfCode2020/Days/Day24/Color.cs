using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day24
{
    public enum Color
    {
        White,
        Black
    }

    public static class ColorExt {
        public static Color GetOposite(this Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }
    }
}

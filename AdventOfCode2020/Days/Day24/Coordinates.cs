using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day24
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Coordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b)
        {
            return new Coordinates(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public override int GetHashCode()
        {
            return 31 * X + 32 * Y + 33 * Z + 17;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates cords && cords.Equals(this);
        }

        public override string ToString()
        {
            return $"X{X},{Y},{Z}";
        }

        public bool Equals(Coordinates other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
    }
}

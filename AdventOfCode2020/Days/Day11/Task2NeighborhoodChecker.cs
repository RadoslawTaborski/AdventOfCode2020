using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day11
{
    internal class Task2NeighborhoodChecker : INeighborhoodChecker
    {
        private readonly List<Vector> vectors = new List<Vector>
            {
                new Vector(-1,-1),
                new Vector(-1, 0),
                new Vector(-1, 1),
                new Vector(0,-1),
                new Vector(0, 1),
                new Vector(1, -1),
                new Vector(1, 0),
                new Vector(1, 1)
            };
        public int Check(ref Area input, int y, int x)
        {
            var result = 0;

            foreach(var vector in vectors)
            {
                var k = 1;
                while (true)
                {
                    var v = Vector.Multiply(vector, k);
                    var yNext = y + v.Y;
                    var xNext = x + v.X;

                    var value = input.GetValue(yNext, xNext);
                    if(value == null)
                    {
                        break;
                    }
                    if(value == Place.Occupied)
                    {
                        result++;
                        break;
                    } else if (value == Place.Free)
                    {
                        break;
                    }
                    k++;
                }
            }

            return result;
        }

        private class Vector
        {
            public int Y { get; }
            public int X { get; }

            public Vector(int y, int x)
            {
                this.Y = y;
                this.X = x;
            }

            public static Vector Multiply(Vector v, int k)
            {
                return new Vector(k*v.Y, k*v.X);
            }
        }
    }
}
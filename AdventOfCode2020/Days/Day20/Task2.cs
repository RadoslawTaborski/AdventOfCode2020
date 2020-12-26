using AdventOfCode2020.Helpers;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    [Puzzle(20, 2)]
    public class Task2 : Day20
    {
        private List<Point> frame = new List<Point>
        {
            new Point{Y= 0, X=18},
            new Point{Y= 1, X=0},
            new Point{Y= 1, X=5},
            new Point{Y= 1, X=6},
            new Point{Y= 1, X=11},
            new Point{Y= 1, X=12},
            new Point{Y= 1, X=17},
            new Point{Y= 1, X=18},
            new Point{Y= 1, X=19},
            new Point{Y= 2, X=1},
            new Point{Y= 2, X=4},
            new Point{Y= 2, X=7},
            new Point{Y= 2, X=10},
            new Point{Y= 2, X=13},
            new Point{Y= 2, X=16},

        };
        protected override string Find(Image image)
        {
            var data = image.GetImage();

            data = FindMonsers(data);
            data = ArrayModifier.Rotate(data);
            data = FindMonsers(data);
            data = ArrayModifier.Rotate(data);
            data = FindMonsers(data);
            data = ArrayModifier.Rotate(data);
            data = FindMonsers(data);
            data.Reverse();
            data = FindMonsers(data);
            data = ArrayModifier.Rotate(data);
            data = FindMonsers(data);
            data = ArrayModifier.Rotate(data);
            data = FindMonsers(data);
            data = ArrayModifier.Rotate(data);
            data = FindMonsers(data);

            return $"{CountHashes(data)}";
        }

        private int CountHashes(List<List<char>> data)
        {
            var counter = 0;
            for (var i = 0; i < data.Count; ++i)
            {
                for (var j = 0; j < data[i].Count; ++j)
                {
                    if (data[i][j] == '#')
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private List<List<char>> FindMonsers(List<List<char>> data)
        {
            for (var i = 0; i < data.Count - 3; ++i)
            {
                for (var j = 0; j < data[i].Count - 20; ++j)
                {
                    var isFound = true;
                    foreach (var point in frame)
                    {
                        if (data[i + point.Y][j + point.X] != '#')
                        {
                            isFound = false;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        foreach (var point in frame)
                        {
                            data[i + point.Y][j + point.X] = 'O';
                        }
                    }
                }
            }
            return data;
        }
    }

    internal class Point
    {
        public int X { get; init; }
        public int Y { get; init; }
    }
}

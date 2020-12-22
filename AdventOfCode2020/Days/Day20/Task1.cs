using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    [Puzzle(20)]
    public class Task1 : Day20
    {
        protected override string Find(Image image)
        {
            return $"{(long)image.Rows[0].Columns[0].Id * image.Rows[^1].Columns[0].Id * image.Rows[0].Columns[^1].Id * image.Rows[^1].Columns[^1].Id}";
        }
    }
}

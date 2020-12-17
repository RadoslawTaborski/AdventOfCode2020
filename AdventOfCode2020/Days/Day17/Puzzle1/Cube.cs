using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17.Puzzle1
{
    public partial class Cube : ICube
    {
        private SortedDictionary<long, SortedDictionary<long, SortedDictionary<long, CellState>>> cells;

        private List<Range> bounds = new List<Range>
        {
            new Range { Min = 0, Max = 0 },
            new Range { Min = 0, Max = 0 },
            new Range { Min = 0, Max = 0 }
        };

        public Cube()
        {
            cells = new SortedDictionary<long, SortedDictionary<long, SortedDictionary<long, CellState>>>();
        }

        public void SetPlace(CellState value, params long[] dims)
        {
            var y = dims[0];
            var x = dims[1];
            var z = dims[2];
            if (cells.ContainsKey(y))
            {
                if (cells[y].ContainsKey(x))
                {
                    UpdateRanges(y, x, z);
                    cells[y][x][z] = value;
                    return;
                }
                else
                {
                    cells[y][x] = new SortedDictionary<long, CellState>();
                }
            }
            else
            {
                cells[y] = new SortedDictionary<long, SortedDictionary<long, CellState>>();
            }
            SetPlace(value, y, x, z);
        }

        private void UpdateRanges(long y, long x, long z)
        {
            bounds[0] = UpdateRange(y, bounds[0]);
            bounds[1] = UpdateRange(x, bounds[1]);
            bounds[2] = UpdateRange(z, bounds[2]);
        }

        private Range UpdateRange(long input, Range range)
        {
            if (input < range.Min)
            {
                range.Min = input;
            }
            else if (input > range.Max)
            {
                range.Max = input;
            }

            return range;
        }

        public (long min, long max) GetRange(int dim)
        {
            return (bounds[dim].Min, bounds[dim].Max);
        }

        public CellState? GetValue(params long[] dims)
        {
            var y = dims[0];
            var x = dims[1];
            var z = dims[2];
            if (cells.ContainsKey(y))
            {
                if (cells[y].ContainsKey(x))
                {
                    if (cells[y][x].ContainsKey(z))
                    {
                        return cells[y][x][z];
                    }
                    else
                    {
                        return CellState.Inactive;
                    }
                }
                else
                {
                    return CellState.Inactive;
                }
            }
            else
            {
                return CellState.Inactive;
            }
        }

        public long GetNoOfActiveCube()
        {
            var result = 0;

            foreach (var dim1 in cells)
            {
                foreach (var dim2 in dim1.Value)
                {
                    foreach (var dim3 in dim2.Value)
                    {
                        if (dim3.Value == CellState.Active)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (var k = GetRange(2).min; k <= GetRange(2).max; ++k)
            {
                result.Append($"z = {k}\r\n");
                for (var j = GetRange(0).min; j <= GetRange(0).max; ++j)
                {
                    for (var i = GetRange(1).min; i <= GetRange(1).max; ++i)
                    {
                        result.Append((char)GetValue(i, j, k));
                    }
                    result.Append(Environment.NewLine);
                }
            }

            return result.ToString();
        }
    }
}

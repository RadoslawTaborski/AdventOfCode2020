using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class Cube
    {
        public int Dim { get; }
        public Dictionary<string, CellState> Cells { get; }
        public List<Range> Bounds { get; private set; }

        public Cube(int dim)
        {
            this.Dim = dim;
            this.Cells = new Dictionary<string, CellState>();
            this.Bounds = new List<Range>();
            for(var i = 0; i < dim; ++i)
            {
                Bounds.Add(new Range { Min = 0, Max = 0 });
            }
        }

        public (long min, long max) GetRange(int dim)
        {
            return (Bounds[dim].Min, Bounds[dim].Max);
        }

        public CellState? GetValue(CubeKey key)
        {
            var str = key.ToString();
            if (Cells.ContainsKey(key.ToString()))
            {
                return Cells[str];
            }

            return CellState.Inactive;
        }

        public void SetCell(CellState value, CubeKey dims)
        {
            Cells[dims.ToString()] = value;
            UpdateRanges(dims);
        }

        private void UpdateRanges(CubeKey key)
        {
            for(var i =0; i<Dim; ++i)
            {
                UpdateRange(key.Dims[i], Bounds[i]);
            }
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
    }

    public class CubeKey
    {
        public ImmutableList<long> Dims { get; private set; }

        public CubeKey(params long[] dims)
        {
            Dims = dims.ToImmutableList();
        }

        public CubeKey(string str)
        {
            Dims = str.Split(",").Select(x=>long.Parse(x)).ToImmutableList();
        }

        public override string ToString()
        {
            return string.Join(",", Dims);
        }
    }
}

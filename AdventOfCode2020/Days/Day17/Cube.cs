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
        public Dictionary<CubeKey, CellState> Cells { get; }

        private List<Range> bounds;

        public Cube(int dim)
        {
            this.Dim = dim;
            this.Cells = new Dictionary<CubeKey, CellState>();
            this.bounds = new List<Range>();
            for(var i = 0; i < dim; ++i)
            {
                bounds.Add(new Range { Min = 0, Max = 0 });
            }
        }

        public (long min, long max) GetRange(int dim)
        {
            return (bounds[dim].Min, bounds[dim].Max);
        }

        public CellState? GetValue(params long[] dims)
        {
            if (dims.Length != this.Dim)
            {
                throw new Exception("wrong number of input data");
            }

            CubeKey key = new CubeKey(dims);
            if (Cells.ContainsKey(key))
            {
                return Cells[key];
            }

            return CellState.Inactive;
        }

        public void SetCell(CellState value, params long[] dims)
        {
            if(dims.Length != this.Dim)
            {
                throw new Exception("wrong number of input data");
            }

            Cells[new CubeKey(dims)] = value;
            UpdateRanges(dims);
        }

        private void UpdateRanges(params long[] dims)
        {
            for(var i =0; i<Dim; ++i)
            {
                UpdateRange(dims[i], bounds[i]);
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

    public record CubeKey //TODO:
    {
        public ImmutableList<long> Dims { get; private set; }

        public CubeKey(params long[] dims)
        {
            Dims = dims.ToImmutableList();
        }
    }
}

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
        public List<Range> Bounds { get; private set; }

        public Cube(int dim)
        {
            this.Dim = dim;
            this.Cells = new Dictionary<CubeKey, CellState>();
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
            if (Cells.ContainsKey(key))
            {
                return Cells[key];
            }

            return CellState.Inactive;
        }

        public void SetCell(CellState value, CubeKey dims)
        {
            Cells[dims] = value;
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

    public class CubeKey : IEquatable<CubeKey>
    {
        public ImmutableList<long> Dims { get; private set; }

        public CubeKey(params long[] dims)
        {
            Dims = dims.ToImmutableList();
        }

        public override bool Equals(object obj)
        {
            return obj is CubeKey key && key.Equals(this);
        }

        public override int GetHashCode()
        {
            return (int)(Dims.Aggregate((a,b)=> 1*a+3*b)%int.MaxValue);
        }

        public bool Equals(CubeKey other)
        {
            if (Dims.SequenceEqual(other.Dims))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(", ", Dims);
        }
    }
}

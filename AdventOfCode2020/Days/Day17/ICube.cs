using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public interface ICube
    {
        long GetNoOfActiveCube();
        void SetPlace(CellState value, params long[] dims);
        CellState? GetValue(params long[] dims);
        (long min, long max) GetRange(int dim);
    }
}

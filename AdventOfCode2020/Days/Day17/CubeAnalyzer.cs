using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class CubeAnalyzer
    {
        public long GetNoOfActiveCube(Cube cube)
        {
            return cube.Cells.Where(x => x.Value == CellState.Active).Count();
        }
    }
}

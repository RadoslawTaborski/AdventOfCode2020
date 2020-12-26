using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public static class CubeAnalyzer
    {
        public static long GetNoOfActiveCube(Cube cube)
        {
            return cube.Cells.Where(x => x.Value == CellState.Active).Count();
        }

        public static List<CubeKey> GetActiveCells(Cube cube)
        {
            return cube.Cells.Where(x => x.Value == CellState.Active).Select(x=>new CubeKey(x.Key)).ToList();
        }

        public static List<CubeKey> GenerateKeysToCheck(Cube input, CubeKey dims)
        {
            var keysToCheck = new List<CubeKey>();
            Check(new List<long>(), ref keysToCheck, 0, dims);
            keysToCheck = keysToCheck.Where(x => !dims.Dims.SequenceEqual(x.Dims)).ToList();
            var result = new List<CubeKey>();
            foreach (var k in keysToCheck)
            {
                var flag = true;
                for (var i = 0; i < dims.Dims.Count; ++i)
                {
                    if (k.Dims[i] > input.Bounds[i].Max || k.Dims[i] < input.Bounds[i].Min)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result.Add(k);
                }
            }

            return result;
        }

        public static List<CubeKey> GetPossibilities(Cube input)
        {
            var result = new List<CubeKey>();
            foreach (var active in GetActiveCells(input))
            {
                var keysToCheck = new List<CubeKey>();
                Check(new List<long>(), ref keysToCheck, 0, active);
                result.AddRange(keysToCheck);
            }

            return result.Distinct().ToList();
        }

        private static void Check(List<long> input, ref List<CubeKey> output, int idx, CubeKey dims)
        {
            if (idx == dims.Dims.Count)
            {
                output.Add(new CubeKey(input.ToArray()));
                return;
            }
            for (var i = -1; i <= 1; ++i)
            {
                var copy = new List<long>(input)
                {
                    dims.Dims[idx] + i
                };
                Check(copy, ref output, idx + 1, dims);
            }
        }
    }
}

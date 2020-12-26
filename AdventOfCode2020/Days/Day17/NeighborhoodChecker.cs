using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class NeighborhoodChecker
    {
        public long Check(Cube input, params long[] dims)
        {
            var result = 0;
            if (dims.Length != input.Dim)
            {
                throw new Exception("wrong number of input data");
            }

            var keysToCheck = GenerateKeysToCheck(input, dims);

            foreach (var key in keysToCheck)
            {
                var value = input.GetValue(key);
                if (value == CellState.Active)
                {
                    result++;
                }
            }

            return result;
        }

        private List<CubeKey> GenerateKeysToCheck(Cube input, long[] dims)
        {
            var keysToCheck = new List<List<long>>();
            Check(new List<long>(), ref keysToCheck, 0, dims);
            keysToCheck = keysToCheck.Where(x => !AreTheSame(x, dims)).ToList();
            var keys = keysToCheck.Select(x=>new CubeKey(x.ToArray())).ToList();
            var result = new List<CubeKey>();
            foreach (var k in keys) {
                var flag = true;
                for (var i = 0; i < dims.Length; ++i)
                {
                    if(k.Dims[i]>input.Bounds[i].Max || k.Dims[i] < input.Bounds[i].Min)
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

        private bool AreTheSame(List<long> x, long[] dims)
        {
            for(var i =0; i< x.Count; ++i)
            {
                if(x[i]!= dims[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void Check(List<long> input, ref List<List<long>> output, int idx, params long[] dims)
        {
            if(idx == dims.Length)
            {
                output.Add(input);
                return;
            }
            for (var i = -1; i <= 1; ++i)
            {
                var copy = new List<long>(input)
                {
                    dims[idx] + i
                };
                Check(copy, ref output, idx + 1, dims);
            }
        }
    }
}

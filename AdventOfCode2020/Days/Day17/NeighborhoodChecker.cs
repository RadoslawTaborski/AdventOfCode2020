﻿using System;
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

            var keysToCheck = new List<List<long>>();
            Check(new List<long>(), ref keysToCheck, 0, dims);
            keysToCheck = keysToCheck.Where(x => !AreTheSame(x, dims)).ToList();

            foreach(var key in keysToCheck)
            {
                var value = input.GetValue(key.ToArray());
                if (value == CellState.Active)
                {
                    result++;
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
                var copy = new List<long>(input);
                copy.Add(dims[idx] + i);
                Check(copy, ref output, idx + 1, dims);
            }
        }
    }
}

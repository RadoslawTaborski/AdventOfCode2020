using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day01
{
    public class ValuesMultiplicator
    {
        public static string GetMathOperation(List<long> values)
        {
            var result = "";
            foreach (var item in values.Take(values.Count - 1))
            {
                result += $"{item} * ";
            }

            result += $"{values.ElementAt(values.Count - 1)} = {values.Aggregate((x, y) => x * y)}";

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day1
{
    internal class ValuesFinder
    {
        public static List<int> Find(List<int> input, int maxDeep, int sumValue)
        {
            var output = new List<List<int>>();
            Find(input, new List<ValueObj>(), maxDeep, sumValue, ref output);

            if(output.Count == 0)
            {
                throw new Exception("values not found");
            }

            return output.ElementAt(0);
        }

        private static void Find(List<int> input, List<ValueObj> values, int maxDeep, int sumValue, ref List<List<int>> output)
        { 
            if(values.Count >= maxDeep)
            {
                if(values.Select(x=>x.Value).Sum() == sumValue)
                {
                     output.Add(values.Select(x=>x.Value).ToList());
                } else
                {
                    return;
                }
            }

            var init = values.Count > 0 ? values.Last().Id : 0;

            for (var i = init; i < input.Count; ++i)
            {
                if (!values.Any(x => x.Id == i))
                {
                    if(values.Select(x => x.Value).Sum() > sumValue)
                    {
                        return;
                    }
                    var clone = new List<ValueObj>(values)
                    {
                        new ValueObj { Id = i, Value = input[i] }
                    };
                    Find(input, clone, maxDeep, sumValue, ref output);
                } else
                {
                    continue;
                }
            }
        }
    }

    internal record ValueObj
    {
        public int Id { get; init; }
        public int Value { get; init; }
    }
}

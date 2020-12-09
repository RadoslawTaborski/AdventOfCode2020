using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Helpers
{
    public class SumFinder
    {
        public static List<long> Find(List<long> input, int maxDeep, long sumValue)
        {
            var output = new List<List<long>>();
            Find(input, new List<ValueObj>(), maxDeep, sumValue, ref output);

            if (output.Count == 0)
            {
                return new List<long>();
            }

            return output.ElementAt(0);
        }

        private static void Find(List<long> input, List<ValueObj> values, int maxDeep, long sumValue, ref List<List<long>> output)
        {
            if (values.Count >= maxDeep)
            {
                if (values.Select(x => x.Value).Sum() == sumValue)
                {
                    output.Add(values.Select(x => x.Value).ToList());
                }
                else
                {
                    return;
                }
            }

            var init = values.Count > 0 ? values.Last().Id : 0;

            for (var i = init; i < input.Count; ++i)
            {
                if (!values.Any(x => x.Id == i))
                {
                    if (values.Select(x => x.Value).Sum() > sumValue)
                    {
                        return;
                    }
                    var clone = new List<ValueObj>(values)
                    {
                        new ValueObj { Id = i, Value = input[i] }
                    };
                    Find(input, clone, maxDeep, sumValue, ref output);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    internal record ValueObj
    {
        public int Id { get; init; }
        public long Value { get; init; }
    }
}

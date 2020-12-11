using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day10
{
    [Puzzle(10, 2)]
    public class Task2 : Day10
    {
        private readonly Dictionary<int, Node> cache = new Dictionary<int, Node>();

        protected override string FindValue(List<int> input)
        {
            var maxDifference = 3;

            input.Add(0);
            input.Add(input.Max() + 3);

            input.Sort();

            var root = new Node(0, input[0]);

            GetPermutations(ref input, maxDifference, ref root);

            var result = root.GetNumberOfWays();

            return $"{result}";
        }

        private void GetPermutations(ref List<int> input, int maxDifference, ref Node node)
        {
            var idx = node.Id + 1;
            var tmp = input[idx];
            while (tmp - node.Value <= maxDifference && idx < input.Count - 1)
            {
                if (!cache.ContainsKey(tmp))
                {
                    var newNode = new Node(idx, tmp);
                    GetPermutations(ref input, maxDifference, ref newNode);
                    cache.Add(tmp, newNode);
                } 
                node.Add(cache[tmp]);
                idx++;
                tmp = input[idx];
            }
        }
    }
}

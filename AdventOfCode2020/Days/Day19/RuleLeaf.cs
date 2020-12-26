using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day19
{
    public class RuleLeaf : IRule
    {
        public int Id { get; init; }
        public List<char> Value { get; init; }

        public string GenerateRegex(Dictionary<int, IRule> dictionary)
        {
            return $"{string.Join("|", Value)}";
        }
    }
}

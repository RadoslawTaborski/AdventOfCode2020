using AdventOfCode2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day19
{
    public class Rule : IRule
    {
        public int Id { get; init; }
        public List<List<int>> Patterns { get; init; }

        public string GenerateRegex(Dictionary<int, IRule> dictionary)
        {
            var list = new List<string>();

            foreach (var pattern in Patterns)
            {
                list.Add(CreateFromCollection(pattern, dictionary));
            }

            return new StringBuilder().Append('(').Append(string.Join("|", list)).Append(')').ToString();
        }

        private string CreateFromCollection(List<int> pattern, Dictionary<int, IRule> dictionary)
        {
            var strBuilder = new StringBuilder();

            foreach (var a in pattern)
            {
                strBuilder.Append(dictionary[a].GenerateRegex(dictionary));
            }

            return strBuilder.ToString();
        }

        public Rule Add(List<int> add)
        {
            Patterns.Add(add);
            return this;
        }
    }
}

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
        private int counter = 0;
        private Dictionary<string[], List<string>> history = new Dictionary<string[], List<string>>(new StringArrayEqualityComparer());
        public int Id { get; init; }
        public List<List<int>> Patterns { get; init; }

        public string GenerateRegex(Dictionary<int, IRule> dictionary)
        {
            var list = new List<string>();
            var shouldBeLoop = Patterns.Any(x => x.Contains(Id));
            if (shouldBeLoop)
            {
                list.Add(CreateFromCollectionWithLoop(Patterns[0], dictionary));
            }
            else
            {
                foreach (var pattern in Patterns)
                {
                    list.Add(CreateFromCollection(pattern, dictionary));
                }
            }

            return new StringBuilder().Append("(").Append(string.Join("|", list)).Append(")").ToString();
        }

        private string CreateFromCollectionWithLoop(List<int> pattern, Dictionary<int, IRule> dictionary)
        {
            var strBuilder = new StringBuilder();

            if (pattern.Count == 1)
            {
                strBuilder.Append("(").Append(dictionary[pattern[0]].GenerateRegex(dictionary)).Append(")+");
            } else
            {
                var r1 = dictionary[pattern[0]].GenerateRegex(dictionary);
                var r2 = dictionary[pattern[1]].GenerateRegex(dictionary);
                strBuilder.Append("(").Append(Loop(r1,r2,0,100)).Append(")");
            }

            return strBuilder.ToString();
        }

        private string Loop(string r1, string r2, int v1, int v2)
        {
            if (v1 == v2)
            {
                return "";
            }

            var strBuilder = new StringBuilder();
            var innerLoop = Loop(r1, r2, v1 + 1, v2);
            if (innerLoop != "")
            {
                strBuilder.Append("(").Append(r1).Append(")((").Append(innerLoop).Append(")*)(").Append(r2).Append(")");
            }
            else
            {
                strBuilder.Append("(").Append(r1).Append(")(").Append(r2).Append(")");
            }

            return strBuilder.ToString();
        }

        private string CreateFromCollection(List<int> pattern, Dictionary<int, IRule> dictionary)
        {
            var strBuilder = new StringBuilder();

            strBuilder.Append('(');
            foreach (var a in pattern)
            {
                strBuilder.Append('(').Append(dictionary[a].GenerateRegex(dictionary)).Append(')');
            }
            strBuilder.Append(')');

            return strBuilder.ToString();
        }

        public Rule Add(List<int> add)
        {
            Patterns.Add(add);
            return this;
        }
    }
}

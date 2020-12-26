using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day19
{
    public abstract class Day19 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");

            var (rules, messages) = GetParts(input);
            var origin = GetOrigins(rules);

            origin = ModifiedRules(origin);

            var tmp = origin[0].GenerateRegex(origin);

            Regex rgx = new Regex($"^{tmp}$");
            var counter = 0;
            foreach (string message in messages)
            {
                if (rgx.IsMatch(message))
                {
                    counter++;
                }
            }

            result = $"{counter}";
        }

        protected abstract Dictionary<int, IRule> ModifiedRules(Dictionary<int, IRule> processedRule);

        private Dictionary<int, IRule> GetOrigins(List<string> rules)
        {
            var result = new Dictionary<int, IRule>();

            foreach (var r in rules)
            {
                var splitted = r.Split(":");
                var id = int.Parse(splitted[0]);

                if (splitted[1].Contains("\""))
                {
                    var splitted2 = splitted[1].Split("|");

                    var rulePart = new List<char>();
                    foreach (var s in splitted2)
                    {
                        var p = s.Replace("\"", "");
                        p = p.Replace(" ", "");
                        rulePart.Add(p[0]);
                    }

                    result.Add(id, new RuleLeaf { Id = id, Value = rulePart });
                } else {
                    var splitted2 = splitted[1].Split("|");

                    var rulePart = new List<List<int>>();
                    foreach (var s in splitted2)
                    {
                        var p = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        rulePart.Add(p.Select(x => int.Parse(x)).ToList());
                    }

                    result.Add(id, new Rule { Id = id, Patterns = rulePart });
                }
            }

            return result;
        }

        private (List<string> rules, List<string> messages) GetParts(List<string> input)
        {
            var result1 = new List<string>();
            var result2 = new List<string>();
            bool firstPartCompleted = false;
            foreach (var inp in input)
            {
                if(inp == "")
                {
                    firstPartCompleted = true;
                    continue;
                }

                if (firstPartCompleted)
                {
                    result2.Add(inp);
                } else
                {
                    result1.Add(inp);
                }
            }

            return (result1, result2);
        }
    }
}

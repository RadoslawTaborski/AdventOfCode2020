using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day19
{
    [Puzzle(19, 2)]
    public class Task2 : Day19
    {
        protected override Dictionary<int, IRule> ModifiedRules(Dictionary<int, IRule> processedRule)
        {
            processedRule[8] = (processedRule[8] as Rule).Add(new List<int> { 42, 8 });
            processedRule[11] = (processedRule[11] as Rule).Add(new List<int> { 42, 11, 31 });

            return processedRule;
        }
    }
}

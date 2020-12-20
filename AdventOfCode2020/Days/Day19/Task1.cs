using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day19
{
    [Puzzle(19)]
    public class Task1 : Day19
    {
        protected override Dictionary<int, IRule> ModifiedRules(Dictionary<int, IRule> processedRule)
        {
            return processedRule;
        }
    }
}

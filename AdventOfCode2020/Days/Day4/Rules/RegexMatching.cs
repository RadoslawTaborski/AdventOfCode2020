using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4.Rules
{
    public class RegexMatching : IRule
    {
        public string Pattern { get; init; }
        public bool IsValid(string value)
        {
            Regex regex = new Regex(Pattern);

            Match match = regex.Match(value);

            return match.Success;
        }
    }
}

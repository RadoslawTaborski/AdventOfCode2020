using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day2.Rules
{
    internal class Rule1 : IRule
    {
        public int Min { get; init; }
        public int Max { get; init; }
        public string Value { get; init; }
        public bool IsValid(string password)
        {
            int count = Regex.Matches(password, Value).Count;

            if(count<Min || count > Max)
            {
                return false;
            }

            return true;
        }
    }
}

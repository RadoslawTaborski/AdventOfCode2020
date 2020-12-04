using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4.Rules
{
    public class OneOf : IRule
    {
        public List<string> AllowedValues { get; init; }
        public bool IsValid(string value)
        {
            if (AllowedValues.Contains(value))
            {
                return true;
            }

            return false;
        }
    }
}

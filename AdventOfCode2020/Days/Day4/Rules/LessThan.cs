using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4.Rules
{
    public class LessThan : IRule
    {
        public int MaxValue { get; init; }
        public bool IsValid(string value)
        {
            if (int.TryParse(value, out var number))
            {
                if (number <= MaxValue)
                {
                    return true;
                }
            }

            return false;

        }
    }
}

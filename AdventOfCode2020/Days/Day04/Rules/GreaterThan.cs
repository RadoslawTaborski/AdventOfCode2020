using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day04.Rules
{
    public class GreaterThan : IRule
    {
        public int MinValue { get; init; }
        public bool IsValid(string value)
        {
            if(int.TryParse(value, out var number))
            {
                if(number >= MinValue)
                {
                    return true;
                }
            }

            return false;

        }
    }
}

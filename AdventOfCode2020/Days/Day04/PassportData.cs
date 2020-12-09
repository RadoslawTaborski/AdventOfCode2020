using AdventOfCode2020.Days.Day04.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day04
{
    public class PassportData
    {
        public string Name { get; init; }
        public List<IRule> Rules { get; init; } = new List<IRule>();
    }
}

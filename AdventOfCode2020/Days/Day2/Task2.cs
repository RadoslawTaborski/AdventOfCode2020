using AdventOfCode2020.Days.Day2.Rules;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day2
{
    [Task(2, 2)]
    public class Task2 : Day2
    {
        protected override List<IRule> CreateRules((int v1, int v2, string v3, string v4) data)
        {
            var result = new List<IRule>
            {
                new Rule2
                {
                    Idx1 = data.v1,
                    Idx2 = data.v2,
                    Value = data.v3
                }
            };

            return result;
        }
    }
}

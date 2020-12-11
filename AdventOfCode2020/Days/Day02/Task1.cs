using AdventOfCode2020.Days.Day02.Rules;
using AdventOfCode2020.Tasks;
using System.Collections.Generic;
using System.Linq;
using Task = AdventOfCode2020.Tasks.Puzzle;

namespace AdventOfCode2020.Days.Day02
{
    [Puzzle(2)]
    public class Task1 : Day02
    {
        protected override List<IRule> CreateRules((int v1, int v2, string v3, string v4) data)
        {
            var result = new List<IRule>
            {
                new Rule1
                {
                    Min = data.v1,
                    Max = data.v2,
                    Value = data.v3
                }
            };

            return result;
        }
    }
}

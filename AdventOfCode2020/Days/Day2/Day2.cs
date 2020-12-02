using AdventOfCode2020.Days.Day2.Rules;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day2
{
    public abstract class Day2 : Task
    {
        protected override void Result(out string result)
        {
            var input = ReadRows($"Input1.txt");

            var counter = 0;

            foreach (var row in input)
            {
                var data = DataParser.ExtractDataFromRow(row);

                var rules = CreateRules(data);

                var passwordPolicy = new PasswordPolicy().SetRules(rules);

                if (passwordPolicy.PasswordIsCorrect(data.v4))
                {
                    counter++;
                }

            }

            result = $"{counter}";
        }

        protected abstract List<IRule> CreateRules((int v1, int v2, string v3, string v4) data);
    }
}

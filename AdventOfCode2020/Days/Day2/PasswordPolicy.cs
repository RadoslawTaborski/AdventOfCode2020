using AdventOfCode2020.Days.Day2.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day2
{
    class PasswordPolicy
    {
        private List<IRule> rules = new List<IRule>();

        public PasswordPolicy SetRules(List<IRule> rules)
        {
            this.rules = rules;
            return this;
        }

        public bool PasswordIsCorrect(string password)
        {
            var result = true;

            foreach(var rule in rules)
            {
                result &= rule.IsValid(password);
            }

            return result;
        }
    }
}

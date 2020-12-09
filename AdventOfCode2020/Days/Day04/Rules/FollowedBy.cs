using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day04.Rules
{
    public class FollowedBy : IRule
    {
        public bool StartWith {get; init;}
        public Dictionary<string, List<IRule>> KeysWithRules { get; init; }

        public bool IsValid(string value)
        {
            var oneOfPossibleValue = false;
            foreach(var val in KeysWithRules)
            {
                if (value.StartsWith(val.Key))
                {
                    oneOfPossibleValue = true;
                    var secondPart = value.Substring(val.Key.Length);
                    foreach (var rule in val.Value)
                    {
                        if (!rule.IsValid(secondPart))
                        {
                            return false;
                        }
                    }
                } 
                else if (value.EndsWith(val.Key))
                {
                    oneOfPossibleValue = true;
                    var secondPart = value.Substring(0, value.Length-val.Key.Length);
                    foreach (var rule in val.Value)
                    {
                        if (!rule.IsValid(secondPart))
                        {
                            return false;
                        }
                    }
                }
            }

            return oneOfPossibleValue;
        }
    }
}

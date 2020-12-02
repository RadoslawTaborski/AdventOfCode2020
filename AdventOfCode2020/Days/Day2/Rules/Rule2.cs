using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day2.Rules
{
    class Rule2 : IRule
    {
        public int Idx1 { get; init; }
        public int Idx2 { get; init; }
        public string Value { get; init; }

        public bool IsValid(string password)
        {
            if(Idx1 - 1 >= 0 || Idx1 - 1 < password.Length)
            {
                if (Idx2 - 1 >= 0 || Idx2 - 1 < password.Length)
                {
                    if (password[Idx1 - 1] == char.Parse(Value) ^ password[Idx2 - 1] == char.Parse(Value))
                    {
                        return true;
                    }
                } else
                {
                    if (password[Idx1 - 1] == char.Parse(Value))
                    {
                        return true;
                    }
                }
            } else
            {
                if (Idx2 - 1 >= 0 || Idx2 - 1 < password.Length)
                {
                    if (password[Idx2 - 1] == char.Parse(Value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

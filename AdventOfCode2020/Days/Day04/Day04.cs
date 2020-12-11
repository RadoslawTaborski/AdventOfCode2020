using AdventOfCode2020.Days.Day04.Scanners;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day04
{
    public abstract class Day04 : Puzzle
    {
        protected PassportReader reader = new PassportReader();

        protected abstract IPassportScanner PrepareScanner();

        protected override void Result(out string result)
        {
            result = $"{Run(PrepareScanner())}";
        }

        protected int Run(IPassportScanner scaner)
        {
            var input = ReadRows($"Input1.txt");

            var parts = ReadParts(input);
            var passports = new List<Passport>();

            foreach(var part in parts)
            {
                passports.Add(reader.Read(part));
            }

            var counter = 0;
            foreach(var passport in passports)
            {
                if (scaner.IsValid(passport))
                {
                    counter++;
                }
            }

            return counter++;
        }
    }
}

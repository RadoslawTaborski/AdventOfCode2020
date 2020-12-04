using AdventOfCode2020.Days.Day4.Scanners;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day4
{
    public abstract class Day4 : Task
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

        private List<List<string>> ReadParts(List<string> input)
        {
            var result = new List<List<string>>();

            var tmp = new List<string>();
            foreach(var inputData in input)
            {
                if(!string.IsNullOrEmpty(inputData))
                {
                    tmp.Add(inputData);
                } else
                {
                    result.Add(tmp);
                    tmp = new List<string>();
                }
            }

            if (tmp.Count > 0)
            {
                result.Add(tmp);
            }

            return result;
        }
    }
}

using AdventOfCode2020.Days.Day04.Scanners;
using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day04
{
    [Puzzle(4)]
    public class Task1 : Day04
    {
        protected override IPassportScanner PrepareScanner()
        {
            return new PassportScanner
            {
                MandatoryFields = new List<PassportData>
                {
                    new PassportData
                    {
                        Name = "byr",
                    },
                   new PassportData
                    {
                        Name = "iyr",
                    },
                    new PassportData
                    {
                        Name = "eyr",
                    },
                    new PassportData
                    {
                        Name = "hgt",
                    },
                     new PassportData
                    {
                        Name = "hcl",
                    },
                    new PassportData
                    {
                        Name = "ecl",
                    },
                    new PassportData
                    {
                        Name = "pid",
                    }
                },
                OptionalFields = new List<PassportData>
                {
                    new PassportData
                    {
                        Name = "cid",
                    },
                }
            };
        }
    }
}

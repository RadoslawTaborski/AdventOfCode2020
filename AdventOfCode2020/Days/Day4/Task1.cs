using AdventOfCode2020.Days.Day4.Scanners;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4
{
    [Task(4)]
    public class Task1 : Day4
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

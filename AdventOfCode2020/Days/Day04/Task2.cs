using AdventOfCode2020.Days.Day04.Rules;
using AdventOfCode2020.Days.Day04.Scanners;
using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day04
{
    [Task(4, 2)]
    public class Task2 : Day04
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
                        Rules = new List<IRule>
                        {
                            new GreaterThan
                            {
                                MinValue = 1920
                            },
                            new LessThan
                            {
                                MaxValue = 2002
                            }
                        }
                    },
                   new PassportData
                    {
                        Name = "iyr",
                        Rules = new List<IRule>
                        {
                            new GreaterThan
                            {
                                MinValue = 2010
                            },
                            new LessThan
                            {
                                MaxValue = 2020
                            }
                        }
                    },
                    new PassportData
                    {
                        Name = "eyr",
                        Rules = new List<IRule>
                        {
                            new GreaterThan
                            {
                                MinValue = 2020
                            },
                            new LessThan
                            {
                                MaxValue = 2030
                            }
                        }
                    },
                    new PassportData
                    {
                        Name = "hgt",
                        Rules = new List<IRule>
                        {
                            new FollowedBy
                            {
                                KeysWithRules = new Dictionary<string, List<IRule>>
                                {
                                    ["cm"] = new List<IRule>
                                    {
                                        new GreaterThan {
                                            MinValue = 150
                                        },
                                        new LessThan
                                        {
                                            MaxValue = 193
                                        }
                                    },
                                    ["in"] = new List<IRule>
                                    {
                                        new GreaterThan {
                                            MinValue = 59
                                        },
                                        new LessThan
                                        {
                                            MaxValue = 76
                                        }
                                    },
                                }
                            }
                        }
                    },
                     new PassportData
                    {
                        Name = "hcl",
                        Rules = new List<IRule>
                        {
                            new FollowedBy
                            {
                                StartWith = true,
                                KeysWithRules = new Dictionary<string, List<IRule>>
                                {
                                    ["#"] = new List<IRule>
                                    {
                                        new RegexMatching
                                        {
                                            Pattern = "^[0-9a-f]{6}$"
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new PassportData
                    {
                        Name = "ecl",
                        Rules = new List<IRule>
                        {
                            new OneOf
                            {
                                AllowedValues = new List<string>
                                {
                                    "amb","blu","brn","gry","grn","hzl","oth"
                                }
                            }
                        }
                    },
                    new PassportData
                    {
                        Name = "pid",
                        Rules = new List<IRule>
                        {
                            new RegexMatching
                            {
                                Pattern = "^[0-9]{9}$"
                            }
                        }
                    }
                },
                OptionalFields = new List<PassportData>
                {
                    new PassportData
                    {
                        Name = "cid",
                        Rules = new List<IRule>()
                    },
                }
            };
        }
    }
}

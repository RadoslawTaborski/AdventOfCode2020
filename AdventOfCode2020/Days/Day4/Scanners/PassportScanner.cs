using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4.Scanners
{
    public class PassportScanner : IPassportScanner
    {
        public List<PassportData> MandatoryFields { get; init; }
        public List<PassportData> OptionalFields { get; init; }

        public bool IsValid(Passport passport)
        {
            foreach (var field in MandatoryFields)
            {
                if (!passport.Data.ContainsKey(field.Name))
                {
                    return false;
                } else
                {
                    foreach(var rule in field.Rules)
                    {
                        if (!rule.IsValid(passport.Data[field.Name]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4.Scanners
{
    public interface IPassportScanner
    {
        public bool IsValid(Passport passport);
    }
}

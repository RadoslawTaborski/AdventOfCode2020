﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day02.Rules
{
    public interface IRule
    {
        bool IsValid(string password);
    }
}

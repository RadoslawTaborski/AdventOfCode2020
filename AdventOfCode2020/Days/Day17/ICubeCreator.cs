﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public interface ICubeCreator
    {
        ICube Create(List<List<char>> input);
    }
}

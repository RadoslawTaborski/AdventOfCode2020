using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Tasks
{
    public interface IPuzzle
    {
        int Day { get; }
        int Number { get; }
        string Result();
    }
}

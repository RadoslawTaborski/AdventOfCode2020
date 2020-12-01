using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Tasks
{
    public interface ITask
    {
        int Day { get; }
        int Number { get; }
        string Result();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Puzzles
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class PuzzleAttribute : Attribute
    {
        public PuzzleAttribute(int day, int numberOfTask = 1)
        {
            Day = day;
            NumberOfTask = numberOfTask;
        }

        public int Day { get; init; }
        public int NumberOfTask { get; init; }
    }
}

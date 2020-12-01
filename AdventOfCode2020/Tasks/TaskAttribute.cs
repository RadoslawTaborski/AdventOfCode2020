using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Tasks
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class TaskAttribute : Attribute
    {
        public TaskAttribute(int day, int numberOfTask = 1)
        {
            Day = day;
            NumberOfTask = numberOfTask;
        }

        public int Day { get; init; }
        public int NumberOfTask { get; init; }
    }
}

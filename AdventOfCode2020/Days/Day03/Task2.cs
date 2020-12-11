using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day03
{
    [Puzzle(3,2)]
    public class Task2: Day03
    {
        protected override void Result(out string result)
        {
            int counted1 = StartTravel(0, 0, 1, 1, 0, 0, '#');
            int counted2 = StartTravel(0, 0, 3, 1, 0, 0, '#');
            int counted3 = StartTravel(0, 0, 5, 1, 0, 0, '#');
            int counted4 = StartTravel(0, 0, 7, 1, 0, 0, '#');
            int counted5 = StartTravel(0, 0, 1, 2, 0, 0, '#');

            result = $"{counted1} * {counted2} * {counted3} * {counted4} * {counted5} = {counted1* counted2* counted3* counted4* counted5}";
        }
    }
}

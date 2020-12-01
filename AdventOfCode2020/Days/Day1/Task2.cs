using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day1
{
    [Task(1, 2)]
    public class Task2 : Task
    {
        protected override void Result(out string result)
        {
            var input = ReadRows($"Task1.txt").Select(x => int.Parse(x)).ToList();

            for (var i = 0; i < input.Count; ++i)
            {
                for (var j = 0; j < input.Count; ++j)
                {
                    if (i != j)
                    {
                        for (var k = 0; k < input.Count; ++k)
                        {
                            if (i != k && j != k)
                            {
                                if (input[i] + input[j] + input[k] == 2020)
                                {
                                    result = $"{input[i]} * {input[j]} * {input[k]} = {input[i] * input[j] * input[k]}";
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            result = "not found";
        }
    }
}

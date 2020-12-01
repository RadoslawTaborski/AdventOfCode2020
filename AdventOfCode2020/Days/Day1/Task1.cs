using AdventOfCode2020.Tasks;
using System.Linq;
using Task = AdventOfCode2020.Tasks.Task;

namespace AdventOfCode2020.Days.Day1
{
    [Task(1)]
    public class Task1 : Task
    {
        protected override void Result(out string result)
        {
            var input = ReadRows($"Task1.txt").Select(x=>int.Parse(x)).ToList();

            for(var i = 0; i<input.Count; ++i)
            {
                for(var j = 0; j<input.Count; ++j)
                {
                    if (i != j)
                    {
                        if(input[i] + input[j] == 2020)
                        {
                            result = $"{input[i]} * {input[j]} = {input[i] * input[j]}";
                            return;
                        }
                    }
                }
            }

            result = "not found";
        }
    }
}

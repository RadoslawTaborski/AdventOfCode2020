using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Tasks
{
    public class TasksProcessor
    {
        public void Run(IEnumerable<ITask> tasks)
        {
            foreach(var task in tasks){
                Console.WriteLine($"Day: {task.Day} Task: {task.Number}");
                Console.WriteLine(task.Result());
                Console.WriteLine("********************************************");
            }
        }
    }
}

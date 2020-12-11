using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzles
{
    public class PuzzlesProcessor
    {
        public void Run(IEnumerable<IPuzzle> tasks)
        {
            foreach(var task in tasks){
                Console.WriteLine($"Day: {task.Day} Task: {task.Number}");
                Console.WriteLine(task.Result());
                Console.WriteLine("********************************************");
            }
        }
    }
}

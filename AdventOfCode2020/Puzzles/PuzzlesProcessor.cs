using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzles
{
    public class PuzzlesProcessor
    {
        public void Run(IEnumerable<IPuzzle> tasks)
        {
            Console.WriteLine($"--------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"Day",9}|{"Part",10}|{"Time [ms]",12}|{"Solution",50}|");
            Console.WriteLine($"--------------------------------------------------------------------------------------");
            var previousDay = tasks.ElementAt(0).Day;
            foreach (var task in tasks)
            {
                if (previousDay != task.Day)
                {
                    Console.WriteLine($"--------------------------------------------------------------------------------------");
                }
                PrintRow(task);
                previousDay = task.Day;
            }
            Console.WriteLine($"--------------------------------------------------------------------------------------");
        }

        private static void PrintRow(IPuzzle task)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = task.Result();
            sw.Stop();
            Console.WriteLine($"|{"Day "+task.Day,9}|{"Part "+task.Number,10}|{sw.ElapsedMilliseconds + " ms", 12}|{result,50}|");
        }
    }
}

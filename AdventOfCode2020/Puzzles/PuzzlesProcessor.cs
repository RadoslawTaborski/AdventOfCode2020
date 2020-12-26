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
            PrintBoard();
            PrintRow("", "", "Time", "Solution");
            PrintBoard();
            var previousDay = tasks.ElementAt(0).Day;
            foreach (var task in tasks)
            {
                if (previousDay != task.Day)
                {
                    PrintBoard();
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = task.Result();
                sw.Stop();
                PrintRow(task.Day.ToString(), task.Number.ToString(), sw.ElapsedMilliseconds.ToString() + " ms", result);
                previousDay = task.Day;
            }
            PrintBoard();
        }

        private static void PrintBoard()
        {
            Console.WriteLine($"--------------------------------------------------------------------------------------");
        }

        private static void PrintRow(string day, string part, string time, string solution)
        {
            Console.WriteLine($"|{"Day "+day,9}|{"Part "+part,10}|{time, 12}|{solution,50}|");
        }
    }
}

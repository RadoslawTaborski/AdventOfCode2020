using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class PuzzlesRunner
    {
        private static readonly PuzzlesRetriever tasksRetriever = new PuzzlesRetriever();
        private static readonly PuzzlesProcessor tasksProcessor = new PuzzlesProcessor();

        public static void Run(int day, int number)
        {
            var tasks = tasksRetriever.GetTasks(day, number);
            tasksProcessor.Run(tasks);
        }
    }
}

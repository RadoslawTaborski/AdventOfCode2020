﻿using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class TasksRunner
    {
        private static readonly TasksRetriever tasksRetriever = new TasksRetriever();
        private static readonly TasksProcessor tasksProcessor = new TasksProcessor();

        public static void Run(int day, int number)
        {
            var tasks = tasksRetriever.GetTasks(day, number);
            tasksProcessor.Run(tasks);
        }
    }
}

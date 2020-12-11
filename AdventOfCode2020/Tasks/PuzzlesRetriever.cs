using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Tasks
{
    class PuzzlesRetriever
    {
        private IEnumerable<TypeWithData> GetTasksTypes(int day = 0, int numberOfTask = 0)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                            .Where(x => typeof(IPuzzle).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .ToList();

            var result = new List<TypeWithData>();

            foreach (var type in types)
            {
                var attrs = type.GetCustomAttributes(false);

                var attr = attrs.SingleOrDefault(x => x.GetType().Name == "PuzzleAttribute");
                PuzzleAttribute attribute = attr as PuzzleAttribute;

                var data = new TaskData { Day = attribute.Day, Number = attribute.NumberOfTask };

                if (day != 0)
                {
                    if (attribute.Day == day)
                    {
                        if (numberOfTask != 0)
                        {
                            if (attribute.NumberOfTask == numberOfTask)
                            {
                                result.Add(new TypeWithData { Data = data, Type=type });
                            }
                        }
                        else
                        {
                            result.Add(new TypeWithData { Data = data, Type = type });
                        }
                    }
                }
                else
                {
                    result.Add(new TypeWithData { Data = data, Type = type });
                }
            }

            return result;
        }

        public IEnumerable<IPuzzle> GetTasks(int day = 0, int numberOfTask = 0)
        {
            var result = new List<TaskWithData>();
            var types = GetTasksTypes(day, numberOfTask);

            foreach (var type in types)
            {
                var task = (IPuzzle)Activator.CreateInstance(type.Type);
                result.Add(new TaskWithData { Data = type.Data, Task = task });
            }

            return result.OrderBy(x => x.Data.Day).ThenBy(x => x.Data.Number).Select(x=>x.Task);
        }

    }

    internal class TaskData
    {
        public int Day { get; init; }
        public int Number { get; init; }
    }

    internal class TypeWithData
    {
        public TaskData Data { get; init; }
        public Type Type { get; init; }
    }

    internal class TaskWithData
    {
        public TaskData Data { get; init; }
        public IPuzzle Task { get; init; }
    }
}

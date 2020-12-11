using AdventOfCode2020.Tasks;
using System;
using System.Configuration;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var (day, number) = GetInputParameters(args);

            PuzzlesRunner.Run(day, number);

            Console.ReadLine();
        }

        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                throw new Exception("Error reading app settings");
            }
        }

        static (int Day, int Number) GetInputParameters(string[] args)
        {
            var paramsAreSet = true;

            int day = 0;
            int number = 0;
            if (args.Length != 0)
            {
                for (var i = 0; i < args.Length; ++i)
                {
                    switch (args[i])
                    {
                        case "-d":
                            paramsAreSet &= int.TryParse(args[i + 1], out day);
                            break;
                        case "-t":
                            paramsAreSet &= int.TryParse(args[i + 1], out number);
                            break;
                    }
                }
            }
            else
            {
                var paramsFromConsole = bool.Parse(ReadSetting("ParamsFromConsole"));
                if (!paramsFromConsole)
                {
                    paramsAreSet &= int.TryParse(ReadSetting("Day"), out day);
                    paramsAreSet &= int.TryParse(ReadSetting("Task"), out number);
                }
                else
                {
                    paramsAreSet = false;
                }
            }

            if (!paramsAreSet)
            {
                day = GetConsoleParameter("Please enter the number of the day: ");
                number = GetConsoleParameter("Please enter the number of the task: ");
            }

            return (day, number);
        }

        private static int GetConsoleParameter(string question)
        {
            var result = 0;
            bool notInit = true;
            while (notInit)
            {
                Console.WriteLine(question);
                var dayStr = Console.ReadLine();
                notInit = !int.TryParse(dayStr, out result);
            }

            return result;
        }
    }
}

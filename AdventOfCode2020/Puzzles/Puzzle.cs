using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles
{
    public abstract class Puzzle : IPuzzle
    {
        private PuzzleAttribute _attribute;

        public int Number => Attribute != null ? Attribute.NumberOfTask : 0;

        public int Day => Attribute != null ? Attribute.Day : 0;

        private PuzzleAttribute Attribute
        {
            get
            {
                if (_attribute == null)
                {
                    var attrs = GetType().GetCustomAttributes(false);

                    var attr = attrs.SingleOrDefault(x => x.GetType().Name == "PuzzleAttribute");
                    _attribute = attr as PuzzleAttribute;
                }
                return _attribute;
            }
        }

        protected virtual void Result(out string result)
        {
            result = "not found";
        }

        public string Result()
        {
            Result(out var result);
            return result;
        }

        protected List<string> ReadRows(string fileName)
        {
            var result = new List<string>();

            var path = $@"./Resources/Day{Day:00}/{fileName}";

            if (!File.Exists(path))
            {
                return result;
            }

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                   result.Add(sr.ReadLine());
                }
            }

            return result;
        }

        protected List<List<char>> ReadTable(string fileName)
        {
            var result = new List<List<char>>();

            var path = $@"./Resources/Day{Day:00}/{fileName}";

            if (!File.Exists(path))
            {
                return result;
            }

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    result.Add(new List<char>(sr.ReadLine()));
                }
            }

            return result;
        }

        protected List<List<string>> ReadParts(List<string> input)
        {
            var result = new List<List<string>>();

            var tmp = new List<string>();
            foreach (var inputData in input)
            {
                if (!string.IsNullOrEmpty(inputData))
                {
                    tmp.Add(inputData);
                }
                else
                {
                    result.Add(tmp);
                    tmp = new List<string>();
                }
            }

            if (tmp.Count > 0)
            {
                result.Add(tmp);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Tasks
{
    public abstract class Task : ITask
    {
        private TaskAttribute _attribute;

        public int Number => Attribute != null ? Attribute.NumberOfTask : 0;

        public int Day => Attribute != null ? Attribute.Day : 0;

        private TaskAttribute Attribute
        {
            get
            {
                if (_attribute == null)
                {
                    var attrs = GetType().GetCustomAttributes(false);

                    var attr = attrs.SingleOrDefault(x => x.GetType().Name == "TaskAttribute");
                    _attribute = attr as TaskAttribute;
                }
                return _attribute;
            }
        }

        protected abstract void Result(out string result);
        public string Result()
        {
            Result(out var result);
            return result;
        }

        protected List<string> ReadRows(string fileName)
        {
            var result = new List<string>();

            var path = $@"./Resources/Day{Day}/{fileName}";

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day03
{
    public class Row
    {
        public List<char> Pattern { get; init; }
        private List<char> Fields { get; } = new List<char>();

        public char GetField(int idx)
        {
            while (Fields.Count <= idx)
            {
                Fields.AddRange(Pattern);
            }

            return Fields.ElementAt(idx);
        }
    }
}

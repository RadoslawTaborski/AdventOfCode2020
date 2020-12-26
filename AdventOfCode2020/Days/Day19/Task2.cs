using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day19
{
    [Puzzle(19, 2)]
    public class Task2 : Day19
    {
        protected override Dictionary<int, IRule> ModifiedRules(Dictionary<int, IRule> processedRule)
        {
            var max = 5;
            var counter = 0;
            var l8 = new List<int> { 42 };
            var l11 = new List<int> { 42, 31 };
            while(counter < max)
            {
                var l8tmp = Generator8(counter, l8);
                var l11tmp = Generator11(counter, l11);
                processedRule[8] = (processedRule[8] as Rule).Add(l8tmp);
                processedRule[11] = (processedRule[11] as Rule).Add(l11tmp);
                counter++;
            }

            return processedRule;
        }

        private List<int> Generator11(int counter, List<int> l11)
        {
            var l11tmp = new List<int>(l11);
            var counter2 = 0;
            while (counter2 < counter + 1)
            {
                for (int i = 0; i < l11.Count; i++) {
                    int l = l11[i];
                    l11tmp.Insert((l11tmp.Count + 1) / 2, l);
                }
                counter2++;
            }

            return l11tmp;
        }

        private List<int> Generator8(int counter, List<int> l8)
        {
            var l8tmp = new List<int>(l8);
            var counter2 = 0;
            while (counter2 < counter + 1)
            {
                l8tmp.AddRange(l8);
                counter2++;
            }

            return l8tmp;
        }
    }
}

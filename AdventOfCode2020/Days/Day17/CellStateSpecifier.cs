using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class CellStateSpecifier
    {
        public List<Rule> Rules { get; init; }

        public CellState GetState(CellState currentValue, int input)
        {
            var rule = Rules.Where(x => x.From == currentValue).FirstOrDefault();
            if(rule.Values.Contains(input))
            {
                return rule.To;
            }

            return rule.Default;
        }
    }
}

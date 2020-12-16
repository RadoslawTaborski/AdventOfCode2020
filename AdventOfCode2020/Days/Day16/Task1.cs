using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    [Puzzle(16)]
    public class Task1 : Day16
    {
        protected override string FindValue(Dictionary<Ticket, List<Field>> rejected, List<Ticket> correct, Ticket own, List<IValidator> validators)
        {
            string result;
            var sum = 0;
            foreach (var ticket in rejected)
            {
                sum += ticket.Value.Select(x => x.Value).Sum();
            }

            result = $"{sum}";
            return result;
        }
    }
}

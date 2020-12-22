using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day21
{
    [Puzzle(21, 2)]
    public class Task2 : Day21
    {
        protected override string GetResult(Dictionary<string, Component> components, List<Meal> meals)
        {
            var sorted = components.Where(x => x.Value.Allergen != null).OrderBy(y => y.Value.Allergen.Name).Select(z=>z.Key);
            return string.Join(",", sorted);
        }
    }
}

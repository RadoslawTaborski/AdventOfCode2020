using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day21
{
    [Puzzle(21)]
    public class Task1 : Day21
    {
        protected override string GetResult(Dictionary<string, Component> components, List<Meal> meals)
        {
            var counter = CountComponentsWithoutAllergents(meals);
            return $"{counter}";
        }

        private int CountComponentsWithoutAllergents(List<Meal> meals)
        {
            var counter = 0;
            foreach (var m in meals)
            {
                counter += m.Components.Where(x => x.Allergen == null).Count();
            }

            return counter;
        }
    }
}

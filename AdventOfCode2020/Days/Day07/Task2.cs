using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day07
{
    [Task(7, 2)]
    public class Task2 : Day07
    {
        protected override string FindValue(List<Bag> bags)
        {
            string name = "shiny gold";
            Bag bag = bags.Where(x => x.Name == name).First();

            var counter = CountBags(bag)-1;

            return $"{counter}";
        }

        private int CountBags(Bag bag)
        {
            var result = 1;
            foreach (var nestedBag in bag.Bags)
            {
                result += (nestedBag.Value * CountBags(nestedBag.Key));
            }

            return result;
        }
    }
}

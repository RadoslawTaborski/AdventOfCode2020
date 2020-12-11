using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day07
{
    [Puzzle(7)]
    public class Task1 : Day07
    {
        protected override string FindValue(List<Bag> bags)
        {
            string name = "shiny gold";
            var counter = 0;
            foreach(var bag in bags)
            {
                if(Search(bag, name))
                {
                    counter++;
                }
            }

            return $"{counter}";
        }

        private bool Search(Bag bag, string name)
        {
            var result = false;
            if(bag.Bags.Where(x=>x.Key.Name == name).Any())
            {
                return true;
            }
            foreach (var nestedBag in bag.Bags)
            {
                result |= Search(nestedBag.Key, name);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day7
{
    public class Bag
    {
        public string Name { get; init; }

        public List<KeyValuePair<Bag, int>> Bags { get; } = new List<KeyValuePair<Bag, int>>();

        public void AddItem(Bag bag, int quantity)
        {
            Bags.Add(new KeyValuePair<Bag, int>(bag, quantity));
        }
    }
}

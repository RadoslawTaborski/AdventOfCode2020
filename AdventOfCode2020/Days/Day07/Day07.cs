using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day07
{
    public abstract class Day07 : Task
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");
            var list = ReadEntries(input);
            var bags = DataSupplementation(list);

            result = FindValue(bags);
        }

        protected abstract string FindValue(List<Bag> bags);

        private List<Bag> DataSupplementation(List<KeyValuePair<Bag, string>> data)
        {
            var result = new List<Bag>();
            foreach(var item in data)
            {
                var parts = item.Value.Split(", ");
                foreach(var part in parts)
                {
                    if (part != "no other bags.")
                    {
                        var subparts = part.Split(" ");
                        var name = string.Join(" ", subparts.Take(subparts.Length - 1).Skip(1));
                        item.Key.AddItem(FindBag(name, data.Select(x => x.Key).ToList()), int.Parse(subparts[0]));
                    }
                }
                if (item.Key.Bags.Count != 0)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }

        private Bag FindBag(string name, List<Bag> bags)
        {
            return bags.Where(x => x.Name == name).First();
        }

        private List<KeyValuePair<Bag, string>> ReadEntries(List<string> input)
        {
            var collection = new List<KeyValuePair<Bag, string>>();
            foreach(var inp in input)
            {
                var parts = inp.Split(" bags contain ");
                var bag = new Bag
                {
                    Name = parts[0]
                };
                collection.Add(new KeyValuePair<Bag, string>(bag, parts[1]));
            }

            return collection;
        }
    }
}

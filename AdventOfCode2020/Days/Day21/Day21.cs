using AdventOfCode2020.Puzzles;
using MoreLinq;
using MoreLinq.Experimental;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day21
{
    public abstract class Day21 : Puzzle
    {
        private Dictionary<string, Component> components = new Dictionary<string, Component>();
        private Dictionary<string, Allergen> allergens = new Dictionary<string, Allergen>();

        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("Input1.txt");

            var meals = CreateMeals(input);

            FindAllergents(meals);

            result = GetResult(components, meals);
        }

        protected abstract string GetResult(Dictionary<string, Component> components, List<Meal> meals);

        private void FindAllergents(List<Meal> meals)
        {
            var found = new List<Allergen>();
            while (found.Count != allergens.Count)
            {
                foreach (var al in allergens.Where(x => !found.Contains(x.Value)))
                {
                    var collection = meals.Where(x => x.Allergens.Contains(al.Value));
                    var components = collection.Select(z => z.Components.Where(y => y.Allergen == null)).Aggregate((a, b) => a.Intersect(b)).ToList();
                    if (components.Count == 1)
                    {
                        components[0].Allergen = al.Value;
                        found.Add(al.Value);
                    }
                }
            }
        }

        private List<Meal> CreateMeals(List<string> input)
        {
            var result = new List<Meal>();

            var counter = 0;
            foreach(var inp in input)
            {
                var splitted = inp.Split("(", StringSplitOptions.RemoveEmptyEntries);
                var componentList = CreateComponents(splitted[0], components);
                var allergenList = CreateAllergens(splitted[1][..^1], allergens);

                foreach(var comp in componentList)
                {
                    comp.AddPossibleAllergens(allergenList.ToArray());
                }

                result.Add(new Meal {Id=0, Allergens = allergenList, Components = componentList });
                counter++;
            }

            return result;
        }

        private HashSet<Allergen> CreateAllergens(string v, Dictionary<string, Allergen> allergens)
        {
            var result = new HashSet<Allergen>();

            var newValue = v[9..];
            var splitted = newValue.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in splitted)
            {
                var trimmed = part.Trim();
                if (allergens.ContainsKey(trimmed))
                {
                    result.Add(allergens[trimmed]);
                }
                else
                {
                    var allergen = new Allergen(trimmed);
                    result.Add(allergen);
                    allergens.Add(trimmed, allergen);
                }
            }
            return result;
        }

        private HashSet<Component> CreateComponents(string v, Dictionary<string, Component> components)
        {
            var result = new HashSet<Component>();

            var splitted = v.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(var part in splitted)
            {
                var trimmed = part.Trim();
                if (components.ContainsKey(trimmed))
                {
                    result.Add(components[trimmed]);
                }
                else
                {
                    var component = new Component(trimmed);
                    result.Add(component);
                    components.Add(trimmed, component);
                }
            }
            return result;
        }
    }
}

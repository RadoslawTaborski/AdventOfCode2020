using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day21
{
    public class Meal : IEquatable<Meal>
    {
        public int Id { get; init; }
        public HashSet<Component> Components { get; init; }
        public HashSet<Allergen> Allergens { get; init; }

        public (HashSet<Component> commonComponents, HashSet<Allergen> commonAllergens) Compare(Meal meal)
        {
            var result1 = Components.Intersect(meal.Components).ToHashSet();
            var result2 = Allergens.Intersect(meal.Allergens).ToHashSet();

            return (result1, result2);
        }

        public bool Equals(Meal other)
        {
            return Id == other.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day21
{
    public class Component : IEquatable<Component>
    {
        public string Name { get; init; }
        public Allergen Allergen { get; set; }
        public HashSet<Allergen> PossibleAllergens { get; private set; }

        public Component(string name, params Allergen[] possibleAllergens)
        {
            Name = name;
            this.PossibleAllergens = new HashSet<Allergen>(possibleAllergens);
        }

        public void AddPossibleAllergens(params Allergen[] possibleAllergens)
        {
            foreach(var al in possibleAllergens)
            {
                this.PossibleAllergens.Add(al);
            }
        }

        public void RemovePossibleAllergens(params Allergen[] possibleAllergens)
        {
            foreach (var al in possibleAllergens)
            {
                this.PossibleAllergens.Remove(al);
            }
        }

        public override int GetHashCode()
        {
            return 68 + 17 * Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Component component && Equals(component);
        }

        public bool Equals(Component p)
        {
            return Name == p.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

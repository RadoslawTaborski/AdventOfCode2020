using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day21
{
    public class Allergen : IEquatable<Allergen>
    {
        public string Name { get; init; }

        public Allergen(string name)
        {
            Name = name;
        }

        public override int GetHashCode()
        {
            return 31 + 17 * Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Allergen allergen && Equals(allergen);
        }

        public bool Equals(Allergen p)
        {
            return Name == p.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

using System;

namespace AdventOfCode2020.Days.Day23
{
    public class Cup : IEquatable<Cup>
    {
        public int Id { get; init; }

        public override bool Equals(object obj)
        {
            return obj is Cup cup && Equals(cup);
        }

        public override int GetHashCode()
        {
            return 31 * Id + 17;
        }

        public bool Equals(Cup other)
        {
            return other.Id == Id;
        }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
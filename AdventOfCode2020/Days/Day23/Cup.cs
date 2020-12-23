using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day23
{
    public class Cup : IEquatable<Cup>
    {
        public int Id { get; private set; }
        public Cup Next { get; private set; }

        public Cup(int id)
        {
            Id = id;
            Next = null;
        }

        public Cup SetNext(Cup next)
        {
            Next = next;
            return this;
        }

        public List<Cup> ExtractNexts(int count)
        {
            var result = new List<Cup>();

            var cup = this;
            for (var i = 0; i < count; ++i)
            {
                cup = cup.Next;
                result.Add(cup);
                if (i == count - 1)
                {
                    var tmp = cup.Next;
                    cup.Next = null;
                    Next = tmp;
                }
            }

            return result;
        }

        public void Insert(List<Cup> toAdd)
        {
            var tmp = Next;

            Next = toAdd[0];
            toAdd[^1].Next = tmp;
        }

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
            var next = Next != null ? Next.Id.ToString() :"null";
            return $"{Id} -> {next}";
        }
    }
}
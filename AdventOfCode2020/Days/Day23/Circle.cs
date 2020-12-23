using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day23
{
    public class Circle
    {
        public int MaxId { get; private set; }
        private Dictionary<int, Cup> Memory { get; set; }
        public Cup Start { get; private set; }

        public Circle(Cup start)
        {
            Start = start;
            Memory = new Dictionary<int, Cup>();
            var cup = start;
            MaxId = cup.Id;
            do
            {
                Memory.Add(cup.Id, cup);
                cup = cup.Next;
                if (MaxId < cup.Id)
                {
                    MaxId = cup.Id;
                }
            } while (cup.Id != start.Id);
        }

        public Cup GetCup(int id)
        {
            return Memory[id];
        }

        public List<Cup> GetAll(Cup start)
        {
            var result = new List<Cup>();
            var cup = start;
            do
            {
                result.Add(cup);
                cup = cup.Next;
            } while (cup.Id != start.Id);

            return result;
        }
    }
}

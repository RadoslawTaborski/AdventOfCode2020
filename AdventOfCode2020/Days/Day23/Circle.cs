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
        public KeyValuePair<int, Cup> Current { get; private set; }
        private HashSet<Cup> Enabled { get; set; }
        private List<Cup> Cups { get; set; }

        public Circle(List<Cup> cups)
        {
            Cups = cups;
            Current = new KeyValuePair<int, Cup>(0, Cups[0]);
            Enabled = new HashSet<Cup>(cups);
        }

        public Cup GetNext()
        {
            var next = Cups[GetNextIndex(1)];
            Current = new KeyValuePair<int, Cup>(GetNextIndex(1), next);
            return Current.Value;
        }

        public void SkipTo(Cup cup)
        {
            var idx = Cups.IndexOf(cup);
            Current = new KeyValuePair<int, Cup>(idx, Cups[idx]);
        }

        public List<Cup> GetAll(Cup start)
        {
            var previous = Current;
            SkipTo(start);
            var result = new List<Cup>();
            for(var i = 0; i < Cups.Count; ++i)
            {
                var idx = GetNextIndex(i);
                result.Add(Cups[idx]);
            }

            SkipTo(previous.Value);
            return result;
        }

        public Cup Exists(int cupId)
        {
            if (cupId < 0)
            {
                return Cups.MaxBy(x => x.Id).First();
            }
            var cup = new Cup { Id = cupId };
            if (Enabled.Contains(cup))
            {
                return cup;
            } else
            {
                return null;
            }
        }

        public List<Cup> ExtractNext(int number)
        {
            var result = new List<Cup>();

            for(var i =0; i<number; ++i)
            {
                var idx = GetNextIndex(1);
                result.Add(Cups[idx]);
                Enabled.Remove(Cups[idx]);
                Cups.RemoveAt(idx);
                SkipTo(Current.Value);
            }

            return result;
        }

        public void Insert(List<Cup> toAdd)
        {
            var idx = GetNextIndex(1);
            foreach (var a in toAdd)
            {
                Cups.Insert(idx, a);
                Enabled.Add(a);
            }
        }

        private int GetNextIndex(int number)
        {
            var newIdx = Current.Key + number;
            if (newIdx>Cups.Count-1)
            {
                return newIdx - Cups.Count;
            }
            return newIdx;
        }

        public override string ToString()
        {
            return string.Join(", ", Cups);
        }
    }
}

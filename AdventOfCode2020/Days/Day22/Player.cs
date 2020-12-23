using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day22
{
    public class Player
    {
        public int Id { get; init; }
        public Queue<int> Cards { get; init; }
        private List<List<int>> History { get; set; } = new List<List<int>>();

        public int GetCard()
        {
            var card = Cards.Peek();
            Cards.Dequeue();
            return card;
        }

        public void AddCard(params int[] cards)
        {
            foreach(var c in cards)
            {
                Cards.Enqueue(c);
            }
        }

        public void Remember()
        {
            History.Add(new List<int>(Cards));
        }

        public bool IsInHistory()
        {
            foreach (var h in History)
            {
                if (Cards.SequenceEqual(h))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Id}: {string.Join(", ", Cards)}";
        }
    }
}

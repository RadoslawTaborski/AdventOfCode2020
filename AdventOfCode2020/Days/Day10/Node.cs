using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day10
{
    public class Node
    {
        public int Id { get; }
        public int Value { get; }

        private long? numberOfWays = null;

        public Node(int id, int value)
        {
            Id = id;
            Value = value;
        }

        private List<Node> Nodes { get; } = new List<Node>();

        public void Add(Node node)
        {
            Nodes.Add(node);
        }

        internal long GetNumberOfWays()
        {
            if (Nodes.Count == 0)
            {
                numberOfWays = 1;
            }

            if (numberOfWays == null)
            {
                numberOfWays = 0;

                foreach (var n in Nodes)
                {
                    numberOfWays += n.GetNumberOfWays();
                }
            }

            return numberOfWays.GetValueOrDefault();
        }
    }
}

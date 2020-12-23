using AdventOfCode2020.Puzzles;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day22
{
    public abstract class Day22 : Puzzle
    {
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("Input1.txt");
            var playersData = input.Split("");
            var player1 = CreatePlayer(playersData.ElementAt(0), 1);
            var player2 = CreatePlayer(playersData.ElementAt(1), 2);

            var winner = Game(player1, player2);

            result = $"{Rater.Rate(winner)}";
        }

        protected abstract Player Game(Player player1, Player player2);

        private Player CreatePlayer(IEnumerable<string> data, int id)
        {
            var queue = new Queue<int>();
            foreach(var inp in data.Skip(1))
            {
                queue.Enqueue(int.Parse(inp));
            }

            return new Player { Id = id, Cards = queue };
        }
    }
}

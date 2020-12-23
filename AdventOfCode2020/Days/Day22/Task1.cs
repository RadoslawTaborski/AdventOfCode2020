using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day22
{
    [Puzzle(22)]
    public class Task1 : Day22
    {
        protected override Player Game(Player player1, Player player2)
        {
            while (player1.Cards.Count != 0 && player2.Cards.Count != 0)
            {
                var player1Card = player1.GetCard();
                var player2Card = player2.GetCard();

                if (player1Card > player2Card)
                {
                    player1.AddCard(player1Card);
                    player1.AddCard(player2Card);
                }
                else
                {
                    player2.AddCard(player2Card);
                    player2.AddCard(player1Card);
                }
            }

            return player1.Cards.Count == 0 ? player2 : player1;
        }
    }
}

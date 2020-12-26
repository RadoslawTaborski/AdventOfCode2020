using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day22
{
    [Puzzle(22, 2)]
    public class Task2 : Day22
    {
        protected override Player Game(Player player1, Player player2)
        {
            Player winner = null;
            while (player1.Cards.Count != 0 && player2.Cards.Count != 0)
            {
                bool p1AlreadyWas = player1.IsInHistory();
                bool p2AlreadyWas = player2.IsInHistory();
                player1.Remember();
                player2.Remember();
                var player1Card = player1.GetCard();
                var player2Card = player2.GetCard();

                if (p1AlreadyWas || p2AlreadyWas)
                {
                    winner = player1;
                    break;
                }
                else
                {
                    winner = player1Card > player2Card ? player1 : player2;

                    if (player1.Cards.Count >= player1Card && player2.Cards.Count >= player2Card)
                    {
                        winner = SubGame(player1, player2, winner, player1Card, player2Card);
                    }
                }
                if (winner.Id == player1.Id)
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

            return winner;
        }

        private Player SubGame(Player player1, Player player2, Player winner, int player1Card, int player2Card)
        {
            var player1Clone = CreateClone(player1, player1Card);
            var player2Clone = CreateClone(player2, player2Card);

            if (player1Clone.Cards.Count != 0 && player2Clone.Cards.Count != 0)
            {
                winner = Game(player1Clone, player2Clone);
            }

            return winner;
        }

        private Player CreateClone(Player player, int value)
        {
            return new Player { Id = player.Id, Cards = new Queue<int>(player.Cards.Take(value)) };
        }
    }
}

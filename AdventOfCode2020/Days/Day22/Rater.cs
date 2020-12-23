using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day22
{
    public class Rater
    {
        public static int Rate(Player player)
        {
            var result = 0;
            var counter = 1;
            foreach(var card in player.Cards.Reverse())
            {
                result += counter * card;
                counter++;
            }

            return result;
        }
    }
}

using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day23
{
    public abstract class Day23 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");

            var circle = CreateCircle(input);

            circle = Play(circle, GetNoOfTurns());

            result = FindValue(circle);
        }

        protected abstract string FindValue(Circle circle);

        protected abstract int GetNoOfTurns();

        private Circle Play(Circle circle, int turns)
        {
            var counter = 0;
            var cup = circle.Start;
            while (counter != turns)
            {
                var list = cup.ExtractNexts(3);
                int search = GetInsertCupId(circle, cup, list);
                var previousId = cup.Id;
                cup = circle.GetCup(search);
                cup.Insert(list);
                cup = circle.GetCup(previousId);
                cup = cup.Next;

                counter++;
            }

            return circle;
        }

        private int GetInsertCupId(Circle circle, Cup cup, List<Cup> list)
        {
            var search = cup.Id - 1;
            if (search == 0)
            {
                search = circle.MaxId;
            }
            while (list.Where(x => x.Id == search).Any())
            {
                search--;
                if (search == 0)
                {
                    search = circle.MaxId;
                }
            }

            return search;
        }

        private Circle CreateCircle(List<string> input)
        {
            var max = int.Parse(input[0][0].ToString());
            var start = new Cup(max);
            var cup = start;
            foreach (var c in input[0].Skip(1))
            {
                var id = int.Parse(c.ToString());
                if(id > max)
                {
                    max = id;
                }
                var newCup = new Cup(id);
                cup.SetNext(newCup);
                cup = newCup;
            }
            cup = Extends(cup, max);
            cup.SetNext(start);

            return new Circle(start);
        }

        protected abstract Cup Extends(Cup cup, int max);
    }
}

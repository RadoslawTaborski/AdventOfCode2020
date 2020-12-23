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
            base.Result(out result);

            var input = ReadRows("Input1.txt");

            var circle = CreateCircle(input);

            circle = Play(circle, 100);

            var collectionStartingAt1 = circle.GetAll(new Cup { Id = 1 });
            result = $"{string.Join("", collectionStartingAt1.Skip(1))}";
        }

        private Circle Play(Circle circle, int turns)
        {
            //Console.WriteLine(circle);
            var counter = 0;
            while (counter != turns)
            {
                var list = circle.ExtractNext(3);
                list.Reverse();
                var previous = circle.Current;
                var search = previous.Value.Id - 1;
                var searchedCup = circle.Exists(search);
                while (searchedCup == null)
                {
                    search--;
                    searchedCup = circle.Exists(search);
                }
                circle.SkipTo(searchedCup);
                circle.Insert(list);
                circle.SkipTo(previous.Value);
                circle.GetNext();

                counter++;
                //Console.WriteLine(circle);
            }

            return circle;
        }

        private Circle CreateCircle(List<string> input)
        {
            var list = new List<Cup>();
            foreach (var c in input[0])
            {
                list.Add(new Cup { Id = int.Parse(c.ToString()) });
            }
            return new Circle(list);
        }
    }
}

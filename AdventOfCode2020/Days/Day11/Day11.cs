using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day11
{
    public abstract class Day11 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadTable("Input1.txt");

            var area = AreaCreator.Create(input);

            var memory = new List<Area>();
            memory.Add(area);
            do
            {
                memory.Add(GetTurnMaker().MakeTurn(memory.Last()));
            }
            while (!memory.Last().Equals(memory[^2]));

            Area lastState = memory.Last();

            result = $"{lastState.GetNoOfOccupiedPlaces()}";
        }

        protected abstract TurnMaker GetTurnMaker();
    }
}

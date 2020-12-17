using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public abstract class Day17 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadTable("Input1.txt");

            var lastState = new CubeCreator().Create(input, GetDim());
            //Console.WriteLine(lastState);
            int counter = 1;
            while (counter <= 6)
            {
                lastState = GetTurnMaker().MakeTurn(lastState);
                //Console.WriteLine($"********* counter = {counter}");
                //Console.WriteLine(lastState);
                counter++;
            }

            result = $"{new CubeAnalyzer().GetNoOfActiveCube(lastState)}";
        }

        protected abstract int GetDim();
        protected TurnMaker GetTurnMaker() {
            var rules = new List<Rule>
            {
                new Rule
                {
                    From = CellState.Active,
                    To = CellState.Active,
                    Default = CellState.Inactive,
                    Values = new List<long> {2,3}
                },
                new Rule
                {
                    From = CellState.Inactive,
                    Values = new List<long> {3},
                    To = CellState.Active,
                    Default = CellState.Inactive
                }
            };

            return new TurnMaker(rules, new NeighborhoodChecker());
        }
    }
}

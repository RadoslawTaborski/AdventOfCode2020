using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17.Puzzle1
{
    [Puzzle(17)]
    public class Task1 : Day17
    {
        protected override ICubeCreator GetCubeCreator()
        {
            return new CubeCreator();
        }

        protected override ITurnMaker GetTurnMaker()
        {
            var rules = new List<Rule>
            {
                new Rule
                {
                    From = CellState.Active,
                    To = CellState.Active,
                    Default = CellState.Inactive,
                    Values = new List<int> {2,3}
                },
                new Rule
                {
                    From = CellState.Inactive,
                    Values = new List<int> {3},
                    To = CellState.Active,
                    Default = CellState.Inactive
                }
            };

            return new TurnMaker(rules, new NeighborhoodChecker());
        }
    }
}

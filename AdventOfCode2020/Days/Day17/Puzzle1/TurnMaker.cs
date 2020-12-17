using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17.Puzzle1
{
    public class TurnMaker : ITurnMaker
    {
        private readonly CellStateSpecifier placeSpecifier;
        private readonly INeighborhoodChecker checker;

        public TurnMaker(List<Rule> rules, INeighborhoodChecker checker)
        {
            this.checker = checker;
            this.placeSpecifier = new CellStateSpecifier { Rules = rules };
        }

        public ICube MakeTurn(ICube inputState)
        {
            var result = new Cube();

            for (var i = inputState.GetRange(0).min-1; i <= inputState.GetRange(0).max+1; ++i)
            {
                for (var j = inputState.GetRange(1).min-1; j <= inputState.GetRange(1).max+1; ++j)
                {
                    for (var k = inputState.GetRange(2).min-1; k <= inputState.GetRange(2).max+1; ++k)
                    {
                        int value = checker.Check(ref inputState, i, j, k);
                        CellState newState = placeSpecifier.GetState(inputState.GetValue(i, j, k).Value, value);
                        result.SetPlace(newState, i, j, k);
                    }
                }
            }

            return result;
        }
    }
}

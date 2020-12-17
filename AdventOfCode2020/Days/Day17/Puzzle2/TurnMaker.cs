using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day17.Puzzle2
{
    internal class TurnMaker : ITurnMaker
    {
        private CellStateSpecifier placeSpecifier;
        private NeighborhoodChecker checker;

        public TurnMaker(List<Rule> rules, NeighborhoodChecker neighborhoodChecker)
        {
            this.placeSpecifier = new CellStateSpecifier { Rules = rules };
            this.checker = neighborhoodChecker;
        }

        public ICube MakeTurn(ICube inputState)
        {
            var result = new Cube();

            for (var i = inputState.GetRange(0).min - 1; i <= inputState.GetRange(0).max + 1; ++i)
            {
                for (var j = inputState.GetRange(1).min - 1; j <= inputState.GetRange(1).max + 1; ++j)
                {
                    for (var k = inputState.GetRange(2).min - 1; k <= inputState.GetRange(2).max + 1; ++k)
                    {
                        for (var l = inputState.GetRange(3).min - 1; l <= inputState.GetRange(3).max + 1; ++l)
                        {
                            int value = checker.Check(ref inputState, i, j, k, l);
                            CellState newState = placeSpecifier.GetState(inputState.GetValue(i, j, k, l).Value, value);
                            result.SetPlace(newState, i, j, k, l);
                        }
                    }
                }
            }

            return result;
        }
    }
}
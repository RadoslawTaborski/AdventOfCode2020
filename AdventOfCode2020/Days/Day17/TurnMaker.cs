using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public class TurnMaker
    {
        private readonly CellStateSpecifier placeSpecifier;
        private readonly NeighborhoodChecker checker;

        public TurnMaker(List<Rule> rules, NeighborhoodChecker checker)
        {
            this.checker = checker;
            this.placeSpecifier = new CellStateSpecifier { Rules = rules };
        }

        public Cube MakeTurn(Cube inputState)
        {
            var result = new Cube(inputState.Dim);

            var keys = new List<List<long>>();
            GetPossibilities(new List<long>(), ref keys, 0, inputState);

            foreach (var key in keys)
            {
                var value = checker.Check(inputState, key.ToArray());
                CellState newState = placeSpecifier.GetState(inputState.GetValue(key.ToArray()).Value, value);
                result.SetPlace(newState, key.ToArray());
            }

            return result;
        }

        private void GetPossibilities(List<long> input, ref List<List<long>> output, int idx, Cube cube)
        {
            if (idx == cube.Dim)
            {
                output.Add(input);
                return;
            }
            for (var i = cube.GetRange(idx).min -1; i <= cube.GetRange(idx).max; ++i)
            {
                var copy = new List<long>(input);
                copy.Add(i);
                GetPossibilities(copy, ref output, idx + 1, cube);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    public class TurnMaker
    {
        private readonly PlaceSpecifier placeSpecifier;
        private readonly INeighborhoodChecker checker;

        public TurnMaker(int maxNumberOfNeighbors, INeighborhoodChecker checker)
        {
            this.checker = checker;
            this.placeSpecifier = new PlaceSpecifier { MaxNumberOfNeighbors = maxNumberOfNeighbors };
        }

        public Area MakeTurn(Area inputState)
        {
            var result = new Area(inputState.GetRows(), inputState.GetColumns());

            for(var i = 0; i< inputState.GetRows(); ++i)
            {
                for(var j = 0; j< inputState.GetColumns(); ++j)
                {
                    int value = checker.Check(ref inputState, i, j);
                    Place newState = placeSpecifier.GetPlace(inputState.GetValue(i,j).Value, value);
                    result.SetPlace(i, j, newState);
                }
            }

            return result;
        }
    }
}

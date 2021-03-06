﻿using System;
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

            var keys = CubeAnalyzer.GetPossibilities(inputState);

            foreach (var key in keys)
            {
                var value = checker.Check(inputState, key);
                CellState newState = placeSpecifier.GetState(inputState.GetValue(key).Value, value);
                result.SetCell(newState, key);
            }

            return result;
        }
    }
}

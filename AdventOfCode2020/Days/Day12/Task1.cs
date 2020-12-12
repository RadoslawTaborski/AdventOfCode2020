using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day12
{
    [Puzzle(12)]
    public class Task1 : Day12
    {
        private readonly IMoveMaker moveMaker = new Task1MoveMaker();

        protected override Position GetInitShipPosition()
        {
            return new Position
            {
                X = 0,
                Y = 0,
                Turn = Turn.Right
            };
        }

        protected override Position GetInitWaypointPosition()
        {
            return new Position
            {
                X = 0,
                Y = 0,
                Turn = Turn.Up
            };
        }

        protected override IMoveMaker GetMoveMaker()
        {
            return moveMaker;
        }
    }
}

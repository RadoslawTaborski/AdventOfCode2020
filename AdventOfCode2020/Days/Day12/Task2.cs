using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day12
{
    [Puzzle(12,2)]
    public class Task2 : Day12
    {
        private readonly IMoveMaker moveMaker = new Task2MoveMaker();

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
                X = 10,
                Y = 1,
                Turn = Turn.Up
            };
        }

        protected override IMoveMaker GetMoveMaker()
        {
            return moveMaker;
        }
    }
}

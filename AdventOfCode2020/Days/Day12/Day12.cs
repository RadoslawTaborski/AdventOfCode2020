using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day12
{
    public abstract class Day12 : Puzzle
    {
        protected override void Result(out string result)
        {
            base.Result(out result);

            var input = ReadRows("Input1.txt");
            var steps = new List<IStep>();
            foreach (var inp in input)
            {
                steps.Add(StepFactory.Create(inp));
            }

            var finalPositions = MakeMovies(GetInitShipPosition(), GetInitWaypointPosition(), steps);
            result = $"{GetManhattanDistance(finalPositions.ship.X, finalPositions.ship.Y)}";
        }

        protected abstract Position GetInitShipPosition();
        protected abstract Position GetInitWaypointPosition();

        protected abstract IMoveMaker GetMoveMaker();

        private int GetManhattanDistance(int x, int y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }

        private (Position ship, Position waypoint) MakeMovies(Position shipPosition, Position waypointPosition, List<IStep> steps)
        {
            var result1 = shipPosition;
            var result2 = waypointPosition;
            foreach(var step in steps)
            {
                var (ship, waypoint) = GetMoveMaker().MakeMove(result1, result2, step);
                result1 = ship;
                result2 = waypoint;
                //Console.WriteLine($"ship: {result1} \t waypoint: {result2}");
            }

            return (result1, result2);
        }
    }
}

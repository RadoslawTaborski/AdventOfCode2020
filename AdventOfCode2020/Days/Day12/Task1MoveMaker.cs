using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public class Task1MoveMaker : IMoveMaker
    {
        public (Position ship, Position waypoint) MakeMove(Position inputShipPosition, Position inputWaypointPosition, IStep step)
        {
            return step switch
            {
                Forward f when step is Forward => (MakeForward(inputShipPosition, f), inputWaypointPosition),
                Move m when step is Move => (MakeDirectionMove(inputShipPosition, m), inputWaypointPosition),
                Rotation r when step is Rotation => (MakeRotation(inputShipPosition, r), inputWaypointPosition),
                _ => throw new Exception("Illegal step"),
            };
        }

        private Position MakeRotation(Position input, Rotation r)
        {
            return new Position { X = input.X, Y = input.Y, Turn = input.Turn.CalculateTurn(r) };
        }

        private Position MakeDirectionMove(Position input, Move m)
        {
            return m.Direction switch
            {
                Direction.N => new Position { X = input.X, Y = input.Y + m.Value, Turn = input.Turn },
                Direction.S => new Position { X = input.X, Y = input.Y - m.Value, Turn = input.Turn },
                Direction.E => new Position { X = input.X + m.Value, Y = input.Y, Turn = input.Turn },
                Direction.W => new Position { X = input.X - m.Value, Y = input.Y, Turn = input.Turn },
                _ => throw new Exception("Illegal direction"),
            };
        }

        private Position MakeForward(Position input, Forward f)
        {
            return input.Turn switch
            {
                Turn.Up => new Position { X = input.X, Y = input.Y + f.Value, Turn = input.Turn },
                Turn.Right => new Position { X = input.X + f.Value, Y = input.Y, Turn = input.Turn },
                Turn.Down => new Position { X = input.X, Y = input.Y - f.Value, Turn = input.Turn },
                Turn.Left => new Position { X = input.X - f.Value, Y = input.Y, Turn = input.Turn },
                _ => throw new Exception("Illegal turn"),
            };
        }
    }
}

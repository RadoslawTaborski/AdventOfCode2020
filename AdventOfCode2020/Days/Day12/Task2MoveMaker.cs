using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public class Task2MoveMaker : IMoveMaker
    {
        public (Position ship, Position waypoint) MakeMove(Position inputShipPosition, Position inputWaypointPosition, IStep step)
        {
            return step switch
            {
                Forward f when step is Forward => (MakeForward(inputShipPosition, inputWaypointPosition, f), inputWaypointPosition),
                Move m when step is Move => (inputShipPosition, MakeDirectionMove(inputWaypointPosition, m)),
                Rotation r when step is Rotation => (inputShipPosition, MakeRotation(inputWaypointPosition, r)),
                _ => throw new Exception("Illegal step"),
            };
        }

        private Position MakeRotation(Position waypointPosition, Rotation r)
        {
            int degrees = r.Value;
            if (r.Turn == Turn.Right)
            {
                degrees = 360 - r.Value;
            }

            var radians = DegreeToRadians(degrees);
            var x = waypointPosition.X * Math.Cos(radians) - waypointPosition.Y * Math.Sin(radians);
            var y = waypointPosition.X * Math.Sin(radians) + waypointPosition.Y * Math.Cos(radians);

            return new Position { X = (int)Math.Round(x), Y = (int)Math.Round(y), Turn = waypointPosition.Turn };
        }

        private double DegreeToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private Position MakeDirectionMove(Position waypointPosition, Move m)
        {
            return m.Direction switch
            {
                Direction.N => new Position { X = waypointPosition.X, Y = waypointPosition.Y + m.Value, Turn = waypointPosition.Turn },
                Direction.S => new Position { X = waypointPosition.X, Y = waypointPosition.Y - m.Value, Turn = waypointPosition.Turn },
                Direction.E => new Position { X = waypointPosition.X + m.Value, Y = waypointPosition.Y, Turn = waypointPosition.Turn },
                Direction.W => new Position { X = waypointPosition.X - m.Value, Y = waypointPosition.Y, Turn = waypointPosition.Turn },
                _ => throw new Exception("Illegal direction"),
            };
        }

        private Position MakeForward(Position shipPosition, Position wayPointPosition, Forward f)
        {
            return new Position
            {
                X = wayPointPosition.X * f.Value + shipPosition.X,
                Y = wayPointPosition.Y * f.Value + shipPosition.Y,
                Turn = shipPosition.Turn
            };
        }
    }
}

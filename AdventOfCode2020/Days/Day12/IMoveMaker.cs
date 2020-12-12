using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public interface IMoveMaker
    {
        public (Position ship, Position waypoint) MakeMove(Position inputShipPosition, Position inputWayPointPosition, IStep step);
    }
}

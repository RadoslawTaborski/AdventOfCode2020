using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    public class PlaceSpecifier
    {
        public int MaxNumberOfNeighbors { get; init; }

        public Place GetPlace(Place currentValue, int input)
        {
            if(currentValue == Place.Free && input == 0)
            {
                return Place.Occupied;
            }
            if(currentValue == Place.Occupied && input >= MaxNumberOfNeighbors)
            {
                return Place.Free;
            }

            return currentValue;
        }
    }
}

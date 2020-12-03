using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day3
{
    public class Travel
    {
        public Area Area { get; init; }
        public Traveler Traveler { get; init; }

        public List<char> ObservedFields(int x, int y)
        {
            var result = new List<char>();

            var xPosition = x;
            for(var i = y; i < Area.Rows.Count; i+=Traveler.StepInDown)
            {
                result.Add(Area.Rows[i].GetField(xPosition));
                xPosition += Traveler.StepInRight;
            }

            return result;
        }
    }
}

using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day3
{
    public abstract class Day3 : Task
    {
        protected int StartTravel(int startX, int startY, int stepInRight, int stepInDown, int observeX, int observeY, char observedObj)
        {
            var input = ReadRows($"Input1.txt");

            Travel travel = CreateTravel(input, stepInRight, stepInDown, observeX, observeY);

            var observedPoints = travel.ObservedFields(startX, startY);

            var countedChars = observedPoints.Where(x => x == observedObj).Count();
            return countedChars;
        }

        private Travel CreateTravel(List<string> input, int stepInRight, int stepInDown, int observeX, int observeY)
        {
            Area area = CreateArea(input);
            Traveler traveler = CreateTraveler(stepInRight, stepInDown, observeX, observeY);
            var travel = new Travel
            {
                Area = area,
                Traveler = traveler
            };
            return travel;
        }

        private Traveler CreateTraveler(int stepInRight, int stepInDown, int observeX, int observeY)
        {
            return new Traveler
            {
                StepInRight = stepInRight,
                StepInDown = stepInDown,
                ObservePoint = new ObservePoint
                {
                    X = observeX,
                    Y = observeY,
                }
            };
        }

        private Area CreateArea(List<string> input)
        {
            var rows = new List<Row>();

            foreach (var line in input)
            {
                rows.Add(new Row
                {
                    Pattern = new List<char>(line)
                });
            }

            return new Area
            {
                Rows = rows
            };
        }
    }
}

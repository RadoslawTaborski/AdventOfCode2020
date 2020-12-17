using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public abstract class Day17 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadTable("Input1.txt");

            var lastState = GetCubeCreator().Create(input);
            //Console.WriteLine(lastState);
            int counter = 1;
            while (counter <= 6)
            {
                lastState = GetTurnMaker().MakeTurn(lastState);
                //Console.WriteLine($"********* counter = {counter}");
                //Console.WriteLine(lastState);
                counter++;
            }

            result = $"{lastState.GetNoOfActiveCube()}";
        }

        protected abstract ITurnMaker GetTurnMaker();
        protected abstract ICubeCreator GetCubeCreator();
    }
}

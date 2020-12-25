using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day25
{
    [Puzzle(25)]
    public class Day25 : Puzzle
    {
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt").Select(x => long.Parse(x));

            var cardLoopSize = GenerateLoopSize(input.ElementAt(0), 1, 7, 20201227);
            var doorLoopSize = GenerateLoopSize(input.ElementAt(1), 1, 7, 20201227);

            var cardPrivateKey = GeneratePrivateKey(1, input.ElementAt(0), 20201227, doorLoopSize);

            result = $"{cardPrivateKey}";
        }

        private int GenerateLoopSize(long searchValue, long initValue, long subjectNumber, long magicNumber)
        {
            var value = initValue;
            var counter = 0;
            while (value != searchValue)
            {
                value = (value * subjectNumber) % magicNumber;
                counter++;
            }
            return counter;
        }

        private long GeneratePrivateKey(long initValue, long subjectNumber, long magicNumber, long loopSize)
        {
            var value = initValue;
            var counter = 0;
            while (counter != loopSize)
            {
                value = (value * subjectNumber) % magicNumber;
                counter++;
            }
            return value;
        }
    }
}

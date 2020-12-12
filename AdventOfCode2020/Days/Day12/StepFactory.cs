using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day12
{
    public class StepFactory
    {
        public static IStep Create(string input)
        {
            var token = input[0];
            var value = int.Parse(input.Substring(1));

            return token switch
            {
                'N' => new Move { Direction = Direction.N, Value = value },
                'S' => new Move { Direction = Direction.S, Value = value },
                'E' => new Move { Direction = Direction.E, Value = value},
                'W' => new Move { Direction = Direction.W, Value = value},
                'L' => new Rotation { Turn = Turn.Left, Value = value},
                'R' => new Rotation { Turn = Turn.Right, Value = value},
                'F' => new Forward { Value = value},
                _ => throw new Exception($"Illegal operation: {token}"),
            };
        }
    }
}

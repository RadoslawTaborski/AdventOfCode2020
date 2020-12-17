using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day17
{
    public interface ITurnMaker
    {
        ICube MakeTurn(ICube inputState);
    }
}

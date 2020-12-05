using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day5.Decoders
{
    public interface IDecoder
    {
        (int row, int column) Decode(string code);
    }
}

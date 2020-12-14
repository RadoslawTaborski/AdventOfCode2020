using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public interface IDecoder
    {
        List<KeyValuePair<long, long>> Decode(MemoryLine m, List<KeyValuePair<int, int>> currentMask);
    }
}

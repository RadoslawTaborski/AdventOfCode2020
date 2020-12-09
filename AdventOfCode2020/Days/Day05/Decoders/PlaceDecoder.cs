using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day05.Decoders
{
    public class PlaceDecoder : IDecoder
    {
        public int NoOfRow { get; init; }
        public int NoOfColumn { get; init; }

        public (int row, int column) Decode(string code)
        {
            var startRow = 0;
            var startColumn = 0;
            var maxRow = NoOfRow;
            var maxColumn = NoOfColumn;

            for(var i = 0; i < 7; ++i)
            {
                if (code[i] == 'F')
                {
                    maxRow -= (maxRow - startRow + 1) / 2;
                }
                if (code[i] == 'B')
                {
                    startRow += (maxRow - startRow + 1) / 2;
                }
            }

            for (var i = 7; i < 10; ++i)
            {
                if (code[i] == 'L')
                {
                    maxColumn -= (maxColumn - startColumn + 1) / 2;
                }
                if (code[i] == 'R')
                {
                    startColumn += (maxColumn - startColumn + 1) / 2;
                }
            }

            return (maxRow-1, maxColumn-1);
        }
    }
}

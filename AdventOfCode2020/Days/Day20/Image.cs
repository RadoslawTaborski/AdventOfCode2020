using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class Image
    {
        public List<TilesRow> Rows { get; private set; } = new List<TilesRow>();

        public void Add(TilesRow row)
        {
            Rows.Add(row);
        }

        public List<List<char>> GetImage()
        {
            var result = new List<List<char>>();

            foreach(var item in Rows)
            {
                result.AddRange(item.GetWithoutBorder());
            }

            return result;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            foreach(var row in Rows)
            {
                strBuilder.Append(row);
                strBuilder.Append("\r\n");
            }

            return strBuilder.ToString();
        }
    }
}

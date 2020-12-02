using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day2
{
    class DataParser
    {
        public static (int v1, int v2, string v3, string v4) ExtractDataFromRow(string row)
        {
            string[] parts1 = row.Split("-");
            var value1 = int.Parse(parts1[0]);
            string[] parts2 = parts1[1].Split(" ");
            var value2 = int.Parse(parts2[0]);
            var value4 = parts2[2];
            string[] parts3 = parts2[1].Split(":");
            var value3 = parts3[0];

            return (value1, value2, value3, value4);
        }
    }
}

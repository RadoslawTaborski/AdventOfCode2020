using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Helpers
{
    public class ArrayModifier
    {
        public static List<List<char>> Rotate(List<List<char>> array)
        {
            List<List<char>> ret = new List<List<char>>(array);
            for (var i = 0; i < ret.Count; ++i)
            {
                ret[i] = new List<char>(array[i]);
            }

            for (var j = 0; j < array.Count; ++j)
            {
                for (int i = 0; i < array[0].Count; ++i)
                {
                    ret[i][ret[0].Count - j - 1] = array[j][i];
                }
            }

            return ret;
        }

        public static void Print(List<List<char>> array)
        {
            foreach (var dim1 in array)
            {
                Console.WriteLine(new string(dim1.ToArray()));
            }
        }
    }
}

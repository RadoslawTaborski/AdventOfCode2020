using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public class Task1Decoder : Decoder
    {
        public override List<KeyValuePair<long, long>> Decode(MemoryLine m, List<KeyValuePair<int, int>> currentMask)
        {
            var results = new List<KeyValuePair<long, long>>();
            int[] value = LongToBits(m.InputValue);

            var v = PutMask(value, currentMask);

            results.Add(new KeyValuePair<long, long>(m.Position, v));

            return results;
        }

        private long PutMask(int[] values, List<KeyValuePair<int, int>> currentMask)
        {
            foreach (var maskItem in currentMask)
            {
                if (maskItem.Value != -1)
                {
                    values[35 - maskItem.Key] = maskItem.Value;
                }
            }

            return GetFromBits(values);
        }
    }
}

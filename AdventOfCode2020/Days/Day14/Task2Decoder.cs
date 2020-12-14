using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public class Task2Decoder : Decoder
    {
        public override List<KeyValuePair<long, long>> Decode(MemoryLine m, List<KeyValuePair<int, int>> currentMask)
        {
            var values = CreatePositions(m.Position, currentMask);

            return values.Select(x => new KeyValuePair<long, long>(x, m.InputValue)).ToList();
        }

        private List<long> CreatePositions(long position, List<KeyValuePair<int, int>> currentMask)
        {
            var bits = LongToBits(position);

            bits = PutMask(bits, currentMask);

            var variation = GenerateVariation(bits);

            return variation.Select(v => GetFromBits(v)).ToList();
        }

        private List<int[]> GenerateVariation(int[] bits)
        {
            var result = new List<int[]>();

            GenerateVariation(bits, ref result);

            return result;
        }

        private void GenerateVariation(int[] bits, ref List<int[]> result)
        {
            if (!bits.Contains(-1))
            {
                result.Add(bits);
                return;
            }
            var index = Array.IndexOf(bits, -1);
            for(var i = 0; i<=1; ++i)
            {
                var copy = new int[bits.Length];
                Array.Copy(sourceArray: bits, copy, length: bits.Length);
                copy[index] = i;
                GenerateVariation(copy, ref result);
            }
        }

        private int[] PutMask(int[] bits, List<KeyValuePair<int, int>> currentMask)
        {
            foreach (var maskItem in currentMask)
            {
                bits[35 - maskItem.Key] = CalculateValue(bits[35-maskItem.Key], maskItem.Value);
            }

            return bits;
        }

        private int CalculateValue(int currentValue, int maskValue)
        {
            if(maskValue == -1)
            {
                return -1;
            }
            if(maskValue == 0)
            {
                return currentValue;
            }
            return maskValue;
        }
    }
}

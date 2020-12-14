using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day14
{
    public class ProgramReader
    {
        public static List<IProgramLine> Read(List<string> input)
        {
            {
                var result = new List<IProgramLine>();

                foreach (var inp in input)
                {
                    if (inp.StartsWith("mask"))
                    {
                        var data = inp[7..];
                        var mask = new List<KeyValuePair<int, int>>();
                        for (var i = 35; i >= 0; --i)
                        {
                            if (data[i] != 'X')
                            {
                                mask.Add(new KeyValuePair<int, int>(35 - i, int.Parse(data[i].ToString())));
                            }
                            else
                            {
                                mask.Add(new KeyValuePair<int, int>(35 - i, -1));
                            }
                        }
                        result.Add(new MaskLine { Mask = mask });
                    }
                    else if (inp.StartsWith("mem"))
                    {
                        var data = inp.Split(" = ");
                        data[0] = data[0].Replace("mem", "").Replace("[", "").Replace("]", "");
                        result.Add(new MemoryLine { Position = long.Parse(data[0]), InputValue = long.Parse(data[1]) });
                    } else
                    {
                        Console.WriteLine(inp);
                    }
                }

                return result;
            }
        }
    }
}

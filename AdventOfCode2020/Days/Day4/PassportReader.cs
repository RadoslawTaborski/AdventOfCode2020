using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day4
{
    public class PassportReader
    {
        public Passport Read(List<string> input)
        {
            var data = new Dictionary<string, string>();

            foreach(var line in input)
            {
                var keyValuePairs = line.Split(" ");

                foreach(var keyValue in keyValuePairs)
                {
                    var val = keyValue.Split(":");
                    data.Add(val[0], val[1]);
                }
            }

            return new Passport
            {
                Data = data
            };
        }
    }
}

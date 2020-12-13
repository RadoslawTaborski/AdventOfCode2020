using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    public class BusCreator : IBusCreator
    {
        public List<Bus> Create(string input)
        {
            var result = new List<Bus>();
            var parts = input.Split(',');

            var counter = 0;
            foreach (var part in parts)
            {
                if (part != "x")
                {
                    result.Add(new Bus
                    {
                        Id = part,
                        Span = int.Parse(part),
                        Offset = counter
                    });
                }
                counter++;
            }
            return result;
        }
    }
}

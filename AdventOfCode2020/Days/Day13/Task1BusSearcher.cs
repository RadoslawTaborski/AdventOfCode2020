using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    public class Task1BusSearcher : IBusSearcher
    {
        public (Bus bus, int span) GetBus(List<Bus> buses, int earliestDepartTime)
        {
            var list = new List<KeyValuePair<Bus,int>>();
            foreach(var bus in buses)
            {
                list.Add(new KeyValuePair<Bus, int>(bus, GetNextBus(bus, earliestDepartTime)));
            }

            var sorted = list.OrderBy(x => x.Value);
            var result = sorted.First();

            return (result.Key, result.Value);
        }

        private int GetNextBus(Bus bus, int earliestDepartTime)
        {
            int busValue = bus.Span;
            int passengerValue = earliestDepartTime;

            var rest = passengerValue % busValue;

            return passengerValue + (busValue - rest);
        }
    }
}

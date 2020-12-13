using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day13
{
    public interface IBusSearcher
    {
        (Bus bus, int span) GetBus(List<Bus> buses, int earliestDepartTime);
    }
}

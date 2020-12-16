using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    public class Ticket
    {
        public List<Field> Fields { get; }

        public Ticket(List<Field> fields)
        {
            this.Fields = fields;
        }
    }
}

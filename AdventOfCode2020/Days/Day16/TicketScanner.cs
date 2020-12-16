using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    public class TicketScanner : ITicketScanner
    {
        public (Dictionary<Ticket, List<Field>> rejected, List<Ticket> correct) Scan(List<Ticket> tickets, List<IValidator> validators)
        {
            var result1 = new Dictionary<Ticket,List<Field>>();
            var result2 = new List<Ticket>();

            foreach (var ticket in tickets)
            {
                var rejected = new List<Field>();
                foreach(var field in ticket.Fields)
                {
                    var flag = false;
                    foreach(var validator in validators)
                    {
                        if (validator.Valid(field))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        rejected.Add(field);
                    }
                }
                if (rejected.Count > 0)
                {
                    result1.Add(ticket, rejected);
                } else
                {
                    result2.Add(ticket);
                }
            }

            return (result1, result2);
        }
    }
}

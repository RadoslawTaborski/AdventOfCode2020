using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day16
{
    public interface ITicketScanner
    {
        (Dictionary<Ticket, List<Field>> rejected, List<Ticket> correct) Scan(List<Ticket> tickets, List<IValidator> validators);
    }
}
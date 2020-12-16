using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    public abstract class Day16 : Puzzle
    {
        private readonly ITicketScanner scanner = new TicketScanner();
        protected override void Result(out string result)
        {
            var input = ReadRows("Input1.txt");

            var (validators, own, tickets) = ReadInput(input);

            var (rejected, correct) = scanner.Scan(tickets, validators);

            result = FindValue(rejected, correct, own, validators);
        }

        protected abstract string FindValue(Dictionary<Ticket, List<Field>> rejected, List<Ticket> correct, Ticket own, List<IValidator> validators);

        private (List<IValidator> validators, Ticket own, List<Ticket> tickets) ReadInput(List<string> input)
        {
            var (validationPart, ownTicket, nearbyTickets) = SplitInput(input);

            var validators = GetValidators(validationPart);
            var own = GetTicket(ownTicket);
            var tickets = GetTickets(nearbyTickets);

            return (validators, own, tickets);
        }

        private (List<string> validationPart, List<string> ownTicket, List<string> nearbyTickets) SplitInput(List<string> input)
        {
            var index = input.IndexOf("");
            var valid = input.GetRange(0, index);

            var input2 = input.GetRange(index + 1, input.Count - index - 1);
            var index2 = input2.IndexOf("");
            var own = input2.GetRange(0, index2);

            var tickets = input2.GetRange(index2 + 1, input2.Count - index2 - 1);

            return (valid, own, tickets);
        }

        private List<Ticket> GetTickets(List<string> nearbyTickets)
        {
            var result = new List<Ticket>();
            foreach(var inp in nearbyTickets.Skip(1))
            {
                result.Add(CreateTicketFromLine(inp));
            }
            return result;
        }

        private Ticket GetTicket(List<string> ownTicket)
        {
            return CreateTicketFromLine(ownTicket[1]);
        }

        private Ticket CreateTicketFromLine(string input)
        {
            List<Field> fields = new List<Field>();
            var val = input.Split(",").Select(x => int.Parse(x)).ToList();

            var counter = 0;
            foreach (var v in val)
            {
                fields.Add(new Field(counter, v));
                counter++;
            }

            return new Ticket(fields);
        }

        private List<IValidator> GetValidators(List<string> validationPart)
        {
            var result = new List<IValidator>();

            foreach(var inp in validationPart)
            {
                result.Add(CreateValidator(inp));
            }

            return result;
        }

        private IValidator CreateValidator(string inp)
        {
            var splited1 = inp.Split(": ");
            var name = splited1[0];
            var splited2 = splited1[1].Split(" or ");

            var innerValidators = new List<IValidator>();
            foreach(var part in splited2)
            {
                var splited3 = part.Split("-");
                var min = int.Parse(splited3[0]);
                var max = int.Parse(splited3[1]);

                innerValidators.Add(new RangeValidator(min, max));
            }

            return new MultiValidator(name, innerValidators);
        }
    }
}

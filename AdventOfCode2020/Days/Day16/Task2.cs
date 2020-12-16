using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    [Puzzle(16, 2)]
    public class Task2 : Day16
    {
        protected override string FindValue(Dictionary<Ticket, List<Field>> rejected, List<Ticket> correct, Ticket own, List<IValidator> validators)
        {
            List<KeyValuePair<int, IValidator>> allPossibilities = AllPossibilities(correct, validators);

            var validatorsInOrder = FindOnlyOneCorrectOrder(allPossibilities);

            var onlyDeparturesData = validatorsInOrder.Where(x => ((MultiValidator)x.Value).Name.StartsWith("departure")).ToList();

            var multiply = 1L;

            foreach (var item in onlyDeparturesData)
            {
                multiply *= own.Fields.ElementAt(item.Key).Value;
            }

            return $"{multiply}";
        }

        private static List<KeyValuePair<int, IValidator>> AllPossibilities(List<Ticket> correct, List<IValidator> validators)
        {
            var validatorsWithColumn = new List<KeyValuePair<int, IValidator>>();
            for (var i = 0; i < validators.Count; ++i)
            {
                var fields = correct.Select(x => x.Fields[i]).ToList();

                foreach (var validator in validators)
                {
                    var allIsOk = true;
                    foreach (var field in fields)
                    {
                        allIsOk &= validator.Valid(field);
                    }
                    if (allIsOk)
                    {
                        validatorsWithColumn.Add(new KeyValuePair<int, IValidator>(i, validator));
                    }
                }
            }

            return validatorsWithColumn;
        }

        private Dictionary<int, IValidator> FindOnlyOneCorrectOrder(List<KeyValuePair<int, IValidator>> validatorsWithColumn)
        {
            var result = new Dictionary<int, IValidator>();

            var conflicts = new List<KeyValuePair<int, IValidator>>();

            foreach (var inp in validatorsWithColumn)
            {
                if (validatorsWithColumn.Where(x => x.Key == inp.Key).Count() == 1)
                {
                    result.Add(inp.Key, inp.Value);
                }
                else
                {
                    conflicts.Add(inp);
                }
            }

            while(ResolvingConflicts(result, conflicts).Count>0);

            return result;
        }

        private List<KeyValuePair<int, IValidator>> ResolvingConflicts(Dictionary<int, IValidator> memory, List<KeyValuePair<int, IValidator>> input)
        {
            var toCheck = new List<KeyValuePair<int, IValidator>>();
            var conflict = new List<KeyValuePair<int, IValidator>>();

            foreach (var inp in input)
            {
                if (!memory.ContainsValue(inp.Value))
                {
                    toCheck.Add(inp);
                }
            }
            foreach (var inp in toCheck)
            {
                if (toCheck.Where(x => x.Key == inp.Key).Count() == 1)
                {
                    memory.Add(inp.Key, inp.Value);
                }
                else
                {
                    conflict.Add(inp);
                }
            }

            return conflict;
        }
    }
}

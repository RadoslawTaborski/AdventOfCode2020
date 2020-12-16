using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    public class MultiValidator : IValidator
    {
        public string Name { get; }
        private readonly List<IValidator> validators;

        public MultiValidator(string name, List<IValidator> validators)
        {
            Name = name;
            this.validators = validators;
        }

        public bool Valid(Field field)
        {
            var result = false;

            foreach(var validator in validators)
            {
                result |= validator.Valid(field);
            }

            return result;
        }
    }
}

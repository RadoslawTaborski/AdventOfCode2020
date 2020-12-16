using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day16
{
    public class RangeValidator : IValidator
    {
        private int min;
        private int max;

        public RangeValidator(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public bool Valid(Field field)
        {
            if(field.Value <= max && field.Value >= min)
            {
                return true;
            }
            return false;
        }
    }
}

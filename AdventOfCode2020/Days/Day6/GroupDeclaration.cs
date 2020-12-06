using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day6
{
    public class GroupDeclaration
    {
        public List<PersonDeclaration> Declarations { get; } = new List<PersonDeclaration>();

        public void AddPersonDeclaration(PersonDeclaration declaration)
        {
            Declarations.Add(declaration);
        }
    }
}

using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day06
{
    [Puzzle(6, 2)]
    public class Task2 : Day06
    {
        protected override void GetAnswer(List<GroupDeclaration> groupDeclarations, out string result)
        {
            var counter = 0;
            foreach (var groupDeclaration in groupDeclarations)
            {
                counter += GetAnswers(groupDeclaration).Count();
            }

            result = $"{counter}";
        }

        private List<Question> GetAnswers(GroupDeclaration groupDeclaration)
        {
            var result = new List<Question>(groupDeclaration.Declarations[0].Questions);

            foreach (var declaration in groupDeclaration.Declarations.Skip(1))
            {
                result = result.Intersect(declaration.Questions).ToList();
            }

            return result;
        }
    }
}

using AdventOfCode2020.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day06
{
    [Puzzle(6)]
    public class Task1 : Day06
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

        private HashSet<Question> GetAnswers(GroupDeclaration groupDeclaration)
        {
            var result = new HashSet<Question>();

            foreach (var declaration in groupDeclaration.Declarations)
            {
                result.UnionWith(declaration.Questions.Where(x => x.Answer == true));
            }

            return result;
        }
    }
}

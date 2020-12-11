using AdventOfCode2020.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days.Day06
{
    public abstract class Day06 : Puzzle
    {
        protected abstract void GetAnswer(List<GroupDeclaration> groupDeclarations, out string result);

        protected override void Result(out string result)
        {
            var input = ReadRows($"Input1.txt");
            var groups = ReadParts(input);
            var groupDeclarations = CreateGroupsDeclarations(groups);

            GetAnswer(groupDeclarations, out result);      
        }

        private List<GroupDeclaration> CreateGroupsDeclarations(List<List<string>> groups)
        {
            var groupDeclarations = new List<GroupDeclaration>();

            foreach(var group in groups)
            {
                var groupDeclaration = new GroupDeclaration();
                foreach(var person in group)
                {
                    var personDeclaration = new PersonDeclaration();
                    foreach(var question in person)
                    {
                        personDeclaration.AddQuestion(question.ToString(), true);
                    }
                    groupDeclaration.AddPersonDeclaration(personDeclaration);
                }
                groupDeclarations.Add(groupDeclaration);
            }

            return groupDeclarations;
        }
    }
}

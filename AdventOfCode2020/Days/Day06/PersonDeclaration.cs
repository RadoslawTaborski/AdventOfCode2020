using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day06
{
    public class PersonDeclaration
    {
        public List<Question> Questions { get; } = new List<Question>();

        public void AddQuestion(string name, bool answer)
        {
            Questions.Add(new Question
            {
                Name = name,
                Answer = answer
            });
        }
    }
}
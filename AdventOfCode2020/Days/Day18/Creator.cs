using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day18
{
    public abstract class Creator : ICreator
    {
        public IOperation Create(string input)
        {
            input = input.Replace(" ", "");
            var parts = CreateParts(input);

            var newInputs = new List<string>();
            var operators = new List<Operator>();

            foreach (var part in parts)
            {
                var splited = GetOperator(part);
                if (splited.str.Trim() != "")
                {
                    newInputs.Add(splited.str);
                }
                operators.AddRange(splited.op);
            }

            return CreateOperation(newInputs, operators);
        }

        private static List<string> SimpleOperationSplit(string input)
        {
            var result = new List<string>();

            var chars = new[] { (char)Operator.Multiplication, (char)Operator.Addition };
            var str = input;
            var idx = input.IndexOfAny(chars);
            while (idx != -1)
            {
                result.Add(str.Substring(0, idx + 1));
                str = str[(idx + 1)..];
                idx = str.IndexOfAny(chars);
            }

            if (str.Trim() != "")
            {
                result.Add(str);
            }

            return result;
        }

        protected abstract IOperation CreateOperation(List<string> newInputs, List<Operator> operators);

        protected Operation MergeOperations(IOperation a, IOperation b, Operator op)
        {
            return new Operation
            {
                Operator = op,
                Values = new List<IOperation>
                {
                    a, b
                }
            };
        }

        protected IOperation CreateChild(string input)
        {
            if (input.Contains((char)Operator.Addition) || input.Contains((char)Operator.Multiplication))
            {
                return Create(input);
            }
            else
            {
                return new OperationLeaf { Value = int.Parse(input) };
            }
        }

        private static (List<Operator> op, string str) GetOperator(string v)
        {
            var operators = new List<Operator>();
            var str = v;
            if (v[0] == (char)Operator.Multiplication || v[0] == (char)Operator.Addition)
            {
                operators.Add((Operator)v[0]);
                str = v[1..];
            }
            if (str.Trim() != "")
            {
                if (str[^1] == (char)Operator.Multiplication || str[^1] == (char)Operator.Addition)
                {
                    operators.Add((Operator)str[^1]);
                    str = str[0..^1];
                }
            }

            return (operators, str);
        }

        private static List<string> CreateParts(string input)
        {
            var parts = new List<string>();

            if (input.Trim().Length == 0)
            {
                return parts;
            }
            var (start, end) = GetParthesisIndexes(input);

            if (start == -1 || end == -1)
            {
                parts.AddRange(SimpleOperationSplit(input));
            }
            else
            {
                if (start != 0)
                {
                    parts.AddRange(CreateParts(input.Substring(0, start)));
                }
                parts.Add(input.Substring(start + 1, end - start - 1));
                parts.AddRange(CreateParts(input.Substring(end + 1)));
            }
            return parts;
        }

        private static (int start, int end) GetParthesisIndexes(string input)
        {
            var start = input.IndexOf('(');
            var end = -1;
            if (start != -1)
            {
                var subinp1 = input.Substring(start);
                var counter = 0;
                for (var i = 1; i < subinp1.Length; ++i)
                {
                    if (subinp1[i] == '(')
                    {
                        counter++;
                    }
                    if (subinp1[i] == ')' && counter == 0)
                    {
                        end = start + i;
                    }
                    else if (subinp1[i] == ')')
                    {
                        counter--;
                    }
                }
            }

            return (start, end);
        }
    }
}

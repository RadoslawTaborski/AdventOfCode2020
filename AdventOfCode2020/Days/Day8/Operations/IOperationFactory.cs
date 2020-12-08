namespace AdventOfCode2020.Days.Day8.Operations
{
    public interface IOperationFactory
    {
        IOperation Create(string line);
    }
}
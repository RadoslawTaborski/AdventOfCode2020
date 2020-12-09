namespace AdventOfCode2020.Days.Day08.Operations
{
    public interface IOperationFactory
    {
        IOperation Create(string line);
    }
}
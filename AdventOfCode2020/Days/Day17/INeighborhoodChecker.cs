namespace AdventOfCode2020.Days.Day17
{
    public interface INeighborhoodChecker
    {
        public int Check(ref ICube input, params long[] dim);
    }
}
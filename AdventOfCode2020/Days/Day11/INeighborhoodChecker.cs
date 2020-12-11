namespace AdventOfCode2020.Days.Day11
{
    public interface INeighborhoodChecker
    {
        public int Check(ref Area input, int y, int x);
    }
}
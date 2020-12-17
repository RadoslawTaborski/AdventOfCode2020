namespace AdventOfCode2020.Days.Day17.Puzzle2
{
    internal class NeighborhoodChecker : INeighborhoodChecker
    {
        public int Check(ref ICube input, params long[] dim)
        {
            var result = 0;
            for (var i = -1; i <= 1; ++i)
            {
                for (var j = -1; j <= 1; ++j)
                {
                    for (var k = -1; k <= 1; ++k)
                    {
                        for (var l = -1; l <= 1; ++l)
                        {
                            if (i == 0 && j == 0 && k == 0 && l ==0)
                            {
                                continue;
                            }
                            var value = input.GetValue(dim[0] + i, dim[1] + j, dim[2] + k, dim[3]+l);
                            if (value == CellState.Active)
                            {
                                result++;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
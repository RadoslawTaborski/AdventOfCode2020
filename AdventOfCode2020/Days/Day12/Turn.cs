namespace AdventOfCode2020.Days.Day12
{
    public enum Turn
    {
        Up = 0,
        Right = 90,
        Down = 180,
        Left = 270
    }

    public static class TurnExtensions
    {
        public static Turn CalculateTurn(this Turn turn, Rotation rotation)
        {
            var value = (int)turn;
            if (rotation.Turn == Turn.Left)
            {
                value -= rotation.Value;
            }
            if(rotation.Turn == Turn.Right)
            {
                value += rotation.Value;
            }

            while (value < 0)
            {
                value += 360;
            }

            return (Turn)(value % 360);
        }
    }
}

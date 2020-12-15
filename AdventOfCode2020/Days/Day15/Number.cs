namespace AdventOfCode2020.Days.Day15
{
    public class Number
    {
        public long Value { get; init; }
        public long LastIndex { get; private set; }
        public long PreviousIndex { get; private set; }

        public Number(long value, long lastIndex)
        {
            Value = value;
            LastIndex = lastIndex;
            PreviousIndex = 0;
        }

        public Number Update(long nextIndex)
        {
            PreviousIndex = LastIndex;
            LastIndex = nextIndex;

            return this;
        }
    }
}

namespace MissingNumber.Context
{
    public class NumberSequenceContext
    {
        public int[] Numbers { get; }
        public int Min => Numbers.Min();
        public int Max => Numbers.Max();
        public int Length => Numbers.Length;

        public NumberSequenceContext(int[] numbers)
        {
            Numbers = numbers ?? throw new ArgumentNullException(nameof(numbers));
        }
    }
}
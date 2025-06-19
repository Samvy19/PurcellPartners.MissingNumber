using MissingNumber.Context;

namespace MissingNumber.Services
{
    public interface IValidationService
    {
        bool HasValidLength(NumberSequenceContext context);
        bool HasMissingNumber(NumberSequenceContext context);
        bool HasDuplicates(NumberSequenceContext context);
        bool HasSequence(NumberSequenceContext context);
        bool HasNegativeNumbers(NumberSequenceContext context);
    }

    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Validates the input array for missing number calculation.
        /// </summary>
        /// <param name="numbers">An array of integers representing the sequence.</param>
        /// <returns>True if valid, otherwise false.</returns>
        /// 
        public bool HasValidLength(NumberSequenceContext context)
        => context.Numbers != null && context.Length >= 2;
        public bool HasMissingNumber(NumberSequenceContext context)
        {
            int min = context.Min;
            int max = context.Max;
            int length = context.Length;

            if (min == 0 && length == max - min + 1)
                return false;

            else
                return true;
        }
        public bool HasDuplicates(NumberSequenceContext context)
        => context.Numbers.Distinct().Count() != context.Length;

        public bool HasSequence(NumberSequenceContext context)
        {
            var sorted = context.Numbers.OrderBy(n => n).ToArray();
            int countDiffTwo = 0;

            for (int i = 1; i < sorted.Length; i++)
            {
                int diff = sorted[i] - sorted[i - 1];
                if (diff == 2) countDiffTwo++;
                else if (diff != 1) return false;
            }

            return countDiffTwo <= 1;
        }
        public bool HasNegativeNumbers(NumberSequenceContext context)
        => context.Numbers.Any(n => n < 0);
    }
}

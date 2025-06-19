using MissingNumber.Context;

namespace MissingNumber.Services
{
    public interface ICalculationService
    {
        /// <summary>
        /// Calculates the missing number in a sequence.
        /// </summary>
        /// <param name="numbers">An array of integers representing the sequence.</param>
        /// <returns>The missing number if found, otherwise -1.</returns>
        string CalculateMissingNumber(int[] numbers);
    }

    public class CalculationService : ICalculationService
    {
        private readonly IValidationService _validation;

        public CalculationService(IValidationService validation)
        {
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }
        /// <summary>
        /// Calculates the missing number in a sequence.
        /// </summary>
        /// <param name="numbers">An array of integers representing the sequence.</param>
        /// <returns>The missing number </returns>
        public string CalculateMissingNumber(int[] numbers)
        {
            var context = new NumberSequenceContext(numbers);

            if (!_validation.HasValidLength(context))
                return "Invalid input: Array must have at least two elements.";

            if (_validation.HasNegativeNumbers(context))
                return "Invalid input: Array contains negative numbers.";

            if (_validation.HasDuplicates(context))
                return "Invalid input: Array contains duplicate numbers.";

            if (!_validation.HasMissingNumber(context))
                return "No missing number found in the sequence.";

            if(!_validation.HasSequence(context))
                return "Invalid input: Array is not a valid sequence.";

            int n = context.Max; 
            int expectedSum = n * (n + 1) / 2;
            int actualSum = numbers.Sum(); 
            int missingNumber = expectedSum - actualSum; 
            return missingNumber.ToString(); 
        }
    }
}

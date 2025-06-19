using MissingNumber.Services;
using NUnit.Framework;


namespace UnitTests.MissingNumberTests
{
    [TestFixture]
    public class MissingNumberCalculationTests
    {
        private IValidationService _validation;
        private ICalculationService _calculation;

        [SetUp]
        public void Setup()
        {
            _validation = new ValidationService();
            _calculation = new CalculationService(_validation);
        }

        [TestCase(new int[] { 0, 1, 3, 4 }, "2")]
        [TestCase(new int[] { 1, 2, 3, 5, 0 }, "4")]
        [TestCase(new int[] { 0, 2 }, "1")]
        [TestCase(new int[] { 1, 2, 3, 4 }, "0")]
        public void CalculateMissingNumber_ValidCases_ReturnsMissingNumber(int[] input, string expected)
        {
            Assert.That(_calculation.CalculateMissingNumber(input), Is.EqualTo(expected));
        }

        [TestCase(new int[] { }, "Invalid input: Array must have at least two elements.")]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, "No missing number found in the sequence.")]
        [TestCase(new int[] { 0, 1, 1, 3 }, "Invalid input: Array contains duplicate numbers.")]
        [TestCase(new int[] { 0, 1, -2, 3 }, "Invalid input: Array contains negative numbers.")]
        [TestCase(new int[] { 0, 1, 4, 5 }, "Invalid input: Array is not a valid sequence.")]
        [TestCase(new int[] { 2, 4, 6, 8 }, "Invalid input: Array is not a valid sequence.")]
        [TestCase(new int[] { 0, 2, 4, 6 }, "Invalid input: Array is not a valid sequence.")]
        public void CalculateMissingNumber_InvalidCases_ReturnsErrorMessage(int[] input, string expected)
        {
            Assert.That(_calculation.CalculateMissingNumber(input), Is.EqualTo(expected));
        }

        // Edge case: more than one missing number
        [Test]
        public void CalculateMissingNumber_MoreThanOneMissing_ReturnsInvalidSequence()
        {
            int[] input = { 0, 1, 4, 5 }; // missing 2 and 3
            string expected = "Invalid input: Array is not a valid sequence.";
            Assert.That(_calculation.CalculateMissingNumber(input), Is.EqualTo(expected));
        }
    }
}
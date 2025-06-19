using MissingNumber.Services;

public class Program
{
    public static void Main()
    {
        int[] input = { 2, 6, 1, 3, 4, 5, 8, 0}; // Example: missing number is 2

        IValidationService validation = new ValidationService();
        ICalculationService calculation = new CalculationService(validation);

        string result = calculation.CalculateMissingNumber(input);

        Console.WriteLine($"Result: {result}");
    }
}
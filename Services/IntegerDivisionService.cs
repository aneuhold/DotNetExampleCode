namespace DotNetExampleCode.Services;

internal class IntegerDivisionService
{
    /// <summary>
    /// Prints all even numbers to the console between 2 and the highest parameter value (inclusive)
    /// which is EVENLY divisible by the lowest parameter value.
    /// This will be printed wiht comma delimiters and sorted by lower -> higher numbers
    /// </summary>
    private void PrintEvenNumbers(int int1, int int2)
    {
        // Check for integers that are out of bounds.
        if (int1 < 2 || int2 < 2)
        {
            // Would ideally throw an error here, but that was not part of the instructions.
        }

        var higherValue = Math.Max(int1, int2);
        var lowerValue = Math.Min(int1, int2);

        List<int> evenlyDivisibleNumbers = [];

        for (var i = higherValue; i >= lowerValue; i--)
        {
            // Skip if not even
            if (i % 2 != 0)
            {
                continue;
            }

            if (i % lowerValue == 0)
            {
                // Use insert, so that the lower numbers are at the beginning of the list
                evenlyDivisibleNumbers.Insert(index: 0, i);
            }
        }

        Console.WriteLine(string.Join(", ", evenlyDivisibleNumbers));
    }
}
using StringHelpers.Exceptions;

namespace StringHelpers;

// I have opted to make this static as it makes sense - thus no interface etc. attached to it
public static class StringCalculator
{
    private const string DelimiterSectionSearchStart = "//";
    private const string DelimiterSectionSearchEnd = "\n";

    // Could make both of these char but for consistency, and to potentially allow larger "wrappers", I left them as string
    private const string DelimiterWrapperLeft = "[";
    private const string DelimiterWrapperRight = "]";
    private const int MaximumValidNumber = 1000;

    public static int Add(string inputString)
    {
        return ExtractNumbersFromInput(inputString).Sum();
    }

    private static int[] ExtractNumbersFromInput(string inputString)
    {
        if (inputString.Length == 0)
        {
            return [];
        }

        // Generally I would prefer to move this stuff into a method of its own, but with the length calculation
        // it all landed here. I've spent a while on this already but with some more time I'd move this out and tweak
        // it so we can perform our string length calculations a bit more cleanly
        
        // Our default delimiters
        var delimiters = new[] { ",", "\n" };
        
        // Take the string between the first // and first \n
        var delimiterInput = ExtractStringBetweenTwoStrings(
            inputString,
            DelimiterSectionSearchStart,
            DelimiterSectionSearchEnd
        );
        
        // Assuming we have some result from the extraction
        if (delimiterInput != string.Empty)
        {
            // Let's split them ([this][and][that] are valid)
            var extraDelimiters = SplitDelimiters(delimiterInput);
            
            // Add each one to the array with the defaults
            delimiters = delimiters.Concat(extraDelimiters).ToArray();
        }

        // Now our delimiter input with the length of // and \n (consts in case we ever wanted to change 'em)
        var numbersPosition = DelimiterSectionSearchStart.Length +
                              DelimiterSectionSearchEnd.Length +
                              delimiterInput.Length;

        // If we have delimiters, start after the \n
        var numberInput = delimiterInput != string.Empty
            ? inputString[numbersPosition..]
            : inputString;

        // And finally split our numbers string with the array of delimiters, whilst also removing empty ones
        // and ones above 1000
        var numbers = numberInput
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(i => i <= MaximumValidNumber)
            .ToArray();

        // Throw our exception if we have any negatives
        ThrowIfNegativeNumbersFound(numbers);

        return numbers;
    }

    private static void ThrowIfNegativeNumbersFound(IEnumerable<int> numbers)
    {
        // Where & check the results instead of Any() -> Where() to save enumerating multiple times
        var negativeNumbers = numbers.Where(i => i < 0).ToArray();
        if (negativeNumbers.Length > 0)
        {
            var message = $"Input string contains negative numbers: {
                string.Join(", ", negativeNumbers)
            }.";
            throw new NegativeNumberFoundException(message);
        }
    }

    private static string ExtractStringBetweenTwoStrings(string inputString, string leftString, string rightString)
    {
        var leftPosition = inputString.IndexOf(leftString, StringComparison.Ordinal);
        var rightPosition = inputString.IndexOf(rightString, StringComparison.Ordinal);

        if (leftPosition == -1)
        {
            return string.Empty;
        }

        leftPosition += leftString.Length;
        return inputString[leftPosition..rightPosition];
    }
    
    private static List<string> SplitDelimiters(string delimitersInput)
    {
        var results = new List<string>();

        // Get every index of `[` and `]` in the delimiter input
        var lefts = GetAllIndexesOf(delimitersInput, DelimiterWrapperLeft);
        var rights = GetAllIndexesOf(delimitersInput, DelimiterWrapperRight);

        // If it's not formatted correctly, we'll have an uneven number
        if (lefts.Count != rights.Count)
        {
            throw new InvalidDelimiterFormatException();
        }
        
        // No delimiters so just return the empty list
        if (lefts.Count == 0 && rights.Count == 0)
        {
            results.Add(delimitersInput);
            return results;
        }

        // Now for each set of delimiters we take the string between 'em
        for (var i = 0; i < lefts.Count; i++)
        {
            var leftPosition = lefts[i];
            var rightPosition = rights[i];

            results.Add(
                delimitersInput.Substring(
                    leftPosition + DelimiterWrapperLeft.Length,
                    rightPosition - leftPosition - DelimiterWrapperRight.Length
                )
            );
        }

        return results;
    }

    private static List<int> GetAllIndexesOf(string inputString, string delimiter)
    {
        var indexes = new List<int>();

        // Handily for us, IndexOf returns -1 when nothing is found, so this loop is nice and easy
        for (
            var i = inputString.IndexOf(delimiter, StringComparison.Ordinal);
            i > -1;
            i = inputString.IndexOf(delimiter, i + delimiter.Length, StringComparison.Ordinal)
        )
        {
            indexes.Add(i);
        }

        return indexes;
    }
}
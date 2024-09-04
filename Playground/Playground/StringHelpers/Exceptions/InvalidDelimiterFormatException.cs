namespace StringHelpers.Exceptions;

public class InvalidDelimiterFormatException : Exception
{
    public InvalidDelimiterFormatException()
    {
    }

    public InvalidDelimiterFormatException(string message) : base(message)
    {
    }

    public InvalidDelimiterFormatException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
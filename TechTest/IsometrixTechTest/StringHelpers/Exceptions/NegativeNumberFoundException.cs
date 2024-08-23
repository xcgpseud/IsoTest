namespace StringHelpers.Exceptions;

public class NegativeNumberFoundException : Exception
{
    public NegativeNumberFoundException()
    {
    }

    public NegativeNumberFoundException(string message) : base(message)
    {
    }

    public NegativeNumberFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
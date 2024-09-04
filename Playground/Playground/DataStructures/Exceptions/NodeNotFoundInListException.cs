namespace DataStructures.Exceptions;

public class NodeNotFoundInListException : Exception
{
    public NodeNotFoundInListException()
    {
    }

    public NodeNotFoundInListException(string message) : base(message)
    {
    }

    public NodeNotFoundInListException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
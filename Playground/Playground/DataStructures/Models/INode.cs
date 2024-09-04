namespace DataStructures.Models;

public interface INode<T>
{
    public T? Value { get; set; }

    public INode<T>? NextNode { get; set; }
}
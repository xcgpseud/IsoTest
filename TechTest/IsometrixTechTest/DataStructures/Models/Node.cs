namespace DataStructures.Models;

public class Node<T> : INode<T>
{
    public T? Value { get; set; }

    public INode<T>? NextNode { get; set; }
}
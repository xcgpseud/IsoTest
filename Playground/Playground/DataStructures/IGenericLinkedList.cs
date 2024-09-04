using DataStructures.Models;

namespace DataStructures;

public interface IGenericLinkedList<T>
{
    public INode<T> GetHeadNode();

    public INode<T> Insert(INode<T> nodeToInsertAt, T newNodeValue);

    public INode<T> Insert(int position, T newNodeValue);

    public INode<T> Append(T newNodeValue);

    // Deletes the given node and bridges the gap
    public void Delete(INode<T> nodeToDelete);

    // Maps the function to every value and returns a new list
    public IGenericLinkedList<T> Map(Func<T?, T?> mapFunction);

    // I have decided to make this return a string rather than print directly to the console
    public string PrintList();
}
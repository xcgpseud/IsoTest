using DataStructures.Exceptions;
using DataStructures.Models;

namespace DataStructures;

// Named it this simply to not conflict with the default LinkedList
public class GenericLinkedList<T> : IGenericLinkedList<T>
{
    private GenericLinkedList(INode<T> headNode)
    {
        HeadNode = headNode;
    }

    private INode<T> HeadNode { get; set; }

    public static IGenericLinkedList<T> Create(T value)
    {
        var node = new Node<T>
        {
            Value = value,
        };

        return new GenericLinkedList<T>(node);
    }

    public static IGenericLinkedList<T> Create()
    {
        return new GenericLinkedList<T>(new Node<T>());
    }

    public INode<T> GetHeadNode()
    {
        return HeadNode;
    }

    public INode<T> Insert(INode<T> nodeToInsertAfter, T newNodeValue)
    {
        var newNode = new Node<T>
        {
            Value = newNodeValue,
            NextNode = nodeToInsertAfter.NextNode,
        };
        nodeToInsertAfter.NextNode = newNode;

        return newNode;
    }

    // The spec said "Insert" should just insert at any position, but I thought realistically an Insert with Append
    // behaviour might also be nice
    public INode<T> Insert(T newNodeValue)
    {
        var last = GetHeadNode();
        while (last.NextNode != null)
        {
            last = last.NextNode;
        }
        
        var newNode = new Node<T> { Value = newNodeValue };
        last.NextNode = newNode;

        return newNode;
    }

    public void Delete(INode<T> nodeToDelete)
    {
        var currentNode = GetHeadNode();

        // If we're deleting the head node
        if (currentNode == nodeToDelete)
        {
            // Set the head node to the one AFTER deletion (or an empty node if that has null as NextNode)
            HeadNode = nodeToDelete.NextNode ?? new Node<T>();
            return;
        }

        // Go until our next node is the one we're deleting (i.e. we have the previous node)
        while (currentNode?.NextNode != nodeToDelete)
        {
            // If NextNode ends up being null, we coalesce into an Exception as we know
            // our node doesn't exist in the list at this point
            currentNode = currentNode?.NextNode ?? throw new NodeNotFoundInListException();
        }

        // And now we simply set the previous node's next node to the one after the deleted one
        currentNode.NextNode = nodeToDelete.NextNode;
    }

    public string PrintList()
    {
        var currentNode = GetHeadNode();
        var response = "";
        
        // We have nothing in this list at all
        if (currentNode.Value == null && currentNode.NextNode == null)
        {
            // It felt better to stick with an empty string and not return "null" in the case of null non-string objects
            return "";
        }

        // Traverse through nodes and add their value with a delimiter to the string
        while (currentNode.NextNode != null)
        {
            response += $"{currentNode.Value} -> ";
            currentNode = currentNode.NextNode;
        }

        // Last one is left off due to the nature of our while loop, but this actually serves us well as there is no
        // need for a check to see if the next one exists. We can just add it without the delimiter.
        response += currentNode.Value;

        return response;
        
        // (Alternatively you could loop values, add them to a list and then string.Join the list, but you iterate
        // twice which feels wasteful)
    }
}
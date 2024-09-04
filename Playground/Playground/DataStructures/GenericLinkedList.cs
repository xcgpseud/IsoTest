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

    public INode<T> Insert(INode<T> nodeToInsertAt, T newNodeValue)
    {
        // Due to the nature of a linked list we need to iterate to the previous node
        var currentNode = GetHeadNode();
        if (currentNode == nodeToInsertAt)
        {
            return HeadNode = new Node<T>
            {
                Value = newNodeValue,
                NextNode = currentNode,
            };
        }

        while (currentNode.NextNode != null && currentNode.NextNode != nodeToInsertAt)
        {
            currentNode = currentNode.NextNode;
        }

        if (currentNode.NextNode == null && currentNode != nodeToInsertAt)
        {
            throw new NodeNotFoundInListException();
        }

        var newNode = new Node<T>
        {
            Value = newNodeValue,
            NextNode = currentNode.NextNode,
        };
        
        currentNode.NextNode = newNode;

        return newNode;
    }

    public INode<T> Insert(int position, T newNodeValue)
    {
        var newNode = new Node<T>
        {
            Value = newNodeValue,
        };

        if (position == 0)
        {
            newNode.NextNode = GetHeadNode();
            HeadNode = newNode;

            return newNode;
        }

        var nodeAtPosition = GetNodeAtPosition(position - 1);
        newNode.NextNode = nodeAtPosition.NextNode;
        nodeAtPosition.NextNode = newNode;

        return newNode;
    }

    public INode<T> Append(T newNodeValue)
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

        if (currentNode == nodeToDelete)
        {
            HeadNode = nodeToDelete.NextNode ?? new Node<T>();
            return;
        }

        while (currentNode.NextNode != nodeToDelete)
        {
            currentNode = currentNode?.NextNode ?? throw new NodeNotFoundInListException();
        }

        currentNode.NextNode = nodeToDelete.NextNode;
    }

    public IGenericLinkedList<T> Map(Func<T?, T?> mapFunction)
    {
        var newList = Create();
        var newNode = newList.GetHeadNode();

        for (
            var node = GetHeadNode();
            node != null;
            node = node.NextNode
        )
        {
            if (newNode == null)
            {
                throw new NodeNotFoundInListException();
            }

            newNode.Value = mapFunction(node.Value);
            newNode.NextNode = new Node<T>();
            newNode = newNode.NextNode;
        }

        return newList;
    }

    public string PrintList()
    {
        var currentNode = GetHeadNode();
        var response = "";

        if (currentNode.Value == null && currentNode.NextNode == null)
        {
            return "";
        }

        while (currentNode.NextNode != null)
        {
            response += $"{currentNode.Value} -> ";
            currentNode = currentNode.NextNode;
        }

        response += currentNode.Value;

        return response;
    }

    private INode<T> GetNodeAtPosition(int position)
    {
        var node = GetHeadNode();

        for (var i = 0; i < position; i++)
        {
            node = node?.NextNode;
        }

        if (node == null)
        {
            throw new NodeNotFoundInListException();
        }

        return node;
    }
}
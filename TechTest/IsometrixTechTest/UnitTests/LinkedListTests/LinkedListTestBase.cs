using DataStructures;
using DataStructures.Models;

namespace UnitTests.LinkedListTests;

public class LinkedListTestBase
{
    protected IGenericLinkedList<T> CreateGenericLinkedList<T>(params T[] values)
    {
        var list = GenericLinkedList<T>.Create(values.First());
        var currentHeadNode = list.GetHeadNode();

        // Build the nodes manually, in reverse, to really prove that we're getting exactly what we want with this
        for (var i = 1; i < values.Length; i++)
        {
            // This node will be the next value
            var node = new Node<T>{Value = values[i]};
            
            // Set our next node to this new node
            currentHeadNode.NextNode = node;
            
            // And simply set the current head node to the next one, so it recurses
            currentHeadNode = node;
        }

        // Now we have a clean list with all the passed values, without relying on any of our methods
        return list;
    }
}
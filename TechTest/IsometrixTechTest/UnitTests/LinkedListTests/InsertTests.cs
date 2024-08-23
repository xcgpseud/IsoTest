using NUnit.Framework;
using DataStructures;
using FluentAssertions;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class InsertTests : LinkedListTestBase
{
    [Test]
    public void Insert_OnlySupplyingNewValue_AppendsToList()
    {
        var intList = GenericLinkedList<int>.Create(100);

        var second = intList.Insert(200);
        var third = intList.Insert(300);

        second.Value.Should().Be(200);
        second.NextNode.Should().Be(third);
        
        var headNode = intList.GetHeadNode();
        headNode.Value.Should().Be(100);
        headNode.NextNode?.Value.Should().Be(200);
        headNode.NextNode?.NextNode?.Value.Should().Be(300);
    }

    [Test]
    public void Insert_SupplyPositionAndNewValue_AppendsAfterGivenNode()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var secondNode = list.GetHeadNode().NextNode;
        secondNode.Should().NotBeNull();

        var newNode = list.Insert(secondNode, 900);
        newNode.Value.Should().Be(900);
        newNode.NextNode?.Value.Should().Be(300);

        // Use the last node as our node to insert after to make sure we can do that too
        list.Insert(newNode.NextNode, 5);
        newNode.NextNode?.NextNode?.Value.Should().Be(5);

        // Do a hard check of the order just to be sure - not super tidy but valuable to know
        list.GetHeadNode().NextNode?.Value.Should().Be(200);
        list.GetHeadNode().NextNode?.NextNode?.Value.Should().Be(900);
        list.GetHeadNode().NextNode?.NextNode?.NextNode?.Value.Should().Be(300);
    }
}
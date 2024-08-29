using DataStructures;
using DataStructures.Exceptions;
using DataStructures.Models;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.Models;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class DeleteTests : LinkedListTestBase
{
    [Test]
    public void Delete_CorrectlyRemovesNodeAtGivenPosition()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var secondNode = list.GetHeadNode().NextNode;
        secondNode.Should().NotBeNull();

        list.Delete(secondNode);

        list.GetHeadNode().Value.Should().Be(100);
        list.GetHeadNode().NextNode?.Value.Should().Be(300);
    }

    [Test]
    public void Delete_HeadNode_WithExistingNextNode_SetsHeadAsNextNode()
    {
        var list = CreateGenericLinkedList(100, 200, 300);
        list.Delete(list.GetHeadNode());

        list.GetHeadNode().Value.Should().Be(200);
        list.GetHeadNode().NextNode?.Value.Should().Be(300);
    }

    [Test]
    public void Delete_HeadNode_WithNoExistingNextNode_SetsHeadAsEmptyNode_WithDefaultValue()
    {
        var intList = CreateGenericLinkedList(100);
        var stringList = CreateGenericLinkedList("hello world");
        var boolList = CreateGenericLinkedList(true);
        var objectList = CreateGenericLinkedList(
            new TestModel
            {
                Id = 1,
                Data = "hello world",
            }
        );

        intList.Delete(intList.GetHeadNode());
        stringList.Delete(stringList.GetHeadNode());
        boolList.Delete(boolList.GetHeadNode());
        objectList.Delete(objectList.GetHeadNode());

        intList.GetHeadNode().Should().BeOfType<Node<int>>();
        intList.GetHeadNode().Value.Should().Be(default);

        stringList.GetHeadNode().Should().BeOfType<Node<string>>();
        stringList.GetHeadNode().Value.Should().Be(default);

        boolList.GetHeadNode().Should().BeOfType<Node<bool>>();
        boolList.GetHeadNode().Value.Should().Be(default);

        objectList.GetHeadNode().Should().BeOfType<Node<TestModel>>();
        objectList.GetHeadNode().Value.Should().Be(default);
    }

    [Test]
    public void Delete_LastNode_CorrectlyRemovesLastNode()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var node = list.GetHeadNode().NextNode?.NextNode;

        node.Should().NotBeNull();

        list.Delete(node);
    }

    [Test]
    public void Delete_OutOfBoundsPosition_ThrowsException()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var newNode = new Node<int> { Value = 400 };

        var action = () => list.Delete(newNode);
        action
            .Should()
            .Throw<NodeNotFoundInListException>();
    }
}
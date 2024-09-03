using NUnit.Framework;
using DataStructures;
using DataStructures.Exceptions;
using FluentAssertions;
using UnitTests.Models;

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
    public void Insert_SupplyNodeAndNewValue_InsertsAfterGivenNode()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(3).SplitIntoTuples();

        var intNode = intList.GetHeadNode().NextNode;
        intNode.Should().NotBeNull();
        intList.Insert(intNode, 1000);

        var stringNode = stringList.GetHeadNode().NextNode;
        stringNode.Should().NotBeNull();
        stringList.Insert(stringNode, "HELLO");

        var boolNode = boolList.GetHeadNode().NextNode;
        boolNode.Should().NotBeNull();
        boolList.Insert(boolNode, true);

        var testModelNode = testModelList.GetHeadNode().NextNode;
        testModelNode.Should().NotBeNull();
        testModelList.Insert(
            testModelNode,
            new TestModel
            {
                Guid = Guid.Empty,
                Data = "HELLO",
            }
        );

        intNode.NextNode?.Value.Should().Be(1000);
        intNode.NextNode?.NextNode?.Value.Should().Be(intValues.ToArray()[2]);

        stringNode.NextNode?.Value.Should().Be("HELLO");
        stringNode.NextNode?.NextNode?.Value.Should().Be(stringValues.ToArray()[2]);
        
        boolNode.NextNode?.Value.Should().Be(true);
        boolNode.NextNode?.NextNode?.Value.Should().Be(boolValues.ToArray()[2]);

        testModelNode.NextNode?.Value.Should().NotBeNull();
        testModelNode.NextNode?.Value?.Guid.Should().Be(Guid.Empty);
        testModelNode.NextNode?.Value?.Data.Should().Be("HELLO");
    }

    [Test]
    public void Insert_SupplyFinalNodeAndNewValue_AppendsToList()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var finalNode = list.GetHeadNode().NextNode?.NextNode;
        finalNode.Should().NotBeNull();

        list.Insert(finalNode, 400);

        list.GetHeadNode().NextNode?.NextNode?.NextNode?.Value.Should().Be(400);
    }

    [Test]
    public void Insert_SupplyPositionAndNewValue_InsertsAtGivenPosition()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var newNode = list.Insert(0, 10);

        list.GetHeadNode().Should().Be(newNode);
    }

    [Test]
    public void Insert_SupplyPositionJustAfterLastValue_AppendsToList()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        var newNode = list.Insert(3, 400);

        list.GetHeadNode()
            .NextNode?
            .NextNode?
            .NextNode.Should().Be(newNode);
    }

    [Test]
    public void Insert_SupplyInvalidPosition_ThrowsException()
    {
        var list = CreateGenericLinkedList(100, 200, 300);

        Action action = () => list.Insert(30, 400);

        action.Should().Throw<NodeNotFoundInListException>();
    }
}
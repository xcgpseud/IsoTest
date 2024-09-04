using NUnit.Framework;
using DataStructures;
using DataStructures.Exceptions;
using FluentAssertions;
using NUnit.Framework.Internal;
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
        intList.Insert(intNode, TestIntValue);

        var stringNode = stringList.GetHeadNode().NextNode;
        stringNode.Should().NotBeNull();
        stringList.Insert(stringNode, TestStringValue);

        var boolNode = boolList.GetHeadNode().NextNode;
        boolNode.Should().NotBeNull();
        boolList.Insert(boolNode, TestBoolValue);

        var testModelNode = testModelList.GetHeadNode().NextNode;
        testModelNode.Should().NotBeNull();
        testModelList.Insert(testModelNode, TestModelValue);

        // Check that our nodes are in the expected order
        AssertLinkedListValues(
            intList,
            [intValues[0], intValues[1], TestIntValue, intValues[2]]
        );

        AssertLinkedListValues(
            stringList,
            [stringValues[0], stringValues[1], TestStringValue, stringValues[2]]
        );

        AssertLinkedListValues(
            boolList,
            [boolValues[0], boolValues[1], TestBoolValue, boolValues[2]]
        );

        AssertLinkedListValues(
            testModelList,
            [testModelValues[0], testModelValues[1], TestModelValue, testModelValues[2]]
        );
    }

    [Test]
    public void Insert_SupplyFinalNodeAndNewValue_AppendsToList()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        var finalIntNode = intList.GetHeadNode().NextNode;
        finalIntNode.Should().NotBeNull();
        intList.Insert(finalIntNode, TestIntValue);
        AssertLinkedListValues(intList, [intValues[0], intValues[1], TestIntValue]);

        var finalStringNode = stringList.GetHeadNode().NextNode;
        finalStringNode.Should().NotBeNull();
        stringList.Insert(finalStringNode, TestStringValue);
        AssertLinkedListValues(stringList, [stringValues[0], stringValues[1], TestStringValue]);

        var finalBoolNode = boolList.GetHeadNode().NextNode;
        finalBoolNode.Should().NotBeNull();
        boolList.Insert(finalBoolNode, TestBoolValue);
        AssertLinkedListValues(boolList, [boolValues[0], boolValues[1], TestBoolValue]);

        var finalTestModelNode = testModelList.GetHeadNode().NextNode;
        finalTestModelNode.Should().NotBeNull();
        testModelList.Insert(finalTestModelNode, TestModelValue);
        AssertLinkedListValues(testModelList, [testModelValues[0], testModelValues[1], TestModelValue]);
    }

    [Test]
    public void Insert_SupplyPositionAndNewValue_InsertsAtGivenPosition()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        intList.Insert(1, TestIntValue);
        AssertLinkedListValues(intList, [intValues[0], TestIntValue, intValues[1]]);

        stringList.Insert(1, TestStringValue);
        AssertLinkedListValues(stringList, [stringValues[0], TestStringValue, stringValues[1]]);

        boolList.Insert(1, TestBoolValue);
        AssertLinkedListValues(boolList, [boolValues[0], TestBoolValue, boolValues[1]]);

        testModelList.Insert(1, TestModelValue);
        AssertLinkedListValues(testModelList, [testModelValues[0], TestModelValue, testModelValues[1]]);
    }

    [Test]
    public void Insert_SupplyPositionJustAfterLastValue_AppendsToList()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        intList.Insert(2, TestIntValue);
        stringList.Insert(2, TestStringValue);
        boolList.Insert(2, TestBoolValue);
        testModelList.Insert(2, TestModelValue);

        AssertLinkedListValues(intList, [intValues[0], intValues[1], TestIntValue]);
        AssertLinkedListValues(stringList, [stringValues[0], stringValues[1], TestStringValue]);
        AssertLinkedListValues(boolList, [boolValues[0], boolValues[1], TestBoolValue]);
        AssertLinkedListValues(testModelList, [testModelValues[0], testModelValues[1], TestModelValue]);
    }

    [Test]
    public void Insert_SupplyInvalidPosition_ThrowsException()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        var intAction = () => intList.Insert(100, TestIntValue);
        var stringAction = () => stringList.Insert(100, TestStringValue);
        var boolAction = () => boolList.Insert(100, TestBoolValue);
        var testModelAction = () => testModelList.Insert(100, TestModelValue);

        intAction.Should().Throw<NodeNotFoundInListException>();
        stringAction.Should().Throw<NodeNotFoundInListException>();
        boolAction.Should().Throw<NodeNotFoundInListException>();
        testModelAction.Should().Throw<NodeNotFoundInListException>();
    }
}
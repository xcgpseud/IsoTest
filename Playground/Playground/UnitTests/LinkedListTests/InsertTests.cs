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
        // Arrange
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        // Act
        intList.Insert(TestIntValue);
        stringList.Insert(TestStringValue);
        boolList.Insert(TestBoolValue);
        testModelList.Insert(TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [intValues[0], intValues[1], TestIntValue]);
        AssertLinkedListOrder(stringList, [stringValues[0], stringValues[1], TestStringValue]);
        AssertLinkedListOrder(boolList, [boolValues[0], boolValues[1], TestBoolValue]);
        AssertLinkedListOrder(testModelList, [testModelValues[0], testModelValues[1], TestModelValue]);
    }

    [Test]
    public void Insert_SupplyNodeInMiddleOfList_AndNewValue_InsertsAfterGivenNode()
    {
        // Arrange
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(3).SplitIntoTuples();

        var intNode = intList.GetHeadNode().NextNode;
        var stringNode = stringList.GetHeadNode().NextNode;
        var boolNode = boolList.GetHeadNode().NextNode;
        var testModelNode = testModelList.GetHeadNode().NextNode;

        intNode.Should().NotBeNull();
        stringNode.Should().NotBeNull();
        boolNode.Should().NotBeNull();
        testModelNode.Should().NotBeNull();

        // Act
        intList.Insert(intNode, TestIntValue);
        stringList.Insert(stringNode, TestStringValue);
        boolList.Insert(boolNode, TestBoolValue);
        testModelList.Insert(testModelNode, TestModelValue);

        // Assert
        AssertLinkedListOrder(
            intList,
            [intValues[0], intValues[1], TestIntValue, intValues[2]]
        );

        AssertLinkedListOrder(
            stringList,
            [stringValues[0], stringValues[1], TestStringValue, stringValues[2]]
        );

        AssertLinkedListOrder(
            boolList,
            [boolValues[0], boolValues[1], TestBoolValue, boolValues[2]]
        );

        AssertLinkedListOrder(
            testModelList,
            [testModelValues[0], testModelValues[1], TestModelValue, testModelValues[2]]
        );
    }

    [Test]
    public void Insert_SupplyFinalNodeAndNewValue_AppendsToList()
    {
        // Arrange
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        var finalIntNode = intList.GetHeadNode().NextNode;
        var finalStringNode = stringList.GetHeadNode().NextNode;
        var finalBoolNode = boolList.GetHeadNode().NextNode;
        var finalTestModelNode = testModelList.GetHeadNode().NextNode;

        finalIntNode.Should().NotBeNull();
        finalStringNode.Should().NotBeNull();
        finalBoolNode.Should().NotBeNull();
        finalTestModelNode.Should().NotBeNull();

        // Act
        intList.Insert(finalIntNode, TestIntValue);
        stringList.Insert(finalStringNode, TestStringValue);
        boolList.Insert(finalBoolNode, TestBoolValue);
        testModelList.Insert(finalTestModelNode, TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [intValues[0], intValues[1], TestIntValue]);
        AssertLinkedListOrder(stringList, [stringValues[0], stringValues[1], TestStringValue]);
        AssertLinkedListOrder(boolList, [boolValues[0], boolValues[1], TestBoolValue]);
        AssertLinkedListOrder(testModelList, [testModelValues[0], testModelValues[1], TestModelValue]);
    }

    [Test]
    public void Insert_SupplyPositionAndNewValue_InsertsAtGivenPosition()
    {
        // Arrange
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        // Act
        intList.Insert(1, TestIntValue);
        stringList.Insert(1, TestStringValue);
        boolList.Insert(1, TestBoolValue);
        testModelList.Insert(1, TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [intValues[0], TestIntValue, intValues[1]]);
        AssertLinkedListOrder(stringList, [stringValues[0], TestStringValue, stringValues[1]]);
        AssertLinkedListOrder(boolList, [boolValues[0], TestBoolValue, boolValues[1]]);
        AssertLinkedListOrder(testModelList, [testModelValues[0], TestModelValue, testModelValues[1]]);
    }

    [Test]
    public void Insert_SupplyPositionJustAfterLastValue_AppendsToList()
    {
        // Arrange
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        // Act
        intList.Insert(2, TestIntValue);
        stringList.Insert(2, TestStringValue);
        boolList.Insert(2, TestBoolValue);
        testModelList.Insert(2, TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [intValues[0], intValues[1], TestIntValue]);
        AssertLinkedListOrder(stringList, [stringValues[0], stringValues[1], TestStringValue]);
        AssertLinkedListOrder(boolList, [boolValues[0], boolValues[1], TestBoolValue]);
        AssertLinkedListOrder(testModelList, [testModelValues[0], testModelValues[1], TestModelValue]);
    }

    [Test]
    public void Insert_SupplyInvalidPosition_ThrowsException()
    {
        // Arrange
        var (
            (_, intList),
            (_, stringList),
            (_, boolList),
            (_, testModelList)
            ) = GenerateTestData(2).SplitIntoTuples();

        // Act
        var intAction = () => intList.Insert(100, TestIntValue);
        var stringAction = () => stringList.Insert(100, TestStringValue);
        var boolAction = () => boolList.Insert(100, TestBoolValue);
        var testModelAction = () => testModelList.Insert(100, TestModelValue);

        // Assert
        intAction.Should().Throw<NodeNotFoundInListException>();
        stringAction.Should().Throw<NodeNotFoundInListException>();
        boolAction.Should().Throw<NodeNotFoundInListException>();
        testModelAction.Should().Throw<NodeNotFoundInListException>();
    }
}
using NUnit.Framework;
using DataStructures;
using DataStructures.Exceptions;
using DataStructures.Models;
using FluentAssertions;
using NUnit.Framework.Internal;
using UnitTests.Models;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class InsertTests : LinkedListTestBase
{
    /**
     * To cover:
     * - Insert with node which is not in list: throws exception
     * - Insert with position which is out of bounds: thorws exception
     */
    [Test]
    public void Insert_OnlySupplyingNewValue_AppendsToList()
    {
        // Arrange
        var testData = GenerateTestData(2);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

        // Act
        intList.Append(TestIntValue);
        stringList.Append(TestStringValue);
        boolList.Append(TestBoolValue);
        testModelList.Append(TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [intValues[0], intValues[1], TestIntValue]);
        AssertLinkedListOrder(stringList, [stringValues[0], stringValues[1], TestStringValue]);
        AssertLinkedListOrder(boolList, [boolValues[0], boolValues[1], TestBoolValue]);
        AssertLinkedListOrder(testModelList, [testModelValues[0], testModelValues[1], TestModelValue]);
    }

    [Test]
    public void Insert_SupplyNodeAtStartOfList_AndNewValue_InsertsAtFirstNode()
    {
        // Arrange
        var testData = GenerateTestData(2);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

        // Act
        intList.Insert(intList.GetHeadNode(), TestIntValue);
        stringList.Insert(stringList.GetHeadNode(), TestStringValue);
        boolList.Insert(boolList.GetHeadNode(), TestBoolValue);
        testModelList.Insert(testModelList.GetHeadNode(), TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [TestIntValue, intValues[0], intValues[1]]);
        AssertLinkedListOrder(stringList, [TestStringValue, stringValues[0], stringValues[1]]);
        AssertLinkedListOrder(boolList, [TestBoolValue, boolValues[0], boolValues[1]]);
        AssertLinkedListOrder(testModelList, [TestModelValue, testModelValues[0], testModelValues[1]]);
    }

    [Test]
    public void Insert_SupplyNodeInMiddleOfList_AndNewValue_InsertsAtGivenNode()
    {
        // Arrange
        var testData = GenerateTestData(3);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

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
            [intValues[0], TestIntValue, intValues[1], intValues[2]]
        );
        AssertLinkedListOrder(
            stringList,
            [stringValues[0], TestStringValue, stringValues[1], stringValues[2]]
        );
        AssertLinkedListOrder(
            boolList,
            [boolValues[0], TestBoolValue, boolValues[1], boolValues[2]]
        );
        AssertLinkedListOrder(
            testModelList,
            [testModelValues[0], TestModelValue, testModelValues[1], testModelValues[2]]
        );
    }

    [Test]
    public void Insert_SupplyNodeAtEndOfList_AndNewValue_InsertsJustBeforeEndOfList()
    {
        // Arrange
        var testData = GenerateTestData(2);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

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
        AssertLinkedListOrder(intList, [intValues[0], TestIntValue, intValues[1]]);
        AssertLinkedListOrder(stringList, [stringValues[0], TestStringValue, stringValues[1]]);
        AssertLinkedListOrder(boolList, [boolValues[0], TestBoolValue, boolValues[1]]);
        AssertLinkedListOrder(testModelList, [testModelValues[0], TestModelValue, testModelValues[1]]);
    }

    [Test]
    public void Insert_SupplyPositionAtStartOfList_AndNewValue_InsertsAtStartOfList()
    {
        // Arrange
        var testData = GenerateTestData(2);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

        // Act
        intList.Insert(0, TestIntValue);
        stringList.Insert(0, TestStringValue);
        boolList.Insert(0, TestBoolValue);
        testModelList.Insert(0, TestModelValue);

        // Assert
        AssertLinkedListOrder(intList, [TestIntValue, intValues[0], intValues[1]]);
        AssertLinkedListOrder(stringList, [TestStringValue, stringValues[0], stringValues[1]]);
        AssertLinkedListOrder(boolList, [TestBoolValue, boolValues[0], boolValues[1]]);
        AssertLinkedListOrder(testModelList, [TestModelValue, testModelValues[0], testModelValues[1]]);
    }

    [Test]
    public void Insert_SupplyPositionInMiddleOfList_AndNewValue_InsertsAtGivenPosition()
    {
        // Arrange
        var testData = GenerateTestData(2);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

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
    public void Insert_SupplyPositionOneAfterEndOfList_AndNewValue_AppendsToList()
    {
        // Arrange
        var testData = GenerateTestData(2);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

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
    public void Insert_SupplyInvalidNode_ThrowsException()
    {
        // Arrange
        var testData = GenerateTestData(2);

        // Act
        var intAction = () => testData.IntLinkedList.Insert(new Node<int>(), TestIntValue);
        var stringAction = () => testData.StringLinkedList.Insert(new Node<string>(), TestStringValue);
        var boolAction = () => testData.BoolLinkedList.Insert(new Node<bool>(), TestBoolValue);
        var testModelAction = () => testData.TestModelLinkedList.Insert(new Node<TestModel>(), TestModelValue);

        // Assert
        intAction.Should().Throw<NodeNotFoundInListException>();
        stringAction.Should().Throw<NodeNotFoundInListException>();
        boolAction.Should().Throw<NodeNotFoundInListException>();
        testModelAction.Should().Throw<NodeNotFoundInListException>();
    }

    [Test]
    public void Insert_SupplyInvalidPosition_ThrowsException()
    {
        // Arrange
        var testData = GenerateTestData(2);

        // Act
        var intAction = () => testData.IntLinkedList.Insert(100, TestIntValue);
        var stringAction = () => testData.StringLinkedList.Insert(100, TestStringValue);
        var boolAction = () => testData.BoolLinkedList.Insert(100, TestBoolValue);
        var testModelAction = () => testData.TestModelLinkedList.Insert(100, TestModelValue);

        // Assert
        intAction.Should().Throw<NodeNotFoundInListException>();
        stringAction.Should().Throw<NodeNotFoundInListException>();
        boolAction.Should().Throw<NodeNotFoundInListException>();
        testModelAction.Should().Throw<NodeNotFoundInListException>();
    }
}
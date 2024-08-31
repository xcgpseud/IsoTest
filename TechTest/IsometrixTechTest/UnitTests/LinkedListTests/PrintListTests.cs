using DataStructures;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.Models;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class PrintListTests : LinkedListTestBase
{
    [Test]
    public void PrintList_EmptyList_ReturnsDefaultValueAsString()
    {
        var intList = GenericLinkedList<int>.Create();
        var stringList = GenericLinkedList<string>.Create();
        var boolList = GenericLinkedList<bool>.Create();
        var objectList = GenericLinkedList<TestModel>.Create();

        intList.PrintList().Should().Be("0");
        stringList.PrintList().Should().Be(string.Empty);
        boolList.PrintList().Should().Be("False");
        objectList.PrintList().Should().Be(string.Empty);
    }

    [Test]
    public void PrintList_WithSingleNode_ReturnsNodeValue()
    {
        var intList = CreateGenericLinkedList(100);

        intList.PrintList().Should().Be("100");
    }

    [Test]
    public void PrintList_ReturnsEveryNodeInCorrectFormat()
    {
        var intList = CreateGenericLinkedList(100, 200, 300);
        var stringList = CreateGenericLinkedList("hello", "world");
        var boolList = CreateGenericLinkedList(true, false, true);
        var objectList = CreateGenericLinkedList(
            new TestModel { Id = 1, Data = "Hello World" },
            new TestModel { Id = 2, Data = "Goodbye Moon" }
        );

        intList.PrintList().Should().Be("100 -> 200 -> 300");
        stringList.PrintList().Should().Be("hello -> world");
        boolList.PrintList().Should().Be("True -> False -> True");
        // (See custom ToString on TestModel)
        objectList.PrintList().Should().Be("ID: 1, Data: Hello World -> ID: 2, Data: Goodbye Moon");
    }
}
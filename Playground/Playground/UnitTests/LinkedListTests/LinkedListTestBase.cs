using DataStructures;
using DataStructures.Models;
using FluentAssertions;
using UnitTests.Factories;
using UnitTests.Models;
using UnitTests.Structs;

namespace UnitTests.LinkedListTests;

public class LinkedListTestBase
{
    protected const int TestIntValue = 1000;
    protected const string TestStringValue = "Hello World";
    protected const bool TestBoolValue = true;

    protected readonly TestModel TestModelValue = new()
    {
        Guid = Guid.NewGuid(),
        Data = Guid.NewGuid().ToString(),
    };

    protected readonly Func<int?, int?> DoubleInt = x => x * 2;
    protected readonly Func<string?, string?> DoubleString = x => $"{x} {x}";
    protected readonly Func<bool?, bool?> FlipBool = x => !x;

    protected readonly Func<TestModel?, TestModel?> DoubleModelData = x =>
    {
        if (x == null)
        {
            return null;
        }

        x.Data = $"{x.Data} {x.Data}";

        return x;
    };

    protected IGenericLinkedList<T> CreateGenericLinkedList<T>(params T[] values)
    {
        if (values.Length == 0)
        {
            return GenericLinkedList<T>.Create();
        }

        var list = GenericLinkedList<T>.Create(values.First());
        var currentHeadNode = list.GetHeadNode();

        // Build the nodes manually, in reverse, to really prove that we're getting exactly what we want with this
        for (var i = 1; i < values.Length; i++)
        {
            // This node will be the next value
            var node = new Node<T> { Value = values[i] };

            // Set our next node to this new node
            currentHeadNode.NextNode = node;

            // And simply set the current head node to the next one, so it recurses
            currentHeadNode = node;
        }

        // Now we have a clean list with all the passed values, without relying on any of our methods
        return list;
    }

    // Reusable method to compare all values on a list with an array of in-order values
    protected void AssertLinkedListValues<T>(IGenericLinkedList<T> linkedList, IEnumerable<T> expectedValues)
    {
        var currentNode = linkedList.GetHeadNode();

        foreach (var value in expectedValues)
        {
            currentNode.Should().NotBeNull();
            currentNode.Value.Should().Be(value);

            currentNode = currentNode.NextNode;
        }
    }

    protected TestDataStruct GenerateTestData(
        int numberOfEachElement,
        int intFloor = int.MinValue,
        int intCeiling = int.MaxValue
    )
    {
        var intData = TestDataFactory.GenerateRandomNumbers(
            numberOfEachElement,
            intFloor,
            intCeiling
        ).ToArray();
        var stringData = TestDataFactory.GenerateRandomStrings(numberOfEachElement).ToArray();
        var boolData = TestDataFactory.GenerateRandomBooleans(numberOfEachElement).ToArray();
        var testModelData = TestDataFactory.GenerateRandomTestModels(numberOfEachElement).ToArray();

        return new TestDataStruct
        {
            IntData = (intData, CreateGenericLinkedList(intData)),
            StringData = (stringData, CreateGenericLinkedList(stringData)),
            BooleanData = (boolData, CreateGenericLinkedList(boolData)),
            TestModelData = (testModelData, CreateGenericLinkedList(testModelData)),
        };
    }
}
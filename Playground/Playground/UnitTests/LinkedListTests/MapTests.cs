using NUnit.Framework;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class MapTests : LinkedListTestBase
{
    [Test]
    public void Map_ValidValues_ValidFunction_MapsFunctionToValues()
    {
        var list = CreateGenericLinkedList<int?>(100, 200, 300);
        var expectedValues = new int?[] { 200, 400, 600 };

        var result = list.Map(DoubleInt);

        AssertLinkedListValues(result, expectedValues);
    }

    [Test]
    public void Map_NullValues_ValidFunction_ReturnsListOfNulls()
    {
        var list = CreateGenericLinkedList<int?>(null, null, null);

        var result = list.Map(DoubleInt);

        AssertLinkedListValues(result, new int?[] { null, null, null });
    }
}
using NUnit.Framework;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class MapTests : LinkedListTestBase
{
    [Test]
    public void Map_ValidValues_ValidFunction_MapsFunctionToValues()
    {
        // Arrange
        var list = CreateGenericLinkedList<int?>(100, 200, 300);
        var expectedValues = new int?[] { 200, 400, 600 };

        // Act
        var result = list.Map(DoubleInt);

        // Assert
        AssertLinkedListOrder(result, expectedValues);
    }

    [Test]
    public void Map_NullValues_ValidFunction_ReturnsListOfNulls()
    {
        // Arrange
        var list = CreateGenericLinkedList<int?>(null, null, null);

        // Act
        var result = list.Map(DoubleInt);

        // Assert
        AssertLinkedListOrder(result, new int?[] { null, null, null });
    }
}
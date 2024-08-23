using DataStructures;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.Models;

namespace UnitTests.LinkedListTests;

[TestFixture]
public class CreateTests : LinkedListTestBase
{
    [Test]
    public void Create_NoValue_CreatesListWithEmptyNode()
    {
        var intList = GenericLinkedList<int>.Create();
        var stringList = GenericLinkedList<string>.Create();
        var boolList = GenericLinkedList<bool>.Create();
        var objectList = GenericLinkedList<TestModel>.Create();

        intList.GetHeadNode().Should().BeNull();
        stringList.GetHeadNode().Should().BeNull();
        boolList.GetHeadNode().Should().BeNull();
        objectList.GetHeadNode().Should().BeNull();
    }

    [Test]
    public void Create_WithValue_CreatesListWithFilledNode()
    {
        const int testIntData = 10;
        const string testStringData = "hello world";
        const bool testBoolData = true;
        const string testObjectData = "Test Model Data";

        var intList = GenericLinkedList<int>.Create(10);
        var stringList = GenericLinkedList<string>.Create("hello");
        var boolList = GenericLinkedList<bool>.Create(true);
        var objectList = GenericLinkedList<TestModel>.Create(
            new TestModel
            {
                Id = 1,
                Data = testObjectData,
            }
        );

        intList.GetHeadNode().Value.Should().Be(testIntData);
        stringList.GetHeadNode().Value.Should().Be(testStringData);
        boolList.GetHeadNode().Value.Should().Be(testBoolData);
        objectList.GetHeadNode().Value.Data.Should().Be(testObjectData);
    }
}
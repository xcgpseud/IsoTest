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

        intList.GetHeadNode().Value.Should().Be(0);
        stringList.GetHeadNode().Value.Should().BeNull();
        boolList.GetHeadNode().Value.Should().Be(false);
        objectList.GetHeadNode().Value.Should().BeNull();
    }

    [Test]
    public void Create_WithValue_CreatesListWithFilledNode()
    {
        const int testIntData = 10;
        const string testStringData = "hello world";
        const bool testBoolData = true;
        const string testObjectData = "Test Model Data";

        var intList = GenericLinkedList<int>.Create(testIntData);
        var stringList = GenericLinkedList<string>.Create(testStringData);
        var boolList = GenericLinkedList<bool>.Create(testBoolData);
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
        objectList.GetHeadNode().Value?.Data.Should().Be(testObjectData);
    }
}
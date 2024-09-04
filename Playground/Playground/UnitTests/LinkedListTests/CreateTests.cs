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
        var intList = GenericLinkedList<int>.Create(TestIntValue);
        var stringList = GenericLinkedList<string>.Create(TestStringValue);
        var boolList = GenericLinkedList<bool>.Create(TestBoolValue);
        var testModelList = GenericLinkedList<TestModel>.Create(
            new TestModel
            {
                Guid = TestModelValue.Guid,
                Data = TestModelValue.Data,
            }
        );

        intList.GetHeadNode().Value.Should().Be(TestIntValue);
        stringList.GetHeadNode().Value.Should().Be(TestStringValue);
        boolList.GetHeadNode().Value.Should().Be(TestBoolValue);
        testModelList.GetHeadNode().Value?.Guid.Should().Be(TestModelValue.Guid);
        testModelList.GetHeadNode().Value?.Data.Should().Be(TestModelValue.Data);
    }
}
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
        // Arrange
        var testData = GenerateTestData(0);
        var intList = testData.IntLinkedList;
        var stringList = testData.StringLinkedList;
        var boolList = testData.BoolLinkedList;
        var testModelList = testData.TestModelLinkedList;

        // Act
        // Assert
        AssertLinkedListOrder(intList, []);
        AssertLinkedListOrder(stringList, []);
        AssertLinkedListOrder(boolList, []);
        AssertLinkedListOrder(testModelList, []);

        intList.PrintList().Should().Be("0");
        stringList.PrintList().Should().Be(string.Empty);
        boolList.PrintList().Should().Be("False");
        testModelList.PrintList().Should().Be(string.Empty);
    }

    [Test]
    public void PrintList_WithSingleNode_ReturnsNodeValue()
    {
        // Arrange
        var testData = GenerateTestData(1);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();

        // Act
        // Assert
        intList.PrintList().Should().Be(intValues.First().ToString());
        stringList.PrintList().Should().Be(stringValues.First());
        boolList.PrintList().Should().Be(boolValues.First().ToString());
        testModelList.PrintList().Should().Be(testModelValues.First().ToString());
    }

    [Test]
    public void PrintList_ReturnsEveryNodeInCorrectFormat()
    {
        // Arrange
        var testData = GenerateTestData(3);
        var (intValues, intList) = testData.GetIntData();
        var (stringValues, stringList) = testData.GetStringData();
        var (boolValues, boolList) = testData.GetBoolData();
        var (testModelValues, testModelList) = testData.GetTestModelData();
        
        var expectedIntPrint = string.Join(" -> ", intValues);
        var expectedStringPrint = string.Join(" -> ", stringValues);
        var expectedBoolPrint = string.Join(" -> ", boolValues);
        var expectedTestModelPrint = string.Join(" -> ", testModelValues.ToList());

        // Act
        // Assert
        intList.PrintList().Should().Be(expectedIntPrint);
        stringList.PrintList().Should().Be(expectedStringPrint);
        boolList.PrintList().Should().Be(expectedBoolPrint);
        testModelList.PrintList().Should().Be(expectedTestModelPrint);
    }
}
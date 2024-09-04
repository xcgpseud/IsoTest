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
        var ((_, intList),
            (_, stringList),
            (_, boolList),
            (_, testModelList)) = GenerateTestData(0).SplitIntoTuples();

        AssertLinkedListValues(intList, []);
        AssertLinkedListValues(stringList, []);
        AssertLinkedListValues(boolList, []);
        AssertLinkedListValues(testModelList, []);

        intList.PrintList().Should().Be("0");
        stringList.PrintList().Should().Be(string.Empty);
        boolList.PrintList().Should().Be("False");
        testModelList.PrintList().Should().Be(string.Empty);
    }

    [Test]
    public void PrintList_WithSingleNode_ReturnsNodeValue()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(1).SplitIntoTuples();

        intList.PrintList().Should().Be(intValues.First().ToString());
        stringList.PrintList().Should().Be(stringValues.First());
        boolList.PrintList().Should().Be(boolValues.First().ToString());
        testModelList.PrintList().Should().Be(testModelValues.First().ToString());
    }

    [Test]
    public void PrintList_ReturnsEveryNodeInCorrectFormat()
    {
        var (
            (intValues, intList),
            (stringValues, stringList),
            (boolValues, boolList),
            (testModelValues, testModelList)
            ) = GenerateTestData(3).SplitIntoTuples();

        var expectedIntPrint = string.Join(" -> ", intValues);
        var expectedStringPrint = string.Join(" -> ", stringValues);
        var expectedBoolPrint = string.Join(" -> ", boolValues);
        var expectedTestModelPrint = string.Join(" -> ", testModelValues);

        intList.PrintList().Should().Be(expectedIntPrint);
        stringList.PrintList().Should().Be(expectedStringPrint);
        boolList.PrintList().Should().Be(expectedBoolPrint);
        testModelList.PrintList().Should().Be(expectedTestModelPrint);
    }
}
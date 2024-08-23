using FluentAssertions;
using NUnit.Framework;
using StringHelpers;
using StringHelpers.Exceptions;

namespace UnitTests.StringCalculatorTests;

[TestFixture]
public class AddTests
{
    [Test]
    public void Add_EmptyString_ReturnsZero()
    {
        const string inputString = "";

        var result = StringCalculator.Add(inputString);

        result.Should().Be(0);
    }

    [TestCase("1,10\n100,1000", 1111)]
    [TestCase("5,500,250", 755)]
    [TestCase("5,400\n250", 655)]
    [TestCase("5,10", 15)]
    [TestCase("5\n5", 10)]
    [TestCase("150", 150)]
    public void Add_Several_CommaAndOrNewLineSeparated_ReturnsSum(
        string inputString,
        int expectedSum
    )
    {
        var result = StringCalculator.Add(inputString);

        result.Should().Be(expectedSum);
    }

    [TestCase("//?\n1?2?3", 6)]
    [TestCase("//?\n2,4?6", 12)]
    [TestCase("//@\n4@8\n12,10@100", 134)]
    public void Add_CustomDelimiter_AloneOrWithCommasAndNewLines_ReturnsSum(
        string inputString,
        int expectedSum
    )
    {
        var result = StringCalculator.Add(inputString);

        result.Should().Be(expectedSum);
    }

    [TestCase("1,-1", "-1")]
    [TestCase("1\n-5", "-5")]
    [TestCase("-4,-9", "-4, -9")]
    public void Add_NegativeNumbers_ThrowsNegativeNumberFoundException(
        string inputString,
        string expectedInvalidNumbers
    )
    {
        Action act = () => StringCalculator.Add(inputString);

        act
            .Should()
            .Throw<NegativeNumberFoundException>()
            .Where(exception => exception.Message.Contains(expectedInvalidNumbers));
    }

    [TestCase("5,5000", 5)]
    [TestCase("5000\n6000", 0)]
    [TestCase("1000,1001", 1000)]
    public void Add_NumbersLargerThan1000_AreIgnored(string inputString, int expectedSum)
    {
        var result = StringCalculator.Add(inputString);

        result.Should().Be(expectedSum);
    }

    // Bonus tests

    [TestCase("//[hello world]\n10hello world50", 60)]
    [TestCase("//[***]\n500***10***20", 530)]
    [TestCase("//[***][hello world]\n100***500", 600)]
    [TestCase("//[***][hello world]\n100hello world600", 700)]
    [TestCase("//[*][-]\n2-3", 5)]
    public void Add_LargeDelimiters_InSquareBrackets_WorksAsExpected(string inputString, int expectedSum)
    {
        var result = StringCalculator.Add(inputString);

        result.Should().Be(expectedSum);
    }

    [Test]
    public void Add_InvalidDelimiterFormat_ThrowsException()
    {
        const string inputString = "//[hello[world]\n10hello20world";

        Action act = () => StringCalculator.Add(inputString);

        act
            .Should()
            .Throw<InvalidDelimiterFormatException>();
    }
}
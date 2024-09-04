using UnitTests.Models;

namespace UnitTests.Factories;

public static class TestDataFactory
{
    private static Random CreateRandom() => new Random(Guid.NewGuid().GetHashCode());

    public static IEnumerable<int> GenerateRandomNumbers(
        int count,
        int minimum = int.MinValue,
        int maximum = int.MaxValue
    )
    {
        var random = CreateRandom();

        return Enumerable
            .Range(0, count)
            .Select(_ => random.Next(minimum, maximum));
    }

    public static IEnumerable<string> GenerateRandomStrings(int count) =>
        Enumerable
            .Range(0, count)
            .Select(_ => Guid.NewGuid().ToString());

    public static IEnumerable<bool> GenerateRandomBooleans(int count)
    {
        var random = CreateRandom();

        return Enumerable
            .Range(0, count)
            .Select(_ => random.Next(1, 2) == 2);
    }

    public static IEnumerable<TestModel> GenerateRandomTestModels(int count)
    {
        return Enumerable
            .Range(0, count)
            .Select(
                _ => new TestModel
                {
                    Guid = Guid.NewGuid(),
                    Data = Guid.NewGuid().ToString(),
                }
            );
    }
}
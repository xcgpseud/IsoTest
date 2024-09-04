using DataStructures;
using UnitTests.Models;

namespace UnitTests.Structs;

public readonly struct TestDataStruct
{
    public (int[], IGenericLinkedList<int>) IntData { get; init; }

    public (string[], IGenericLinkedList<string>) StringData { get; init; }

    public (bool[], IGenericLinkedList<bool>) BooleanData { get; init; }

    public (TestModel[], IGenericLinkedList<TestModel>) TestModelData { get; init; }

    public (
        (int[], IGenericLinkedList<int>),
        (string[], IGenericLinkedList<string>),
        (bool[], IGenericLinkedList<bool>),
        (TestModel[], IGenericLinkedList<TestModel>)
        ) SplitIntoTuples()
    {
        return (
            IntData,
            StringData,
            BooleanData,
            TestModelData
        );
    }
}
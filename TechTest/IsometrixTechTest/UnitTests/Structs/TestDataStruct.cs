using DataStructures;
using UnitTests.Models;

namespace UnitTests.Structs;

public struct TestDataStruct
{
    public (IEnumerable<int>, IGenericLinkedList<int>) IntData { get; set; }

    public (IEnumerable<string>, IGenericLinkedList<string>) StringData { get; set; }

    public (IEnumerable<bool>, IGenericLinkedList<bool>) BooleanData { get; set; }

    public (IEnumerable<TestModel>, IGenericLinkedList<TestModel>) TestModelData { get; set; }

    public (
        (IEnumerable<int>, IGenericLinkedList<int>),
        (IEnumerable<string>, IGenericLinkedList<string>),
        (IEnumerable<bool>, IGenericLinkedList<bool>),
        (IEnumerable<TestModel>, IGenericLinkedList<TestModel>)
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
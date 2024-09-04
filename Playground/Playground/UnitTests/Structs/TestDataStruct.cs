using DataStructures;
using UnitTests.Models;

namespace UnitTests.Structs;

public readonly struct TestDataStruct
{
    public int[] IntValues { get; init; }
    public string[] StringValues { get; init; }
    public bool[] BoolValues { get; init; }
    public TestModel[] TestModelValues { get; init; }

    public IGenericLinkedList<int> IntLinkedList { get; init; }
    public IGenericLinkedList<string> StringLinkedList { get; init; }
    public IGenericLinkedList<bool> BoolLinkedList { get; init; }
    public IGenericLinkedList<TestModel> TestModelLinkedList { get; init; }

    public (int[], IGenericLinkedList<int>) GetIntData() => (IntValues, IntLinkedList);
    public (string[], IGenericLinkedList<string>) GetStringData() => (StringValues, StringLinkedList);
    public (bool[], IGenericLinkedList<bool>) GetBoolData() => (BoolValues, BoolLinkedList);
    public (TestModel[], IGenericLinkedList<TestModel>) GetTestModelData() => (TestModelValues, TestModelLinkedList);
}

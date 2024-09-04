namespace UnitTests.Models;

public class TestModel
{
    public Guid Guid { get; set; }

    public string Data { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"GUID: {Guid}, Data: {Data}";
    }
}
namespace UnitTests.Models;

public class TestModel
{
    public int Id { get; set; }

    public string Data { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"ID: {Id}, Data: {Data}";
    }
}
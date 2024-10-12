namespace Core.ValueObjects;

public readonly record struct Code
{
    private string Value { get; init; }

    public Code(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(Code value)
    {
        return value.Value;
    }
}
namespace Core.ValueObjects;

public readonly record struct Total
{
    private int Value { get; init; }

    public Total(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(Total value)
    {
        return value.Value;
    }
}
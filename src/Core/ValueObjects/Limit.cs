namespace Core.ValueObjects;

public readonly record struct Limit
{
    private int Value { get; init; }

    public Limit(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(Limit value)
    {
        return value.Value;
    }
}
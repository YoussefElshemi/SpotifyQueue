namespace Core.ValueObjects;

public readonly record struct Duration
{
    private int Value { get; init; }

    public Duration(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(Duration value)
    {
        return value.Value;
    }
}
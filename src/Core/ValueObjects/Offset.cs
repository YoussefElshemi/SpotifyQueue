namespace Core.ValueObjects;

public readonly record struct Offset
{
    private int Value { get; init; }

    public Offset(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator int(Offset value)
    {
        return value.Value;
    }
}